# BootcampCLT

PARA LEVANTAR EL PROYECTO

el proyecto se encuentra en 
```bash
BootcampCLT/
```
Se encuentra en el lugar la base de datos, la diferencia con el proyecto es el **nombre de la DB** ahora **CatalogoCLT**

```bash
BootcampCLT\scriptDB.sql
```




# ANOTACIONES PERSONALES (para levantar postgres en docker DB: CatalogoCLT)

## DOCKER SETUP FOR POSTGRESQL
docker run --name scp-postgres -e POSTGRES_PASSWORD=a.123456 -p 5432:5432 -d postgres

## DOCKER SETUP FOR BOOTCAMPCLT PROJECT
docker run --rm -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development -e ConnectionStrings__ProductosDb="Host=host.docker.internal;Port=5432;Database=CatalogoCLT;Username=postgres;Password=a.123456" bootcampclt-api:1.1 
## NETWORK SETUP
docker network create bootcampclt-network

docker network connect bootcampclt-network scp-postgres
docker network connect bootcampclt-network <bootcampclt-container-id>


