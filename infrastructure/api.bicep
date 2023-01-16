resource apim 'Microsoft.ApiManagement/service@2021-08-01' existing = {
  name: 'apim-hapiops'
}

resource swapi  'Microsoft.ApiManagement/service/apis@2022-04-01-preview' = {
  name: 'swapi'
  parent: apim
  properties: {
    displayName: 'Starwars API'
    format: 'swagger-link-json'
    path: 'ch3'
    value: 'https://stghapiopshack.blob.core.windows.net/swapi/swapi-swagger.json'
    subscriptionRequired: true
    protocols:[
      'https'
    ]
    apiType:'http'
  }
}

resource subscription 'Microsoft.ApiManagement/service/subscriptions@2021-12-01-preview' = {
  name: 'swapi-sub'
  parent: apim
  properties: {
    scope: '/apis/swapi'
    displayName: 'swapi-sub'
    allowTracing: true
  }
  dependsOn: [
    swapi
  ]
}
