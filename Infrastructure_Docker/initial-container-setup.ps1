
Write-Host "Activating Event Store projections"

$ProjectionsToActivate = @("`$by_category", "`$by_event_type", "`$stream_by_category", "`$streams")
$EventStoreAdminCredential = New-Object -TypeName "System.Management.Automation.PSCredential" -ArgumentList "admin", (ConvertTo-SecureString -String "changeit" -AsPlainText -Force)
$ProjectionsToActivate |foreach {
	Write-Host "Activating projection: $_"
	$Response = Invoke-WebRequest `
		"http://localhost:2113/projection/$_/command/enable" `
		-Method 'POST' `
		-Body @{
			msgTypeId = 293
			name = "$_"
		} `
		-Credential $EventStoreAdminCredential
}

Remove-Variable Response
Remove-Variable EventStoreAdminCredential
Remove-Variable ProjectionsToActivate
