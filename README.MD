# Summary
Logs on to the **iLo 4** server, scrapes the system status page and if any errors sends an email.

# Installation
1. Update the `iLoHealthCheckerConfiguration.json` and copy it to the same folder as your executable.
2. Make the main program executable (from same directory) `chmod +x iloHealthChecker`
3. Execute it with (from same directory) `./iloHealthChecker`
4. Optional: add cron job

# Publish
Example of publish from within the iloHealthChecker src folder `dotnet publish -c Release -o ../../publish/ -p:PublishSingleFile=true --self-contained -r linux-arm`
