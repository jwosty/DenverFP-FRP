namespace SampleApp

open WebSharper
open System

module Server =
    let reverseString (s: string) =
        new string(Array.rev(s.ToCharArray()))

    [<Rpc>]
    let DoSomething input = async {
        return reverseString input
    }
