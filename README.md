SharpAngles
===========

WebSharper bindings for Angular

## Overview

Experimental WebSharper bindings for Angular JS plus sample project showing their implementation based on the examples
available on the [Angular website][1]. This makes it possible to construct single page apps entirely in F#. Angular 
modules currently implemented:

* angular: **partially**
* angular-animate: **no**
* angular-cookies: **no**
* angular-mock-tests: **no**
* angular-nocks: **no**
* angular-resource-tests: **no**
* angular-resource: **no**
* angular-route-tests: **no**
* angular-route: **yes**
* angular-sanitize-tests: **no**
* angular-sanitize: **no**
* angular-scenario: **no**
* angular-tests: **no**

## Usage

The general idea is to implement Angular in a manner that matches the regular JavaScript usuage as closely as possible.
Below is an example of the first (very simple) example found on the Angular website, translated into F#:

```F#
module Server =

    type Todo =
        { text: string
          ``done``: bool }

    [<Rpc>]
    let GetTodos () = [|
        { text = "learn angular"; ``done`` = true }
        { text = "build an angular app"; ``done`` = false }
    |]
    
[<JavaScript>]
module Client =
    
    [<AbstractClass>]
    type TodoScope =
        [<DefaultValue>] val mutable todos: Server.Todo array
        [<DefaultValue>] val mutable addTodo: (unit -> unit)
        [<DefaultValue>] val mutable remaining: (unit -> int)
        [<DefaultValue>] val mutable archive: (unit -> unit)
        [<DefaultValue>] val mutable todoText: string
        
    let Main =
        Angular
            .Module("todoApp", [||])
            .controller("TodoController", (
                            "$scope", 
                            fun (scope: TodoScope) -> 
                                scope.todos <- Server.GetTodos ()
                                scope.addTodo <-
                                    fun _ ->
                                        scope.todos <- Array.append [| { text = scope.todoText; ``done`` = false } |] scope.todos
                                        scope.todoText <- ""
                                scope.remaining <-
                                    fun _ ->
                                        scope.todos
                                        |> Array.filter (fun t -> not t.``done``)
                                        |> Array.length
                                scope.archive <-
                                    fun _ ->
                                        scope.todos <-
                                            scope.todos
                                            |> Array.filter (fun t -> not t.``done``)
            ))
```

## Licensing

Please bear in mind that [WebSharper][2] is subject to separate licensing for all non-open-source projects.

[1]: http://angularjs.com/
[2]: http://www.websharper.com/