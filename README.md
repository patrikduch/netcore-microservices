# Netcore-Microservices

## Development

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

### Nuget packages

<ul>
    <li>all nuget packages must deployed before run</li>
    <li>in case of private feed (PAT) must be configured properly (even for dev environment)</li>
    <li>recommended private storage: Azure Artifact</li>
</ul>


#### Specifiy PAT for Azure Artifact nuget feed

Specify PAT (Personal Access Token) into .env for access private nuget feed.


```bash
NUGET_PAT="secretaccesstoken"
```

## AKS

### Deployment

#### Secrets

Needs to be created imperatively (for security reasons).

For example: 

kubectl create secret generic game-catalog-db-secret --from-literal=HOST=bcpatrikduch --from-literal=USER_PASS=SolutionsArchitect


#### Deployment scripts

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
.\deployment\aks\helm\extensions\ingress\install.bat

##### Microservices deployment

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

##### Dicount microservice (WebAPI + gRPC + Postgres db) 
kubectl apply -f .\deployment\aks\services\discount\discount-db\
kubectl apply -f .\deployment\aks\services\discount\discount-api\
kubectl apply -f .\deployment\aks\services\discount\discount-grpc\


##### Gamecatalog microservice (WebAPI + MongoDb) 
kubectl apply -f .\deployment\aks\services\game-catalog\game-catalog-api\
kubectl apply -f .\deployment\aks\services\game-catalog\game-catalog-db\


###### Required secrets

```bash
kubectl create secret generic game-catalog-api-secret  --from-literal=HOST=game-catalog-db-service --from-literal=COLLECTION=items --from-literal=DB_NAME=ItemsDb --from-literal=USER_NAME=patrikduch --from-literal=USER_PASS=bcpatrikduch07041993 --from-literal=DB_PORT=27017 --from-literal=SERVICE_NAME=GameCatalog --from-literal=RABBITMQ_HOST=amqp://guest:guest@my-release-rabbitmq:5672
```

##### Inventory microservice (WebAPI + MongoDb) 
kubectl apply -f .\deployment\aks\services\inventory\inventory-api\
kubectl apply -f .\deployment\aks\services\inventory\inventory-db\

###### Required secrets

```bash
kubectl create secret generic inventory-db-secret --from-literal=Host=inventory-db-service --from-literal=CollectionName=inventories --from-literal=DatabaseName=InventoryDb --from-literal=Port=27017 --from-literal=ServiceName=Inventory --from-literal=Username=patrikduch --from-literal=Password=bcduchpatrik07041993
--from-literal=RABBITMQ_HOST=amqp://guest:guest@my-release-rabbitmq:5672
```

##### RealTimeTransmission microservice (SignalR + Redis backplane)
kubectl apply -f .\deployment\aks\services\realtime-transmission\realtime-transmission-api\
kubectl apply -f .\deployment\aks\services\realtime-transmission\realtime-transmission-db\


##### K8s extensions (Ingress, etc.)
kubectl apply -f .\deployment\aks\extensions\

##### Webapps
kubectl apply -f .\deployment\aks\webapps\

##### Examples
kubectl apply -f .\deployment\aks\examples\ingress-controller\without-cors\
kubectl apply -f .\deployment\aks\examples\postgres\
kubectl apply -f .\deployment\aks\examples\redis\


### AKS netcoreMicroservices cluster

<img src="https://github.com/patrikduch/netcore-microservices/blob/master/azure/images/azure-eks.PNG?raw=true" />
