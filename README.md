# Netcore-Microservices

## Development

docker-compose --env-file .env -f docker-compose.yml -f docker-compose.override.yml up -d

### Nuget packages

<ul>
    <li>all nuget packages must deployed before run</li>
    <li>in case of private feed (PAT) must be configured properly (even for dev environment)</li>
    <li>recommended private storage: Azure Artifact</li>
</ul>


#### Specifiy PAT for Azure Artifact nuget feed

Specify PAT (Personal Access Token) into .env for access private nuget feeds.


##### .env file configuration

Add .env file to root directory

```bash
NUGET_PAT=secretaccesstoken
```

## AKS

### Deployment

#### Secrets

Needs to be created imperatively (for security reasons).

For example: 

kubectl create secret generic game-catalog-db-secret --from-literal=HOST=bcpatrikduch --from-literal=USER_PASS=SolutionsArchitect


#### Deployment scripts

##### Letsencrypt issuer
```bash
kubectl apply -f.\deployment\aks\letsencrypt\
```

##### Helm extensions

###### RabbitMQ
<sub><b>Installation</b></sub>
```bash
helm repo add azure-marketplace https://marketplace.azurecr.io/helm/v1/repo
helm install rabbitmq-service  azure-marketplace/rabbitmq
```

<b><p><sub>To Access the RabbitMQ AMQP port:</sub></p></b>

```bash
 kubectl port-forward --namespace default svc/rabbitmq-service 5672:5672
```

<b><p><sub>To Access the RabbitMQ Management interface:</sub></p></b>

```bash
 kubectl port-forward --namespace default svc/rabbitmq-service 15672:15672
```

###### Ingress controllers
```bash
kubectl apply -f.\deployment\aks\helm\extensions\ingress\install.bat
```

##### Microservices deployment

#### Ingress
```bash
kubectl apply -f .\deployment\aks\services\ingress\
```

#### Web Blazor
```bash
kubectl apply -f .\deployment\aks\webapps\web-blazor\
```

##### Web API Gateway
```bash
kubectl apply -f .\deployment\aks\services\api-gateways\web-gw\
```

##### Product microservice (WebAPI)

API
```bash
kubectl apply -f .\deployment\aks\services\product\product-api\
```

DB
```bash
kubectl apply -f .\deployment\aks\services\product\product-db\
```
Required secret

```bash
kubectl create secret generic product-db-secret --from-literal PGUSERNAME=SolutionArchitect --from-literal PGDBNAME=productdb --from-literal PGPASSWORD=patrikduch
```


##### User microservice (WebAPI)
```bash
kubectl create secret generic user-api-secret --from-literal="ConnectionString=Server=user-db-service;Database=userdb;User Id=SolutionArchitect; Password=patrikduch"
```

```bash
kubectl create secret generic user-db-secret --from-literal PGUSERNAME=SolutionArchitect --from-literal PGDBNAME=userdb --from-literal PGPASSWORD=patrikduch
```

```bash
kubectl apply -f .\deployment\aks\services\user\user-db\
```


##### Identity-Auth microservice (IdentityServer)
kubectl apply -f .\deployment\aks\services\identity-auth\





##### Basket microservice (WebAPI + Redis)
kubectl apply -f .\deployment\aks\services\basket\basket-api\
kubectl apply -f .\deployment\aks\services\basket\basket-db\


###### Required secrets

```bash
kubectl create secret generic basket-db-secret --from-literal=ConnectionString=basket-db-service:6379 --from-literal=DiscountUrl=http://discount-grpc-service:80
```

##### Catalog microservice (WebAPI + MongoDb) 
kubectl apply -f .\deployment\aks\services\catalog\catalog-api\
kubectl apply -f .\deployment\aks\services\catalog\catalog-db\

###### Required secrets

```bash

kubectl create secret generic catalog-db-secret --from-literal=Host=catalog-db-service --from-literal=CollectionName=products --from-literal=DatabaseName=ProductsDb --from-literal=Port=27017 --from-literal=ServiceName=Catalog --from-literal=Username=patrikduch --from-literal=Password=bcduchpatrik07041993
```

##### Discount microservice (WebAPI + gRPC + Postgres db) 
kubectl apply -f .\deployment\aks\services\discount\discount-db\
kubectl apply -f .\deployment\aks\services\discount\discount-api\
kubectl apply -f .\deployment\aks\services\discount\discount-grpc\


