# Challenge 6: Add a policy using Bicep.

Policies in APIM are small code snippets that can be applied on different levels (Global, Product, API, Operation) either on the inbound side or the outbound side. Policies can then change the behaviour of the API. IN this challenge you will use Bicep to apply a policy that sets a custom request header. 


> **Note**
> 
> Bicep, compared to Terraform, doesn't have a separate state compared to what is already deployed in Azure. During deployment Bicep compares the current state in Azure with the defined state in the Bicep configuration. The result of this is that only changes are applied. However, when it comes to Policies in APIM the XML-style code snippets are formatted after deployment which results that policies are always redeployed, even if no changes are done. This is a known issue which the product team is aware of.  
>


## Main objectives

- Deploy a policy that uses the policy fragment on API level that was created earlier. 
- Deploy a new policy on operation level.


## Activities

- Configure customerapi.bicep to use the policy fragment that was created in Challenge 3, make sure the policy is applied on API level in the inbound section for the Customer API. 
- Create a new policy that sets a custom request header "myheader" and value "apimhack" in the outbound section of the operation "/api/customers - GET" for the Customer API.       
- Validate that the two new applied policies works.  


## Definition of done

- Applied two policies using bicep deployment for the Customer API.   
- One policy is configured on API level and the other on operation level. 

## Helpful links

- [Microsoft.ApiManagement service/apis/operations reference](https://learn.microsoft.com/en-us/azure/templates/microsoft.apimanagement/service/apis/operations?pivots=deployment-language-bicep)


## Solution
- View the solution here, [Challenge 6 - Solution](solution6.md) 

## The challenges

* [Challenge 1: Setup the environment](challenge1.md)
* [Challenge 2: Get familiar with Azure API Management (APIM)](challenge2.md)
* [Challenge 3: Use Bicep for deployment to APIM](challenge3.md)
* [Challenge 4: Create a CI/CD GitHub Action and deploy to Container Apps](challenge4.md)
* [Challenge 5: Use the CI/CD GitHub Action to deploy changes to APIM](challenge5.md)
* [Challenge 6: Add a policy using Bicep](challenge6.md)
* [Challenge 7: Managing Development/Production environments.](challenge7.md)