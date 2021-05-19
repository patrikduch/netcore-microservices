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


kubectl apply -f .\deployment\aks\services\basket\basket-api\
kubectl apply -f .\deployment\aks\services\catalog\catalog-api\
kubectl apply -f .\deployment\aks\services\discount\discount-api\
kubectl apply -f .\deployment\aks\services\discount\discount-grpc\
kubectl apply -f .\deployment\aks\services\game-catalog\game-catalog-api\
kubectl apply -f .\deployment\aks\services\game-catalog\game-catalog-db\

##### Examples
kubectl apply -f .\deployment\aks\examples\postgres\
kubectl apply -f .\deployment\aks\examples\redis\


### AKS netcoreMicroservices cluster

<img src="https://github.com/patrikduch/netcore-microservices/blob/master/azure/images/azure-eks.PNG?raw=true" />
