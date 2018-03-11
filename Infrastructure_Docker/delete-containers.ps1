
Write-Host "Deleting Event Store container and volume"
docker rm -v cont-canonnapi-eventstore
docker volume rm vol-canonnapi-eventstore

Write-Host "Deleting Redis container and volume"
docker rm -v cont-canonnapi-redis
docker volume rm vol-canonnapi-redis
