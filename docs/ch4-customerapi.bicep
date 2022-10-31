param dockerimagetag string 
param location string
param name string
param apidefinitionurl string = '' 
@secure()
param db_connectionstring string


// Variable
var appname = 'ca-customerapi'

// existing resources
resource uami 'Microsoft.ManagedIdentity/userAssignedIdentities@2021-09-30-preview' existing = {
  name: 'umi-${name}'
}

resource acr 'Microsoft.ContainerRegistry/registries@2019-12-01-preview' existing = {
  name: 'acr${name}'
}

resource cae 'Microsoft.App/managedEnvironments@2022-03-01' existing = {
  name: 'cae-${name}'
}




//apps
resource ca_customerapi 'Microsoft.App/containerApps@2022-03-01' = {
  name: appname
  location: location
  identity: {
    type: 'UserAssigned'
    userAssignedIdentities: {
      '${uami.id}': {}
    }
  }
  properties: {
    managedEnvironmentId: cae.id
    configuration: {
      activeRevisionsMode: 'single'
      ingress: {
        external: true
        targetPort: 80
        allowInsecure: true
        transport: 'auto'
      }
      registries: [
        {
          identity: uami.id
          server: acr.properties.loginServer
        }
      ]
      secrets: [
        {
          name: 'dbconnection'
          value: db_connectionstring
        }
      ]
    }
    template: {
      containers: [
        {
          image: '${acr.properties.loginServer}/customerapi:${dockerimagetag}'
          name: appname
          resources: {
            cpu: json('0.25')
            memory: '.5Gi'
          }
          env: [
            {
              name: 'ConnectionStrings__DefaultConnection'
              secretRef: 'dbconnection'
            }
          ]
          
        }
      ]
      scale: {
        minReplicas: 1
        maxReplicas: 1
      }
    }
  }
}


