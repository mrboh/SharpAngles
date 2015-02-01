namespace ellipsoid.org.SharpAngles.Samples.SecondExample

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.JavaScript
    
[<JavaScript>]
module Client =

    type Project () =
        member this.``$id`` = ""
        member this.site = ""
        member this.name = ""
        member this.description = ""
    
    type DataSource () =
        [<Inline "$this.$add($project)">]
        member this.Add(project) = X<Promise<Project>>
        [<Inline "$this.$indexFor($projectId)">]
        member this.IndexFor(projectId) = X<obj>
        member this.Item
            with [<Inline "$this[$index]">] get(index) = X<Project>
        [<Inline "$this.$remove($project)">]
        member this.Remove(project) = X<Promise<Project>>
        [<Inline "$this.$save($project)">]
        member this.Save(project) = X<Promise<Project>>

    [<Inline "$firebase(new Firebase($url)).$asArray()">]
    let Firebase(firebase, url) = X<DataSource>
        
    [<AbstractClass>]
    type ListScope =
        inherit Scope
        [<DefaultValue>] val mutable projects: DataSource

    [<AbstractClass>]
    type CreateScope =
        inherit Scope
        [<DefaultValue>] val mutable save: unit -> unit
        [<DefaultValue>] val mutable project: Project

    [<AbstractClass>]
    type EditScope =
        inherit Scope
        [<DefaultValue>] val mutable projects: DataSource
        [<DefaultValue>] val mutable project: Project
        [<DefaultValue>] val mutable destroy: unit -> unit
        [<DefaultValue>] val mutable save: unit -> unit

    type RouteParams =
        { projectId: int }

    let Main =
        Angular
            .Module("project", [| "ngRoute"; "firebase" |])
            .Value("fbURL", "https://angularjs-projects.firebaseio.com/")
            .Factory("Projects", (
                        "$firebase", "fbURL",
                        fun (firebase, fbUrl) ->    // Note that function arguments have to be tupled for Angular to interact with them properly
                            Firebase (firebase, fbUrl)
            ))
            .Config(("$routeProvider",
                        fun (routeProvider: Route.RouteProvider) ->
                            routeProvider
                                .When("/", Route.RouteConfig(Controller = "ListCtrl", TemplateUrl = "list.html"))
                                .When("/edit/:projectId", Route.RouteConfig(Controller = "EditCtrl", TemplateUrl = "detail.html"))
                                .When("/new", Route.RouteConfig(Controller = "CreateCtrl", TemplateUrl = "detail.html"))
                                .Otherwise(Route.RouteConfig(RedirectTo = "/"))
            ))
            .Controller("ListCtrl", (
                            "$scope", "Projects", 
                            fun (scope: ListScope, projects) ->
                                scope.projects <- projects
            ))
            .Controller("CreateCtrl", (
                            "$scope", "$location", "Projects", 
                            fun (scope: CreateScope, location: LocationService, projects: DataSource) ->
                                scope.save <-
                                    fun _ ->
                                        projects.Add(scope.project)
                                                .Then(fun _ -> location.Path("/")) |> ignore
            ))
            .Controller("EditCtrl", (
                            "$scope", "$location", "$routeParams", "Projects", 
                            fun (scope: EditScope, location: LocationService, routeParams: RouteParams, projects: DataSource) ->
                                let projectId = routeParams.projectId
                                let projectIndex = projects.IndexFor(projectId)

                                scope.projects <- projects
                                scope.project <- scope.projects.Item(projectIndex)
                                scope.destroy <-
                                    fun _ ->
                                        scope.projects.Remove(scope.project)
                                                      .Then(fun data -> location.Path("/")) |> ignore
                                scope.save <-
                                    fun _ ->
                                        scope.projects.Save(scope.project)
                                                      .Then(fun data -> location.Path("/")) |> ignore
            ))
