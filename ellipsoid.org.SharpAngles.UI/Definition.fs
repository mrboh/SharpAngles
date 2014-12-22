namespace ellipsoid.org.SharpAngles.UI

open ellipsoid.org.SharpAngles
open ellipsoid.org.SharpAngles.Common
open ellipsoid.org.SharpAngles.UI.Resources
open IntelliFactory.WebSharper.InterfaceGenerator

module Definition =

    (*
        Type definitions: ui-router
        ===========================
    *)
    
    let HrefOptions = Type.New ()
    let State = Type.New ()
    let StateOptions = Type.New ()
    let StateProvider = Type.New ()
    let StateService = Type.New ()
    let UIViewScrollProvider = Type.New ()
    let UrlMatcher = Type.New ()
    let UrlMatcherFactory = Type.New ()
    let UrlRouterProvider = Type.New ()
    let UrlRouterService = Type.New ()

    let HrefOptionsConfig =
        Pattern.Config "HrefOptionsConfig" {
            Required = []
            Optional =
            [
                "lossy", Bool
                "inherit", Bool
                "relative", State
                "absolute", Bool
            ]
        }
        |=> HrefOptions

    let StateConfig =
        Pattern.Config "StateConfig" {
            Required = []
            Optional =
            [
                "name", String
                "template", Any
                "templateUrl", Any
                "templateProvider", Any
                "controller", Any
                "controllerAs", String
                "controllerProvider", Any
                "resolve", Config
                "url", String
                "params", Any
                "views", Config
                "abstract", Bool
                "onEnter", Any
                "onExit", Any
                "data", Any
                "reloadOnSearch", Bool
            ]
        }
        |=> State

    let StateOptionsConfig =
        Pattern.Config "StateOptionsConfig" {
            Required = []
            Optional =
            [
                "location", Any
                "inherit", Bool
                "relative", State
                "notify", Bool
            ]
        }
        |=> StateOptions

    let StateProviderClass =
        Class "ng.ui.StateProvider"
        |=> Inherits T<ServiceProvider>
        |=> StateProvider
        |+> Protocol [
            "state"                 => String?name * State?config ^-> StateProvider
            "state"                 => State?config ^-> StateProvider
            "decorator"             => Optional String?name * Optional (State?state * Function?parent ^-> Any)?decorator ^-> Any
        ]

    let StateServiceClass =
        Class "ng.ui.StateService"
        |=> StateService
        |+> Protocol [
            "go"                    => String?``to`` * Optional Config?``params`` * Optional StateOptions?options ^-> T<Promise<_>>
            // Combined both transitionTo declarations to prevent doubling up of method signatures
            "transitionTo"          => String?state * Optional Config?``params`` * Optional (Bool + StateOptions)?updateLocationOrOptions ^-> Void
            // "transitionTo"          => String?state * Optional Config?``params`` * Optional StateOptions?options ^-> Void
            "includes"              => String?state * Config?``params`` ^-> Bool
            "is"                    => (String + State)?state * Optional Config?``params`` ^-> Bool
            "href"                  => (String + State)?state * Optional Config?``params`` * Optional HrefOptions?options ^-> String
            "get"                   => String?state ^-> State
            "get"                   => Void ^-> ArrayOf State
            "current"               =? State
            "params"                =? Dictionary String Any
            "reload"                => Void ^-> Void
        ]

    let UIViewScrollProviderClass =
        Class "ng.ui.UIViewScrollProvider"
        |=> UIViewScrollProvider
        |+> Protocol [
            "useAnchorScroll"       => Void ^-> Void
        ]

    let UrlMatcherClass =
        Class "ng.ui.UrlMatcher"
        |=> UrlMatcher
        |+> Protocol [
            "concat"                => String?pattern ^-> UrlMatcher
            "exec"                  => String?path * Config?searchParams ^-> Config
            "parameters"            => Void ^-> ArrayOf String
            "format"                => Config?values ^-> String
        ]

    let UrlMatcherFactoryClass =
        Class "ng.ui.UrlMatcherFactory"
        |=> UrlMatcherFactory
        |+> Protocol [
            "compile"               => String?pattern ^-> UrlMatcher
            "isMatcher"             => Any?o ^-> Bool
        ]

    let UrlRouterProviderClass =
        Class "ng.ui.UrlRouterProvider"
        |=> Inherits T<ServiceProvider>
        |=> UrlRouterProvider
        |+> Protocol [
            "when"                  => (RegExp + UrlMatcher + String)?whenPath * (Function + ArrayOf Any)?handler ^-> UrlRouterProvider
            "when"                  => (RegExp + UrlMatcher + String)?whenPath * String?toPath ^-> UrlRouterProvider
            "otherwise"             => (Function + ArrayOf Any)?handler ^-> UrlRouterProvider
            "otherwise"             => String?path ^-> UrlRouterProvider
            "rule"                  => (Function + ArrayOf Any)?handler ^-> UrlRouterProvider
        ]

    let UrlRouterServiceClass =
        Class "ng.ui.UrlRouterService"
        |=> UrlRouterService
        |+> Protocol [
            "sync"                  => Void ^-> Void
        ]

    let Assembly =
        Assembly [
            Namespace "ellipsoid.org.SharpAngles.UI" [
                HrefOptionsConfig
                StateConfig
                StateOptionsConfig
                StateProviderClass
                StateServiceClass
                UIViewScrollProviderClass
                UrlMatcherClass
                UrlMatcherFactoryClass
                UrlRouterProviderClass
                UrlRouterServiceClass
            ]
            Namespace "ellipsoid.org.SharpAngles.UI.Resources" [
                AngularUIRouter
            ]
        ]
        |> Requires [ AngularUIRouter ]

open IntelliFactory.WebSharper.InterfaceGenerator

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
