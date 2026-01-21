# BootcampCLT


## DOCKER SETUP FOR POSTGRESQL
docker run --name scp-postgres -e POSTGRES_PASSWORD=a.123456 -p 5432:5432 -d postgres

## DOCKER SETUP FOR BOOTCAMPCLT PROJECT
docker run --rm -p 5000:8080 -e ASPNETCORE_ENVIRONMENT=Development -e ConnectionStrings__ProductosDb="Host=host.docker.internal;Port=5432;Database=CatalogoCLT;Username=postgres;Password=a.123456" bootcampclt-api:1.1 
## NETWORK SETUP
docker network create bootcampclt-network

docker network connect bootcampclt-network scp-postgres
docker network connect bootcampclt-network <bootcampclt-container-id>



## ARCHIVO DEPLOYMENT.YML PARA KUBERNETES
```yaml
apiVersion: apps/v1

kind: Deployment

metadata:

  name: postgres

spec:

  replicas: 1

  selector:

    matchLabels:

      app: postgres

  template:
    metadata
      labels:
        app: postgres
    spec:
      containers:
        - name: postgres
          image: postgres:16
          ports:
            - containerPort: 5432
          env:
            - name: POSTGRES_DB
              value: "hardwareCLT"
            - name: POSTGRES_USER
              value: "postgres"
            - name: POSTGRES_PASSWORD
              value: "a.123456"
```
 