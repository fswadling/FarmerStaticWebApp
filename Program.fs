open Farmer
open Farmer.Builders

let pelt8StaticWebApp = staticWebApp {
    name "staticwebapp"
    repository "web app github goes here"
    app_location "frontend"
    api_location "api"
}

let deployment = arm {
    location Location.WestEurope
    add_resource pelt8StaticWebApp
}

deployment
    |> Deploy.execute "static-web-app-resources" [ pelt8StaticWebApp.RepositoryParameter, "github access token goes here" ]
    |> ignore