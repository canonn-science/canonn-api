# This scripts cleans the projects from all artifacts
Get-ChildItem -inc bin,obj,packages,node_modules -rec | Remove-Item -rec -force
