# Comandos para empezar con seq

kubectl apply -f .\namespaces.yaml
kubectl apply -f .\pvc-seq.yaml
kubectl apply -f .\deployment-seq.yaml
kubectl apply -f .\service-seq.yaml


kubectl -n infra port-forward svc/seq 5341:80
 