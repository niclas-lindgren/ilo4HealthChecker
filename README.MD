# Summary
Logs on to the **iLo 4** server, checks the system status and if any errors sends an email.

# Installation
1. Update the `iLoHealthCheckerConfiguration.json_TEMPLATE`
2. Make the main program executable (from same directory) `chmod +x iloHealthChecker`
3. Execute it with (from same directory) `./iloHealthChecker`
4. Optional: add cron job

# Publish
Example of publish from within the iloHealthChecker src folder `dotnet publish -c Release -o ../../publish/ -p:PublishSingleFile=true --self-contained -r linux-arm`