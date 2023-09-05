FROM mcr.microsoft.com/dotnet/sdk:7.0-windowsservercore-ltsc2019 AS builder
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop'; $ProgressPreference = 'SilentlyContinue';"]

WORKDIR /.
# add SSDT build tools
RUN [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12 ; \
   Invoke-WebRequest "https://dist.nuget.org/win-x86-commandline/v5.6.0/nuget.exe" -UseBasicParsing -OutFile "$env:ProgramFiles\NuGet\nuget.exe"
# add SqlPackage tool

ENV download_url="https://download.microsoft.com/download/6/E/4/6E406E38-0A01-4DD1-B85E-6CA7CF79C8F7/EN/x64/DacFramework.msi"
RUN Invoke-WebRequest -Uri $env:download_url -OutFile DacFramework.msi ; \
    Start-Process msiexec.exe -ArgumentList '/i', 'DacFramework.msi', '/quiet', '/norestart' -NoNewWindow -Wait; \
    Remove-Item -Force DacFramework.msi

FROM mcr.microsoft.com/mssql/server:2019-latest

# Install SQLPackage 
RUN Invoke-WebRequest -Uri https://go.microsoft.com/fwlink/?linkid=2113704 -OutFile sqlpackage.zip; Expand-Archive -Path sqlpackage.zip -DestinationPath sqlpackage

# Add the DACPAC to the image
COPY --from=builder ["db.dacpac", "/db.dacpac"]

# Configure external build arguments to allow configurability.
ARG DBNAME=EfExpenseDemo
ARG PASSWORD

# Configure the required environmental variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=$env:PASSWORD
RUN "C:\sqlpackage\sqlpackage.exe" /a:Publish /sf:"db.dacpac" /tsn:. /tdn:$env:DBNAME