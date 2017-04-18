// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Suave
open System
open System.Threading


[<EntryPoint>]
let main argv = 
    let cts = new CancellationTokenSource()
    let conf = { defaultConfig with cancellationToken = cts.Token}
    let listening, server = startWebServerAsync conf (Successful.OK "Hello World")

    Async.Start(server,cts.Token)
    printfn "Make Requests now"
    Console.ReadKey true |> ignore
    
    cts.Cancel()

    0