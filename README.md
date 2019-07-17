# DenverFP-FRP
This project was the starting point Alan and I used in [our talk](https://www.meetup.com/denverfp/events/263198218/?comment_table_id=263045508&comment_table_name=reply) at the DenverFP meetup.
It is a functional reactive web application template using F#, WebSharper, and .NET Core. This project is based on the `websharper-web` dotnet template for F#.

## Getting Started
All you have to do is clone this repo and run `dotnet restore`, and then start it up with `dotnet run`.

## Purpose
Normally, you would just start a new project with `dotnet new websharper-web -lang f#`, but as of the time of this writing on July 16, 2019, is [currently broken](https://fpish.net/topic/Some/0/86609) and is an [open Websharper issue](https://github.com/dotnet-websharper/core/issues/1044).\*

*\* If you're on Windows, it might actually be working, in which case you don't need this repo.*

This project uses a workaround as partially described [here](https://github.com/dotnet-websharper/core/issues/1044#issuecomment-478963571). More complete instructions on the exact steps that we took are coming.

## Code Overview
* `Site.fs`
  * Contains server-side definitions for the HTTP page routes, as well as the server-side computed parts of all the pages. It has some WebSharper [HTML templating](https://developers.websharper.com/docs/v3.x/fs/ui.next-templating3x) to build most of each page.\* 
* `Client.fs`
  * Contains all of the client-side code, which gets transpiled to JavaScript (notice the `JavaScript` attribute on the module), and which gets inserted [into the home page](https://github.com/jwosty/DenverFP-FRP/blob/master/Site.fs#L43). This client-side code uses reactive variables to compute [an output text node](https://github.com/jwosty/DenverFP-FRP/blob/master/Client.fs#L20) based on an [input text field](https://github.com/jwosty/DenverFP-FRP/blob/master/Client.fs#L12) and [a server computation](https://github.com/jwosty/DenverFP-FRP/blob/master/Remoting.fs#L11)
* Remoting.fs
  * Contains a remoting function that executes on the server side but can be called from the client side (internally using AJAX remoting mechanisms). It's only performing a string reversal for demonstration purposes; you can of course perform much more complicated server-side operations here.

Note: The one tweak in functionality we made is to remove the `submit` button next to the text box from [the original template](https://github.com/dotnet-websharper/templates/blob/0baf2861df31658d7aa087273031ba200a2e655a/FSharp/ClientServer/Client.fs#L22), in order to demonstrate how reactive values continuously update. It's obviously not a good idea to use it how this project is using it, since every user keystroke in the input box causes a web request to the server. In real code, you'd want to use a submit button or to throttle the requests or something.

*\* This link is old, but unfourtunately you can't link to particular headers in the 4.x documentation. Templates didn't change in 4.x AFAIK, though. If you want to find the 4.x documentation, first go [here](https://developers.websharper.com/docs/v4.x/fs), then in the left sidebar, navigate to Basics>Reactive&nbsp;HTML>HTML&nbsp;Templates.*
