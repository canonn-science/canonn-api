Write-Host "Stopping Event Store"
docker stop --time 2 cont-canonnapi-eventstore

Write-Host "Stopping Redis"
docker stop cont-canonnapi-redis
