# TODO .NET Application

This is developer experience demo app using dotnet 7.0.

To edit and test locally using docker-compose

```
docker-compose up -d
```

This will mount current folder in /projects/todo-dotnet

Run migration script for first time to create database and tables.

```
#run this to bash into container
docker exec -it todo-dotnet_dotnet_1 bash

#run this inside container to run migration script
dotnet tool install --global dotnet-ef
dotnet ef database update

#run this inside container
cd /projects/todo-dotnet
dotnet run

#Hint Ctrl + C to stop
```

Access the application via [http://localhost:8080](http://localhost:8080)

Access the swagger ui via [Swagger UI](http://localhost:8080/swagger/index.html)

Clean up after testing

```
docker-compose down
```
