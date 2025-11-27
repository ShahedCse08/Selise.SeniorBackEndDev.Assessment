param (
    [string]$sourcePath,
    [string]$destinationPath = "C:\inetpub\wwwroot\MyApp"
)

Write-Host "Stopping IIS..."
iisreset /stop

Write-Host "Copying files to IIS folder..."
Remove-Item $destinationPath\* -Recurse -Force
Copy-Item $sourcePath\* $destinationPath -Recurse

Write-Host "Starting IIS..."
iisreset /start

Write-Host "Deployment completed."
