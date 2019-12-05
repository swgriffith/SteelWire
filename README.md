# Azure DevOps Agent Container

Better README to come later, but in short this repo contains the Dockerfile and Helm chart that can be used to run an Azure DevOps agent in a container, along with a helm chart for deploying to Kubernetes.

The helm chart was based off of the following https://github.com/Azure/helm-vsts-agent

You can build the image with the following:
```bash
docker build -t stevegriffith/vsts-buildagent .  
```

To run the image locally:
```bash
docker run -d -e AZP_URL=<URL to Azure DevOps Instance> \
-e AZP_TOKEN=<Azure DevOps PAT> \
-e AZP_POOL=<Name of Agent Pool> \
stevegriffith/vsts-buildagent:latest
```

Install to Kubernetes via Helm
```bash
# Encode PAT Token
export VSTS_TOKEN=$(echo -n '<PAT TOKEN>' | base64)

# For Helm 2
helm install --name devops --namespace <Optional Namespace> --set vstsToken=${VSTS_TOKEN} --set vstsAccount=<URL to DevOps Instance> --set vstsPool=<Agent Pool Name> -f values.yaml --name vsts-agent .

# For Helm 3
helm install --namespace <Optional Namespace> --set vstsToken=${VSTS_TOKEN} --set vstsAccount=<URL to DevOps Instance> --set vstsPool=<Agent Pool Name> -f values.yaml vsts-agent .