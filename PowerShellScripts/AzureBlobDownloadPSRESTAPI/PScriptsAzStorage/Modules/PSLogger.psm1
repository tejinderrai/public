
Function Write-To-LogFile ([string]$LogEntry, [string]$LogFilePath, [string]$LogFileName) {

    If($LogEntry -ne $null -and $LogFilePath -ne $null -and $LogFileName -ne $null) {

        $Now = Get-Date
        Add-Content -Path "$LogFilePath\$LogFileName" -Value "$Now : $LogEntry"

    }
}

Export-ModuleMember Write-To-LogFile