# Netcore-Microservices

## Development

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

## AKS

### Deployment

kubectl apply -f .\deployment\aks\services\basket\basket-api\

kubectl apply -f .\deployment\aks\services\catalog-api\
kubectl apply -f .\deployment\aks\services\discount-api\
kubectl apply -f .\deployment\aks\services\discount\discount-api\
kubectl apply -f .\deployment\aks\services\discount\discount-grpc\
kubectl apply -f .\deployment\aks\services\discount\discount-db\

### Examples

kubectl apply -f .\deployment\aks\examples\postgres\
kubectl apply -f .\deployment\aks\examples\redis\


![Alt text](azure/images/azure-eks.png?raw=true "Azure EKS")