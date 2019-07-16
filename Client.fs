namespace SampleApp

open WebSharper
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html

[<JavaScript>]
module Client =
    let Main () =
        let rvInput = Var.Create ""
        let vReversed =
            rvInput.View
            |> View.MapAsync (fun str -> Server.DoSomething str)
        div [] [
            Doc.Input [] rvInput
            hr [] []
            h4 [attr.``class`` "text-muted"] [text "The server responded:"]
            div [attr.``class`` "jumbotron"] [h1 [] [textView vReversed]]
        ]