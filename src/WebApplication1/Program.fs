open Microsoft.AspNetCore.Builder
open Giraffe

let webApp = choose [
    route "/" >=> choose [
        POST >=> json "Hello world"
        GET >=> json "Hello world" 
    ]
]

let builder = WebApplication.CreateBuilder()
builder.Services.AddGiraffe() |> ignore

let app = builder.Build()
app.UseGiraffe webApp

app.Run()

