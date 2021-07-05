open Farmer
open Farmer.Builders

let staticWebApp = staticWebApp {
    name "staticwebapp"
    repository "web app github goes here"
    app_location "frontend"
    api_location "api"
}

let deployment = arm {
    location Location.WestEurope
    add_resource staticWebApp
}

deployment
    |> Deploy.execute "static-web-app-resources" [ staticWebApp.RepositoryParameter, "github access token goes here" ]
    |> ignore