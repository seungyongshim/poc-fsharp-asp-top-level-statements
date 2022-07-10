open Microsoft.AspNetCore.Builder
open Giraffe


let sendEmailNotification emailSettings customer message =
    ()

let sendEmailFromHotmailAccount =
    // Here I only apply the `emailSettings` parameter:
    sendEmailNotification hotmailSettings


let sendSmsNotification smsService apiKey customer message =
    ()

let sendSmsWithTwillio =
    // Here I only apply the `smsService` and `apiKey` parameters:
    sendSmsNotification twilioService twilioApiKey


let completeOrder notify customer shoppingBasket =
    notify customer "Your order has been received."
    ()

let completeOrderAndNotify =
    emailSettings
    |> sendEmailNotification
    |> completeOrder


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


