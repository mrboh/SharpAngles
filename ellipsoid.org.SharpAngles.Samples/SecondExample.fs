namespace ellipsoid.org.SharpAngles.Samples.SecondExample

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
    
[<JavaScript>]
module Client =

    type Project () =
        member this.``$id`` = ""
        member this.site = ""
        member this.name = ""
        member this.description = ""
    
    type DataSource () =
        [<Inline "$this.$add($project)">]
        member this.Add(project) = X<Angular.IPromise<Project>>
        [<Inline "$this.$indexFor($projectId)">]
        member this.IndexFor(projectId) = X<obj>
        member this.Item
            with [<Inline "$this[$index]">] get(index) = X<Project>
        [<Inline "$this.$remove($project)">]
        member this.Remove(project) = X<Angular.IPromise<Project>>
        [<Inline "$this.$save($project)">]
        member this.Save(project) = X<Angular.IPromise<Project>>

    [<Inline "$firebase(new Firebase($url)).$asArray()">]
    let Firebase(firebase, url) = X<DataSource>
        
    [<AbstractClass>]
    type ListScope =
        [<DefaultValue>] val mutable projects: DataSource

    [<AbstractClass>]
    type CreateScope =
        [<DefaultValue>] val mutable save: unit -> unit
        [<DefaultValue>] val mutable project: Project

    [<AbstractClass>]
    type EditScope =
        [<DefaultValue>] val mutable projects: DataSource
        [<DefaultValue>] val mutable project: Project
        [<DefaultValue>] val mutable destroy: unit -> unit
        [<DefaultValue>] val mutable save: unit -> unit

    type RouteParams =
        { projectId: int }

    let Main =
        Angular
            .Module("project", [| "ngRoute"; "firebase" |])
            .value("fbURL", "https://angularjs-projects.firebaseio.com/")
            .factory("Projects", (
                        "$firebase", "fbURL",
                        fun (firebase, fbUrl) ->    // Note that function arguments have to be tupled for Angular to interact with them properly
                            Firebase (firebase, fbUrl)
            ))
            .config(("$routeProvider",
                        fun (routeProvider: Angular.Route.IRouteProvider) ->
                            routeProvider
                                .``when``("/", RouteConfig(Controller = "ListCtrl", TemplateUrl = "list.html"))
                                .``when``("/edit/:projectId", RouteConfig(Controller = "EditCtrl", TemplateUrl = "detail.html"))
                                .``when``("/new", RouteConfig(Controller = "CreateCtrl", TemplateUrl = "detail.html"))
                                .otherwise(RouteConfig(RedirectTo = "/"))
            ))
            .controller("ListCtrl", (
                            "$scope", "Projects", 
                            fun (scope: ListScope, projects) ->
                                scope.projects <- projects
            ))
            .controller("CreateCtrl", (
                            "$scope", "$location", "Projects", 
                            fun (scope: CreateScope, location: Angular.ILocationService, projects: DataSource) ->
                                scope.save <-
                                    fun _ ->
                                        projects.Add(scope.project)
                                                .``then``(fun data -> location.path("/")) |> ignore
            ))
            .controller("EditCtrl", (
                            "$scope", "$location", "$routeParams", "Projects", 
                            fun (scope: EditScope, location: Angular.ILocationService, routeParams: RouteParams, projects: DataSource) ->
                                let projectId = routeParams.projectId
                                let projectIndex = projects.IndexFor(projectId)

                                scope.projects <- projects
                                scope.project <- scope.projects.Item(projectIndex)
                                scope.destroy <-
                                    fun _ ->
                                        scope.projects.Remove(scope.project)
                                                  .``then``(fun data -> location.path("/")) |> ignore
                                scope.save <-
                                    fun _ ->
                                        scope.projects.Save(scope.project)
                                                  .``then``(fun data -> location.path("/")) |> ignore
            ))
