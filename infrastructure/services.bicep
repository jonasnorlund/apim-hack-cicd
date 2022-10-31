param name string
param location string
@secure()
param sqlpwd string


// Variables 
var contributorRoleDefId = 'b24988ac-6180-42a0-ab88-20f7382dd24c'
var keyVaultSecretsRoleDefId = '4633458b-17de-408a-b874-0445c86b69e6'
var dbconnstr='Server=tcp:sqlsrv-hack-${name}.database.windows.net,1433;Initial Catalog=customerDb;Persist Security Info=False;User ID=sqlhackadmin;Password=${sqlpwd};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'

// User Assigned Managed Identity
resource umi 'Microsoft.ManagedIdentity/userAssignedIdentities@2021-09-30-preview' = {
  name: 'umi-${name}'
  location: location
}

// User Assigned Managed Identity RBAC for resourcegroup
resource rbac 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
  scope: resourceGroup()
  name: guid(umi.id, contributorRoleDefId)
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', contributorRoleDefId)
    principalId: umi.properties.principalId
    principalType: 'ServicePrincipal'
  }
}

// Azure Container registry
resource acr 'Microsoft.ContainerRegistry/registries@2019-12-01-preview' = {
  name:'acr${name}'
  location:location
  sku:{
    name:'Standard'
  }
}

// Log analytics workspace
resource la 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: 'la-${name}'
  location: location
  properties: {
    retentionInDays: 30
    sku:{
      name: 'PerGB2018'
    }
  } 
}

// Container Apps Environment
resource cae 'Microsoft.App/managedEnvironments@2022-03-01' = {
  name: 'cae-${name}'
  location: location
  properties: {
    appLogsConfiguration: {
      destination: 'log-analytics'
      logAnalyticsConfiguration: {
        customerId: la.properties.customerId
        sharedKey: listKeys(la.id, '2020-03-01-preview').primarySharedKey
      }
    }
  }
}

// Azure keyvault
resource kv 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: 'kv-${name}'
  location: location 
  properties: {
    enabledForTemplateDeployment: true
    enableRbacAuthorization: true
    sku: {
      family: 'A'
      name: 'standard'
    }
    tenantId: subscription().tenantId
  }
}

// User Assigned Managed Identity RBAC for Azure keyvault
resource kvumirbac 'Microsoft.Authorization/roleAssignments@2020-04-01-preview' = {
  scope: kv
  name: guid(umi.id, keyVaultSecretsRoleDefId, kv.id)
  properties: {
    roleDefinitionId: subscriptionResourceId('Microsoft.Authorization/roleDefinitions', keyVaultSecretsRoleDefId)
    principalId: umi.properties.principalId
    principalType: 'ServicePrincipal'
  }
}

resource secret 'Microsoft.KeyVault/vaults/secrets@2021-11-01-preview' = {
  parent: kv
  name: 'dbconnection'
  properties: {
    value: dbconnstr
  }
}


// API Management
resource apim 'Microsoft.ApiManagement/service@2021-12-01-preview' = {
  name: 'apim-${name}'
  location: location
  sku: {
    capacity: 0
    name: 'Consumption'
  }
  properties: {
    publisherEmail: '${name}@mail.com'
    publisherName: name
  }
}


// Azure SQL server
resource sqlsrv 'Microsoft.Sql/servers@2021-08-01-preview' = {
  name: 'sqlsrv-hack-${name}'
  location: location
  properties: {
    administratorLogin: 'sqlhackadmin'
    administratorLoginPassword: sqlpwd
    publicNetworkAccess: 'Enabled'
  }

}

// Azure SQL Server Database
resource sqldb 'Microsoft.Sql/servers/databases@2021-08-01-preview' = {
  parent: sqlsrv
  name: 'customerDb'
  location: location
  sku: {
    name: 'GP_S_Gen5_1'
    tier: 'GeneralPurpose'
    capacity: 1
    family: 'Gen5'
  }
  properties: {
    minCapacity:1
    
  }
}

// Allow Azure Services
resource SQLAllowAllWindowsAzureIps 'Microsoft.Sql/servers/firewallRules@2020-11-01-preview' = {
  name: 'AllowAllWindowsAzureIps'
  parent: sqlsrv
  properties: {
    startIpAddress: '0.0.0.0'
    endIpAddress: '0.0.0.0'
  }
}

// Storage account
resource stg 'Microsoft.Storage/storageAccounts@2022-05-01' = {
  name: 'stg${name}hack'
  location: location
  kind: 'Storage'
  sku: {
    name: 'Standard_LRS'
  }
}

// Storage account Blobservice
resource blobservice 'Microsoft.Storage/storageAccounts/blobServices@2022-05-01' = {
  name: 'default'
  parent: stg
}

// Storage account blob container
resource container 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  name: 'apidefinitions'
  parent: blobservice
}

// Storage account blob container
resource container2 'Microsoft.Storage/storageAccounts/blobServices/containers@2022-05-01' = {
  name: 'swapi'
  parent: blobservice
  properties: {
    publicAccess: 'Blob'
  }
}


