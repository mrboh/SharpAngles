namespace ellipsoid.org.SharpAngles.Samples.FirstExample

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper

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
    open Server
    
    [<AbstractClass>]
    type TodoScope =
        [<DefaultValue>] val mutable todos: Server.Todo array
        [<DefaultValue>] val mutable addTodo: unit -> unit
        [<DefaultValue>] val mutable remaining: unit -> int
        [<DefaultValue>] val mutable archive: unit -> unit
        [<DefaultValue>] val mutable todoText: string
        
    let Main =
        Angular
            .Module("todoApp", [||])
            .Controller("TodoController", (
                            "$scope", 
                            fun (scope: TodoScope) -> 
                                scope.todos <- Server.GetTodos ()
                                scope.addTodo <-
                                    fun _ ->
                                        scope.todos.ToEcma().Push({ text = scope.todoText; ``done`` = false }) |> ignore
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