# Challenge 5: Use the CI/CD GitHub Action to deploy changes to APIM.

The Customer API is now deployed to Container Apps, the next step is to expose the API in APIM. To do that you need to generate an OpenAPI specification in the GitHub Action and import an API into APIM. 
After this has been done you have a complete CI/CD workflow which will enable you to deploy changes faster. 
To validate this, you will create a new operation in the Customer API and deploy the changes using your finalized CI/CD workflow.   

## Main objectives

- Continue with the GitHub Action to create a complete CI/CD workflow. 
- Modify the Customer API and deploy the change using the GitHub Action. 


## Activities

- Use dotnet commands to restore, build and generate a swagger file. Dotnet tool swashbuckle.aspnetcore.cli is configured for the project. 
- Upload the swagger file to Azure storage account to make it accessible for the Bicep deployment. 
- Use Bicep to create the Customer API in APIM, set the path to "ch5". 
- Validate that the API works through APIM. 
- Add an operation in the API that take email as an input parameter and select the customer based on the email. 
- Deploy and validate that the new operation works through APIM.  


## Definition of done

- A complete CI/CD workflow using GitHub Actions for the Customer API that gets deployed when a commit is done to the main branch.  
- A new operation that takes email as an input parameter and returns a customer. 


## Helpful links

- [Swashbuckle CLI](https://github.com/domaindrivendev/Swashbuckle.AspNetCore#swashbuckleaspnetcorecli)
- [az storage upload](https://learn.microsoft.com/en-us/cli/azure/storage/blob?view=azure-cli-latest#az-storage-blob-upload)

## Solution
- View the solution here, [Challenge 5 - Solution](solution5.md) 

## The challenges

* [Challenge 1: Setup the environment](challenge1.md)
* [Challenge 2: Get familiar with Azure API Management (APIM)](challenge2.md)
* [Challenge 3: Use Bicep for deployment to APIM](challenge3.md)
* [Challenge 4: Create a CI/CD GitHub Action and deploy to Container Apps](challenge4.md)
* [Challenge 5: Use the CI/CD GitHub Action to deploy changes to APIM](challenge5.md)
* [Challenge 6: Add a policy using Bicep](challenge6.md)
* [Challenge 7: Managing Development/Production environments.](challenge7.md)