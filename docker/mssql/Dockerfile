#https://mcr.microsoft.com/en-us/product/mssql/rhel/server/about
FROM mcr.microsoft.com/mssql/rhel/server:2019-CU18-rhel-8.5

USER root

RUN if [ ! -d /var/opt/mssql ]; then mkdir -p /var/opt/mssql; fi &&  chgrp -R 0 /var/opt/mssql && chmod g+rwX /var/opt/mssql && chmod -R 777 /var/opt/mssql;

USER mssql
