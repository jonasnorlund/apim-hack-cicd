# Challenge 4: Create a CI/CD Github Action and deploy to Container Apps.

Until now you have worked with publicly available API's, now its time to work with the API that is located in this repo under api/CustomerAPI. It's a simple .net Core 6.0 API that has been forked and modified from https://github.com/Vivekkosare/CustomerAPI (kudos [@VKosare](https://twitter.com/VKosare)). 
In this challenge you will use a GitHub Action to first build and push the code to an Azure Container Registry. Once that is done you will deploy the container image to Azure Container Apps using Bicep.    

## Main objectives

- Create a GitHub Action workflow and use Azure Container Registry to build and create a docker image. 
- Deploy the Customer API to Container Apps using a GitHub Action and Bicep.   


## Activities

- Create a GitHub Action workflow and trigger the workflow when code changes inside the folder api/CustomerAPI. All the activities below should be done in the GitHub Action workflow.  
- Use Azure CLI inside the GitHub Action workflow to build and create a docker image in Azure Container Registry. Use the system environment variable ${{ github.run_number }} to set the docker image tag and pass it into the Bicep file that deploys the Container App. 
- Deploy a Container App and use the docker image that was previously built in Azure Container Registry using Bicep. 
- Use the secret "dbconnection" in Azure Key Vault as a Secret in Container Apps to connect to the Azure SQL database.  
- Validate that the API works in Container Apps. 


## Definition of done

- The Customer API is deployed using GitHub Actions workflow and Bicep to Container Apps.
- Validate that the Customer API is working from VS Code.  


## Helpful links

- [Using workflows in GitHub](https://docs.github.com/en/actions/using-workflows/about-workflows)
- [GitHub environment variables](https://docs.github.com/en/actions/learn-github-actions/environment-variables)
- [az acr build reference](https://learn.microsoft.com/en-us/cli/azure/acr?view=azure-cli-latest#az-acr-build)
- [Use secrets in Bicep](https://learn.microsoft.com/en-us/azure/azure-resource-manager/bicep/key-vault-parameter?tabs=azure-cli#use-getsecret-function)
- [Deploy Container Apps](https://github.com/microsoft/azure-container-apps/blob/main/docs/templates/bicep/main.bicep)

## Solution
- View the solution here, [Challenge 4 - Solution](solution4.md) 

## The challenges

* [Challenge 1: Setup the environment](challenge1.md)
* [Challenge 2: Get familiar with Azure API Management (APIM)](challenge2.md)
* [Challenge 3: Use Bicep for deployment to APIM](challenge3.md)
* [Challenge 4: Create a CI/CD GitHub Action and deploy to Container Apps](challenge4.md)
* [Challenge 5: Use the CI/CD GitHub Action to deploy changes to APIM](challenge5.md)
* [Challenge 6: Add a policy using Bicep](challenge6.md)
* [Challenge 7: Managing Development/Production environments.](challenge7.md)