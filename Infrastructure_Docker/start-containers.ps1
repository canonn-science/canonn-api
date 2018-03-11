
Write-Host "Starting Event Store"
Start-Process docker "start cont-canonnapi-eventstore --interactive"

Write-Host "Starting Redis"
Start-Process docker "start cont-canonnapi-redis --interactive"
