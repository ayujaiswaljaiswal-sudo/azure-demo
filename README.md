# SupplyChain Demo (.NET 7)

Small ASP.NET Core Web API to demo CI/CD in Azure DevOps.

## Run locally

1. Install .NET 7 SDK.
2. From repository root:

```bash
cd src/SupplyChainDemo.Api
dotnet run
```

Open `https://localhost:5001/swagger` to try the endpoints.

## Run with Docker

Build and run:

```bash
docker build -t supplychain-demo:local .
docker run -p 8080:80 supplychain-demo:local
```

Then open `http://localhost:8080/swagger`.

## Azure DevOps CI/CD

1. Create a new Azure DevOps project.
2. Push this repo to the project Git repo (or GitHub and connect it).
3. Create two service connections:
   - Docker registry (Docker Hub or Azure Container Registry)
   - Azure Resource Manager (for deploying to Web App for Containers)
4. Configure pipeline variables or variable groups: `dockerRegistryServiceConnection`, `azureServiceConnection`, `dockerRegistry`, `webAppName`, `imageName`.
5. In Azure DevOps, create a pipeline using `azure-pipelines.yml`.

The YAML will build, test, build & push the Docker image, and deploy to an Azure Web App for Containers. Adjust the `UseDotNet@2` version if you want to use net6/net8 instead.

## Suggestions for demos

- Show pipeline run after commit to `main`.
- Introduce branch policies (PR validation) and required reviewers.
- Add environment approvals before deploy stage.
- Store secrets in Azure Key Vault and use variable groups.

## Next steps (optional)

- Add EF Core and a real database (SQL/SQLite/Postgres).
- Add Kubernetes manifest and Helm chart to deploy to AKS/GKE.
- Add Integration tests and pipeline gates.
# azure-demo
