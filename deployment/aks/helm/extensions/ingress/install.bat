kubectl create namespace ingress-basic

helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx

helm install nginx-ingress ingress-nginx/ingress-nginx ^
    --namespace ingress-basic ^
    --set controller.replicaCount=2 ^
    --set controller.nodeSelector."beta\.kubernetes\.io/os"=linux ^
    --set defaultBackend.nodeSelector."beta\.kubernetes\.io/os"=linux ^
    --set controller.admissionWebhooks.patch.nodeSelector."beta\.kubernetes\.io/os"=linux