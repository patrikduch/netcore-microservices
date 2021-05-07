# Netcore-Microservices

## Development

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

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
