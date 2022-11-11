# Challenge 2: Get familiar with Get familiar with Azure API Management (APIM)

This challenge will help you to get more familiar with Azure API management (APIM). You will import a publicly available swagger definition manually in the Azure portal. Add a policy in APIM that adds a custom http header to your request. After you have done this, you will verify that this works using the VS Code plugin "REST Client".    

## Main objectives

- Import the Conference API through the Azure portal. 
- Add a request header using an APIM policy. 

## Activities

- Import the Conference API ( https://conferenceapi.azurewebsites.net ) through the Azure portal. Set the API URL suffix to "ch2".
- Add a request header in the outbound section of the API, make sure this is applied to all operations. The request header name should be "myheader" and the value "apimhack". 
- Test the imported API using the VS Code plugin "REST Client".   


## Definition of done

- Conference API imported and a request header with the name "myheader" and value "apimhack" has been added to the API. The request header should be present in the response back from APIM. 
- Validated using the VS Code plugin "REST Client" or similar tool. 

## Helpful links

- [Tutorial: Import and publish your first API](https://learn.microsoft.com/en-us/azure/api-management/import-and-publish)
- [Set header policy in APIM](https://learn.microsoft.com/en-us/azure/api-management/api-management-transformation-policies#SetHTTPheader) 
- [REST Client in VS Code](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)
- 
## Solution
- View the solution here, [Challenge 2 - Solution](solution2.md) 

## The challenges

* [Challenge 1: Setup the environment](challenge1.md)
* [Challenge 2: Get familiar with Azure API Management (APIM)](challenge2.md)
* [Challenge 3: Use Bicep for deployment to APIM](challenge3.md)
* [Challenge 4: Create a CI/CD GitHub Action and deploy to Container Apps](challenge4.md)
* [Challenge 5: Use the CI/CD GitHub Action to deploy changes to APIM](challenge5.md)
* [Challenge 6: Add a policy using Bicep](challenge6.md)
* [Challenge 7: Managing Development/Production environments.](challenge7.md)