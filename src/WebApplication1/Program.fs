open Microsoft.AspNetCore.Builder
open Giraffe

let webApp = choose [
    route "/" >=> text "Hello world"
]

let app = WebApplication.Create()
app.UseGiraffe webApp

app.Run()
