namespace ellipsoid.org.SharpAngles.Samples.SecondExample

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper

module Server =
    ()
    
[<JavaScript>]
module Client =

    let Main =
        Angular
            .Module("project", [| "ngRoute" |])
            .config(("$routeProvider",
                        fun (routeProvider: Angular.Route.IRouteProvider) ->
                            routeProvider
                                .``when``("/", RouteConfig(Controller = "ListCtrl", TemplateUrl = "list.html"))
                                .``when``("/edit/:projectId", RouteConfig(Controller = "EditCtrl", TemplateUrl = "detail.html"))
                                .``when``("/new", RouteConfig(Controller = "CreateCtrl", TemplateUrl = "detail.html"))
                                .otherwise(RouteConfig(RedirectTo = "/"))
            ))
