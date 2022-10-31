// az deployment group create -g rg-[YOUR POSTFIX] -f docs/ch3.bicep 


param name string
param location string = resourceGroup().location

resource apim 'Microsoft.ApiManagement/service@2021-08-01' existing = {
  name: 'apim-${name}'
}


resource swapi 'Microsoft.ApiManagement/service/apis@2021-08-01' = {
  parent: apim
  name: 'swapi'
  properties:{
    format: 'openapi+json-link'
    value: 'https://stg${name}hack.blob.core.windows.net/swapi/swapi-swagger.json'
    displayName: 'swapi'
    path: 'ch3'
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



// Below is an example of using a product with the swapi

// resource subscription 'Microsoft.ApiManagement/service/subscriptions@2021-12-01-preview' = {
//   name: 'swapi-sub'
//   parent: apim
//   properties: {
//     scope: '/products/swapi-product'
//     displayName: 'swapi-sub'
//     allowTracing: true
//   }
//   dependsOn: [
//     swapi
//     swapi_product
//   ]
// }

// resource swapi_product 'Microsoft.ApiManagement/service/products@2021-12-01-preview' = {
//   name: 'swapi-product'
//   parent: apim
//   properties: {
//     displayName: 'swapi-product'
//     subscriptionRequired: true
//     description: 'Product for consuming Starwars API.'
//   }
// }

// resource swapi_product_api 'Microsoft.ApiManagement/service/products/apis@2021-12-01-preview' = {
//   name: swapi.name
//   parent: swapi_product
// } 