##### Gamecatalog microservice (WebAPI + MongoDb) 
kubectl apply -f .\deployment\aks\services\game-catalog\game-catalog-api\
kubectl apply -f .\deployment\aks\services\game-catalog\game-catalog-db\


###### Required secrets

```bash
kubectl create secret generic game-catalog-api-secret  --from-literal=HOST=game-catalog-db-service --from-literal=COLLECTION=items --from-literal=DB_NAME=ItemsDb --from-literal=USER_NAME=patrikduch --from-literal=USER_PASS=bcpatrikduch07041993 --from-literal=DB_PORT=27017 --from-literal=SERVICE_NAME=GameCatalog --from-literal=RABBITMQ_HOST=amqp://user:UVpizt6Tzj@rabbitmq-service:5672
```

##### Inventory microservice (WebAPI + MongoDb) 
kubectl apply -f .\deployment\aks\services\inventory\inventory-api\
kubectl apply -f .\deployment\aks\services\inventory\inventory-db\

###### Required secrets

```bash
kubectl create secret generic inventory-db-secret --from-literal=Host=inventory-db-service --from-literal=CollectionName=inventories --from-literal=DatabaseName=InventoryDb --from-literal=Port=27017 --from-literal=ServiceName=Inventory --from-literal=Username=patrikduch --from-literal=Password=bcduchpatrik07041993 --from-literal=RABBITMQ_HOST=amqp://user:UVpizt6Tzj@rabbitmq-service:5672
```

##### RealTimeTransmission microservice (SignalR + Redis backplane)
kubectl apply -f .\deployment\aks\services\realtime-transmission\realtime-transmission-api\
kubectl apply -f .\deployment\aks\services\realtime-transmission\realtime-transmission-db\


##### Ordering microservice (WebAPI) 
kubectl apply -f .\deployment\aks\services\ordering\ordering-api\
kubectl apply -f .\deployment\aks\services\ordering\ordering-db\

```bash
kubectl create secret generic ordering-api-secret --from-literal="ConnectionString=Server=ordering-db-service;Database=OrderDb;User Id=sa; Password=bcduchpatrik07041993"
```

```bash
kubectl create secret generic ordering-db-secret --from-literal=SA_PASSWORD=bcduchpatrik07041993
```

##### Customer microservice (WebAPI + MSSQL database) 
kubectl apply -f .\deployment\aks\services\customer\customer-api\
kubectl apply -f .\deployment\aks\services\customer\customer-db\

```bash
kubectl create secret generic customer-api-secret --from-literal="ConnectionString=Server=customer-db-service;Database=CustomerDb;User Id=sa; Password=bcduchpatrik07041993"
```

```bash
kubectl create secret generic customer-db-secret --from-literal=SA_PASSWORD=bcduchpatrik07041993
```

##### ProjectDetail microservice (WebAPI + MSSQL database) 

kubectl apply -f .\deployment\aks\services\project-detail\project-detail-api\
kubectl apply -f .\deployment\aks\services\project-detail\project-detail-db\

```bash
kubectl create secret generic project-detail-api-secret --from-literal="ConnectionString=Server=project-detail-db-service;Database=ProjectDetailDb;User Id=sa; Password=bcduchpatrik07041993"
```

```bash
kubectl create secret generic project-detail-db-secret --from-literal=SA_PASSWORD=bcduchpatrik07041993
```



##### K8s extensions (Ingress, etc.)
kubectl apply -f .\deployment\aks\extensions\

##### Webapps
kubectl apply -f .\deployment\aks\webapps\

##### Examples
kubectl apply -f .\deployment\aks\examples\ingress-controller\without-cors\


###### Db examples

Postgres

kubectl apply -f .\deployment\aks\examples\dbs\postgres\

Postgres-Azure-Disk

kubectl apply -f .\deployment\aks\examples\dbs\postgres\postgres-azure\


kubectl apply -f .\deployment\aks\examples\dbs\redis\
kubectl apply -f .\deployment\aks\examples\dbs\mssql\

###### Required secrets

MSSQL

```bash
kubectl create secret generic mssql-db-secret --from-literal=SA_PASSWORD=bcduchpatrik07041993
```

### AKS netcoreMicroservices cluster

<img src="https://github.com/patrikduch/netcore-microservices/blob/master/azure/images/azure-eks.PNG?raw=true" />
