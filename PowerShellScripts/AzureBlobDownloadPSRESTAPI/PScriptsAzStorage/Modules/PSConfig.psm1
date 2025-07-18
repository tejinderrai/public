Function GetScriptConfig ([string]$ConfigFileWithPath){

    $ConfigData = Get-Content -Path $ConfigFileWithPath -Raw | Out-String | ConvertFrom-Json

    return $ConfigData
}


Export-ModuleMember GetScriptConfig