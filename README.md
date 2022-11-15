# Azure API Management CI/CD hack with GitHub

The hackathon uses GitHub Actions to create a complete CI/CD workflow for APIs deployed in Azure API Management. Bicep is used to setup the Azure services that is being used. The following services are being used: 
* Azure API Management (consumption)
* Azure Container Apps
* Azure SQL Database (serverless)
* Log analytics
* Managed identities
* Azure Key vault
* Azure Container Registry  
* Storage account
 
  ![Azure services](docs/img/services.png)


## Target audience

This hackathon is directed towards developers that want to learn how to setup a CI/CD workflow against Azure API Management (APIM) using GitHub.    

## Prerequisites

- Basic knowledge of Azure services.
- Basic knowledge of API development.
- Azure subscription with RBAC Owner role or a resourcegroup with RBAC Owner role. If the later is used the resourcegroup naming convention must be "rg-[six letters]" e.g. "rg-majnor". 
- A Service principal with RBAC Owner role on the resourcegroup to be used.   
- VS Code installed locally with the extensions "Bicep" and "REST Client".
- Latest version of Azure CLI installed. 
- A GitHub account is needed.   

## Getting started

* This repo needs to be **forked and cloned** to to use it locally, see more [here](https://docs.github.com/en/get-started/quickstart/fork-a-repo#forking-a-repository)  

### Fork and clone the repository

Log in to GitHub with your GitHub account. Fork this repo by selecting the Fork menu in the GitHub top right corner.
![fork](docs/img/fork.png)

> **Note**<br>
> If your GitHub account is part of an organization there is a limitation that only one fork is possible in the same organization. The workaround is to clone this repo, create a new repository and then push the code from the cloned working copy similar to this:
>
>  ``` bash
>  git clone https://github.com/jonasnorlund/apim-hack-cicd
>  cd apim-hack-cicd
>  git remote set-url origin <url of your new repo>
>  git push origin master
>  ```
>

Clone the fork using git. 
```shell
git clone <your GitHub repository url>/apim-hack-cicd
cd apim-hack-cicd
```


## Structure

To make this hackathon unique for the participants each participant needs to create a combination of six letters that will be used in the  hackathon. This could be the first three letters of your firstname and lastname combined. e.g "majnor". From now on these letters will be called postfix throughout the hackathon.
The hackathon is divided into six challenges. Each challenge consist of the following structure: 
- **Main objective(s)**
    
    Description of the objective(s) in this challenge. 
    
- **Activities**

    Description/guideline of which activities are necessary to complete the challenge.    

- **Definition of done**

    Description of what is necessary to define a challenge "done".

- **Helpful links**

    Some of the challenges has links with information that can be useful to complete the challenge. 

- **Solution**

    Each challenge has a step-by-step guide and also the final solution for the current solution. 

## The challenges

* [Challenge 1: Setup the environment](docs/challenge1.md)
* [Challenge 2: Get familiar with Azure API Management (APIM)](docs/challenge2.md)
* [Challenge 3: Use Bicep for deployment to APIM](docs/challenge3.md)
* [Challenge 4: Create a CI/CD Github Action and deploy to Container Apps](docs/challenge4.md)
* [Challenge 5: Use the CI/CD Github Action to deploy changes to APIM](docs/challenge5.md)
* [Challenge 6: Add a policy using Bicep](docs/challenge6.md)
* [Challenge 7: Managing Development/Production environments.](docs/challenge7.md)
* TODO : Challenge 8: Using APIM to validate JWT tokens in a OAuth2 scenario.











