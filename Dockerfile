FROM mcr.microsoft.com/mssql/server:2019-latest

# add SSDT build tools
RUN nuget install Microsoft.Data.Tools.Msbuild -Version 10.0.61804.210

# add SqlPackage tool
ENV download_url="https://download.microsoft.com/download/6/E/4/6E406E38-0A01-4DD1-B85E-6CA7CF79C8F7/EN/x64/DacFramework.msi"
RUN Invoke-WebRequest -Uri $env:download_url -OutFile DacFramework.msi ; \
    Start-Process msiexec.exe -ArgumentList '/i', 'DacFramework.msi', '/quiet', '/norestart' -NoNewWindow -Wait; \
    Remove-Item -Force DacFramework.msi

# Add the DACPAC to the image
COPY db.bacpac /tmp/db/db.dacpac

# Configure external build arguments to allow configurability.
ARG DBNAME=Database
ARG PASSWORD

# Configure the required environmental variables
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=$PASSWORD

# Launch SQL Server, confirm startup is complete, deploy the DACPAC, then terminate SQL Server.
# See https://stackoverflow.com/a/51589787/488695
RUN ( /opt/mssql/bin/sqlservr & ) | grep -q "Service Broker manager has started" \
    && /opt/sqlpackage/sqlpackage /a:Import /tsn:. /tdn:${DBNAME} /tu:sa /tp:$SA_PASSWORD /sf:/tmp/db/db.bacpac \
    && rm -r /tmp/db \
    && pkill sqlservr \
    && rm -r /opt/sqlpackage