FROM mcr.microsoft.com/mssql/server:2019-latest

WORKDIR /usr/src/app

COPY . /usr/src/app/

# set environment variables
ENV MSSQL_SA_PASSWORD=TestDatabase$
ENV ACCEPT_EULA=Y

EXPOSE 1433

RUN /opt/mssql/bin/sqlservr & sleep 40s \
    && /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P TestDatabase$ -i /usr/src/app/create-database.sql \
    && pkill sqlservr