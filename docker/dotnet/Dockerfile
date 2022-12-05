FROM mcr.microsoft.com/dotnet/sdk:7.0


ENV ACCEPT_EULA=Y
#https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-setup-tools?view=sql-server-ver16#docker
RUN apt-get update && apt-get install -y gnupg2 diffutils git git-lfs jq net-tools && \
    curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - &&\
    curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list | tee /etc/apt/sources.list.d/msprod.list && \
    apt-get update && apt-get install -y mssql-tools unixodbc-dev && apt-get clean all

RUN dotnet tool install -g dotnet-ef
ENV PATH="$PATH:/home/user/.dotnet/tools:/opt/mssql-tools/bin"
RUN echo "export PATH=$PATH:/home/user/.dotnet/tools:/opt/mssql-tools/bin" >> ~/.bashrc

# begin copy from https://github.com/devfile/developer-images/blob/main/base/ubi8/Dockerfile
COPY --chown=0:0 entrypoint.sh /

RUN \
    # add user and configure it
    useradd -u 10001 -G sudo,root -d /home/user --shell /bin/bash -m user && \
    # Setup $PS1 for a consistent and reasonable prompt
    echo "export PS1='\W \`git branch --show-current 2>/dev/null | sed -r -e \"s@^(.+)@\(\1\) @\"\`$ '" >> /home/user/.bashrc && \
    # Copy the global git configuration to user config as global /etc/gitconfig
    #  file may be overwritten by a mounted file at runtime
    cp /etc/gitconfig /home/user/.gitconfig && \
    # Set permissions on /etc/passwd and /home to allow arbitrary users to write
    chgrp -R 0 /home && \
    chmod -R g=u /etc/passwd /etc/group /home && \
    chmod +x /entrypoint.sh

USER 10001
ENV HOME=/home/user
WORKDIR /projects
ENTRYPOINT [ "/entrypoint.sh" ]
CMD ["tail", "-f", "/dev/null"]

# end copy from https://github.com/devfile/developer-images/blob/main/base/ubi8/Dockerfile
