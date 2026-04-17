# Connect to Azure AD using a admin account

# Integration Service Object Principal Id = 845413f4-d020-44ee-a798-6ac0234bc2c8

$ManagedIdentityId = "[Managed Identity Id from VM in Azure Portal]"
$ManagedIdentityAppId = "[Enterprise Application ID = App Id]"
#$AppObjectId = "[Same as Managed Identity Id from VM in Azure Portal]"
$MailboxId  = "[Mailbox SMTP Address]"
$EntraIdTenantId = "[Not used for EXO admin - by Entra ID tenant id]"
$ExchangeAdminUPN = "[Exchange Admin email address]"
$MailBoxRBACScope = "APMailboxSingleMailboxScope"

# Remove old M365 EXO PS Modules if present (Launch PSE as Administrator)
#Remove-Module -Name ExchangeOnlineManagement

# Install a stable vesion of the M365 EXO PS Module
#Install-Module -Name ExchangeOnlineManagement -RequiredVersion 3.6.0 -Force 

#Import M365 EXO Module
Import-Module ExchangeOnlineManagement

# Connect as signed in principal
Connect-ExchangeOnline -UserPrincipalName $ExchangeAdminUPN

# Using RBAC Method - Create a management scope to target the specific mailbox
# https://learn.microsoft.com/en-us/exchange/permissions-exo/application-rbac

#Enable Organisation Customisation
Enable-OrganizationCustomization

# Check Organisation Customization - False = Enabled
Get-OrganizationConfig | fl IsDehydrated

# New Management Scope
New-ManagementScope -Name $MailBoxRBACScope -RecipientRestrictionFilter 'PrimarySmtpAddress -eq "mailbox@maildomain.com"'
$mgtScope = Get-ManagementScope | Where-Object {$_.Name -eq $MailBoxRBACScope }
$mgtScope

# Create the EXP Service Principal to match the Azure AD SP - No Auto Sync is available for this.	
New-ServicePrincipal -AppId $ManagedIdentityAppId -ServiceId $ManagedIdentityId

# Assign the required role 
$RoleAssignment1 = New-ManagementRoleAssignment -App $ManagedIdentityId -Role "Application Mail.ReadWrite" -CustomResourceScope $MailBoxRBACScope 
$RoleAssignment2 = New-ManagementRoleAssignment -App $ManagedIdentityId -Role "Application MailboxFolder.ReadWrite" -CustomResourceScope $MailBoxRBACScope 

Set-ManagementRoleAssignment -Identity $RoleAssignment1.Identity -CustomResourceScope $MailBoxRBACScope 
Set-ManagementRoleAssignment -Identity $RoleAssignment2.Identity -CustomResourceScope $MailBoxRBACScope 

# List Role Assignments
Get-ManagementRoleAssignment -RoleAssignee $ManagedIdentityAppId | Format-List

# Test Authorisation
Test-ServicePrincipalAuthorization -Identity $ManagedIdentityAppId | Format-List

# Removing the assignments and configuration
#Get-ManagementRoleAssignment -RoleAssignee $ManagedIdentityId  | Remove-ManagementRoleAssignment
#Get-ManagementScope 
#Get-ManagementRoleAssignment -RoleAssignee $ManagedIdentityId | Format-List
#Get-ManagementRoleAssignment -RoleAssignee $ManagedIdentityId  | Where-Object {$_.CustomResourceScope -eq $MailBoxRBACScope } | Remove-ManagementRoleAssignment
# Remove - Tidy Up
#$ManagementScope = Get-ManagementScope | Where-Object {$_.Name -eq  "APMailboxSingleMailboxScope3"}
#Remove-ManagementScope -Identity $ManagementScope.Id -Force
# Remove Service Principal
#Remove-ServicePrincipal -Identity $ManagedIdentityAppId






