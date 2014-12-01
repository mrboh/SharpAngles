namespace ellipsoid.org.SharpAngles.Samples.ThirdExample

open ellipsoid.org.SharpAngles
open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.JQuery
    
[<JavaScript>]
module Client =

    type Pane =
        { mutable selected: bool 
          mutable title: string }

    type PaneScopeSelector =
        { title: string }

    type TabsController =
        { mutable addPane: Pane -> unit }

    type BeerForms =
        { ``0``: string
          one: string
          few: string
          other: string }

    [<AbstractClass>]
    type TabsScope =
        [<DefaultValue>] val mutable panes: Pane array
        [<DefaultValue>] val mutable select: Pane -> unit

    [<AbstractClass>]
    type BeerCounterScope =
        [<DefaultValue>] val mutable beers: int array
        [<DefaultValue>] val mutable beerForms: BeerForms


    let NgRepeat = Attr.NewAttr "ng-repeat"
    let NgClass = Attr.NewAttr "ng-class"
    let NgClick = Attr.NewAttr "ng-click"
    let NgTransclude = Attr.NewAttr "ng-transclude"

    [<Inline "{}">]
    let IsolatedScope = X<obj>

    let Templatify element = (Div [ element ]).Html     // This method produces the *inner* HTML of the element, so everything needs to be wrapped in an empty div

    let Main =
        let tabsTemplate =
            Div [ Attr.Class "tabbable" ] -< [
                UL [ Attr.Class "nav nav-tabs" ] -< [
                    LI [ NgRepeat "pane in panes"; NgClass "{active:pane.selected}" ] -< [
                        A [ HRef ""; NgClick "select(pane)" ] -< [ Text "{{pane.title}}" ]
                    ]
                ]
                Div [ Attr.Class "tab-content"; NgTransclude "" ]
            ]
            |> Templatify
        
        let paneTemplate =
            Div [ Attr.Class "tab-pane"; NgClass "{active: selected}"; NgTransclude "" ]
            |> Templatify
            
        let componentsModule = Angular.Module("components", [||])
        let tabsController =
            componentsModule
                .Controller("TabsCtrl", (
                                "$scope", "$element",
                                System.Action<TabsController, TabsScope, JQuery>(
                                    fun controller scope element ->
                                        scope.panes <- [||]
                                        scope.select <-
                                            fun pane ->
                                                scope.panes |> Array.iter (fun p -> p.selected <- false)
                                                pane.selected <- true
                                        controller.addPane <-
                                            fun pane ->
                                                if scope.panes.Length = 0 then scope.select(pane)
                                                scope.panes.ToEcma().Push(pane) |> ignore                
                )))
        let tabsDirective =
            componentsModule
                .Directive("tabs", fun _ ->
                    DirectiveConfig(
                        Restrict = "E",
                        Transclude = true,
                        Scope = IsolatedScope,
                        Controller = "TabsCtrl",
                        Template = tabsTemplate,
                        Replace = true
                    )
                )
                .Directive("pane", fun _ ->
                    DirectiveConfig(
                        Require = "^tabs",
                        Restrict = "E",
                        Transclude = true,
                        Scope = { title = "@" },
                        Link = (
                            fun (scope, element, attrs, tabsCtrl) ->
                                tabsCtrl.addPane(scope)
                        ),
                        Template = paneTemplate,
                        Replace = true
                    )
                )

        Angular
            .Module("app", [| "components" |])
            .Controller("BeerCounter", (
                            "$scope", "$locale",
                            fun (scope: BeerCounterScope, locale: LocaleService) ->
                                scope.beers <- [| 0..6 |]
                                if locale.Id = "en-us" then
                                    scope.beerForms <-
                                        { ``0`` = "no beers"
                                          one = "{} beer"
                                          few = "{} beer"
                                          other = "{} beers" }
                                else
                                    scope.beerForms <-
                                        { ``0`` = "žiadne pivo"
                                          one = "{} pivo"
                                          few = "{} pivá"
                                          other = "{} pív" }
            ))