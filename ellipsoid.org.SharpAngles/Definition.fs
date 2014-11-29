namespace ellipsoid.org.SharpAngles

open ellipsoid.org.SharpAngles.Resources
open IntelliFactory.WebSharper.Dom
open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

module Definition =

    (*
        Helper definitions
        ==================
    *)

    let Any = T<obj>
    let Bool = T<bool>
    let Dictionary t1 t2 = T<System.Collections.Generic.Dictionary<_,_>>.[t1,t2]
    let Document = T<Document>
    let Element = T<Element>
    let Function = T<obj>
    let Int = T<int>
    let JQuery = T<JQuery>
    let Number = T<float>
    let Object = T<obj>
    let Config = T<obj> // Expressed by {}
    let String = T<string>
    let Void = T<unit>

    let Optional x = !? x
    let ArrayOf x = Type.ArrayOf x    
    let ParamArrayOf x = !+ x
    let FunctionOf x y z = x -* y ^-> z
    
    (*
        Type definitions: core
        ======================
    *)
    
    let AnchorScrollProvider = Type.New ()
    let AnchorScrollService = Type.New ()
    let AngularBootstrapConfig = Type.New ()
    let AngularEvent = Type.New ()
    let AngularStatic = Type.New ()
    let AngularStaticVersion = Type.New ()
    let AnimateCallbackObject = Type.New ()
    let AnimateProvider = Type.New ()
    let AnimateService = Type.New ()
    let AsyncModelValidators = Type.New ()
    let Attributes = Type.New ()
    let AugmentedJQuery = Type.New ()
    let AugmentedJQueryStatic = Type.New ()
    let AutoInjectorService = Type.New ()
    let AutoProvideService = Type.New ()
    let BrowserService = Type.New ()
    let CacheFactoryService = Type.New ()
    let CacheObject = Type.New ()
    let CloneAttachFunction = Type.New ()
    let CompiledExpression = Type.New ()
    let CompileProvider = Type.New ()
    let CompileService = Type.New ()
    let ControllerProvider = Type.New ()
    let ControllerService = Type.New ()
    let Deferred = Type.New ()
    let Directive = Type.New ()
    let DirectiveCompileFn = Type.New ()
    let DirectiveFactory = Type.New ()
    let DirectiveLinkFn = Type.New ()
    let DirectivePrePost = Type.New ()
    let DocumentService = Type.New ()
    let ExceptionHandlerService = Type.New ()
    let FilterProvider = Type.New ()
    let FilterService = Type.New ()
    let FormController = Type.New ()
    let HttpBackendService = Type.New ()
    let HttpHeadersGetter = Type.New ()
    let HttpPromise = Type.New ()
    let HttpPromiseCallbackArg = Type.New ()
    let HttpProvider = Type.New ()
    let HttpProviderDefaults = Type.New ()
    let HttpService = Type.New ()
    let IntervalService = Type.New ()
    let InjectorService = Type.New ()
    let InterpolateProvider = Type.New ()
    let InterpolateService = Type.New ()
    let InterpolationFunction = Type.New ()
    let LocaleDateTimeFormatDescriptor = Type.New ()
    let LocaleNumberFormatDescriptor = Type.New ()
    let LocaleNumberPatternDescriptor = Type.New ()
    let LocaleService = Type.New ()
    let LocationProvider = Type.New ()
    let LocationService = Type.New ()
    let LogCall = Type.New ()
    let LogService = Type.New ()
    let ModelFormatter = Type.New ()
    let ModelParser = Type.New ()
    let ModelValidators = Type.New ()
    let ModelViewChangeListener = Type.New ()
    let Module = Type.New ()
    let NgModelController = Type.New ()
    let ParseProvider = Type.New ()
    let ParseService = Type.New ()
    let Promise = Type.New ()
    let QResolveReject = Type.New ()
    let QService = Type.New ()
    let RequestConfig = Type.New ()
    let RequestShortcutConfig = Type.New ()
    let RootElementService = Type.New ()
    let RootScopeService = Type.New ()
    let Scope = Type.New ()
    let SCEDelegateProvider = Type.New ()
    let SCEDelegateService = Type.New ()
    let SCEProvider = Type.New ()
    let SCEService = Type.New ()
    let ServiceProvider = Type.New ()
    let TemplateCacheService = Type.New ()
    let TemplateLinkingFunction = Type.New ()
    let TemplateRequestService = Type.New ()
    let TimeoutService = Type.New ()
    let TranscludeFunction = Type.New ()
    let WindowService = Type.New ()

    (*
        Type definitions: resource
        ==========================
    *)

    let ResourceOptions = Type.New ()
    let ResourceService = Type.New ()
    let ActionDescriptor = Type.New ()
    let _ResourceClass<'T> = Type.New ()
    let Resource<'T> = Type.New ()
    let ResourceArray<'T> = Type.New ()
    let Array<'T> = Type.New ()

    (*
        Type definitions: route
        =======================
    *)

    let RouteParamsService = Type.New ()
    let RouteService = Type.New ()
    let Route = Type.New ()
    let CurrentRoute = Type.New ()
    let RouteProvider = Type.New ()

    (*
        Generic definitions
        ===================
    *)

    let PromiseClass =
        Generic / fun t1 ->
            Class "ng.Promise"
            |=> Promise
            |+> Protocol [
                Generic - fun t2 ->
                    "then"          => (t1?promiseValue ^-> HttpPromise.[t2])?successCallback * Optional (Any?reason ^-> Any)?errorCallback * Optional (Any?state ^-> Any)?notifyCallback ^-> Promise.[t2]
                |> WithComment  ("Regardless of when the promise was or will be resolved or rejected, then calls one of the success or error callbacks asynchronously " +
                                 "as soon as the result is available. The callbacks are called with a single argument: the result or rejection reason. Additionally, " +
                                 "the notify callback may be called zero or more times to provide a progress indication, before the promise is resolved or rejected.\r\n\r\n" +
                                 "This method returns a new promise which is resolved or rejected via the return value of the successCallback, errorCallback. It also " +
                                 "notifies via the return value of the notifyCallback method. The promise can not be resolved or rejected from the notifyCallback method.")
                Generic - fun t2 ->
                    "then"          => (t1?promiseValue ^-> Promise.[t2])?successCallback * Optional (Any?reason ^-> Any)?errorCallback * Optional (Any?state ^-> Any)?notifyCallback ^-> Promise.[t2]
                |> WithComment  ("Regardless of when the promise was or will be resolved or rejected, then calls one of the success or error callbacks asynchronously " +
                                 "as soon as the result is available. The callbacks are called with a single argument: the result or rejection reason. Additionally, " +
                                 "the notify callback may be called zero or more times to provide a progress indication, before the promise is resolved or rejected.\r\n\r\n" +
                                 "This method returns a new promise which is resolved or rejected via the return value of the successCallback, errorCallback. It also " +
                                 "notifies via the return value of the notifyCallback method. The promise can not be resolved or rejected from the notifyCallback method.")
                Generic - fun t2 ->
                    "then"          => (t1?promiseValue ^-> t2)?successCallback * Optional (Any?reason ^-> t2)?errorCallback * Optional (Any?state ^-> Any)?notifyCallback ^-> Promise.[t2]
                |> WithComment  ("Regardless of when the promise was or will be resolved or rejected, then calls one of the success or error callbacks asynchronously " +
                                 "as soon as the result is available. The callbacks are called with a single argument: the result or rejection reason. Additionally, " +
                                 "the notify callback may be called zero or more times to provide a progress indication, before the promise is resolved or rejected.\r\n\r\n" +
                                 "This method returns a new promise which is resolved or rejected via the return value of the successCallback, errorCallback. It also " +
                                 "notifies via the return value of the notifyCallback method. The promise can not be resolved or rejected from the notifyCallback method.")
                Generic - fun t2 ->
                    "catch"         => (Any?reason ^-> HttpPromise.[t2])?onRejected ^-> Promise.[t2]
                |> WithComment "Shorthand for promise.then(null, errorCallback)"
                Generic - fun t2 ->
                    "catch"         => (Any?reason ^-> Promise.[t2])?onRejected ^-> Promise.[t2]
                |> WithComment "Shorthand for promise.then(null, errorCallback)"
                Generic - fun t2 ->
                    "catch"         => (Any?reason ^-> t2)?onRejected ^-> Promise.[t2]
                |> WithComment "Shorthand for promise.then(null, errorCallback)"
                Generic - fun t2 ->
                    "finally"       => (Void ^-> Any)?finallyCallback ^-> Promise.[t2]
                |> WithComment  ("Allows you to observe either the fulfillment or rejection of a promise, but to do so without modifying the final value. This is useful " +
                                 "to release resources or do some clean-up that needs to be done whether the promise was rejected or resolved. See the full " +
                                 "specification for more information.\r\n\r\n" +
                                 "Because finally is a reserved word in JavaScript and reserved keywords are not supported as " +
                                 "property names by ES3, you'll need to invoke the method like promise['finally'](callback) to make your code IE8 and Android 2.x " +
                                 "compatible.")
            ]

    let HttpPromiseClass =
        Generic / fun t1 ->
            let httpPromiseCallback ofType = ofType?data * Number?status * HttpHeadersGetter?headers * RequestConfig?config ^-> Void

            Class "ng.HttpPromise"
            |=> Inherits (PromiseClass t1)
            |=> HttpPromise
            |+> Protocol [
                "success"           => (httpPromiseCallback t1)?callback ^-> HttpPromise.[t1]
                "error"             => (httpPromiseCallback Any)?callback ^-> HttpPromise.[t1]
                Generic - fun t2 ->
                    "then"          => (HttpPromiseCallbackArg.[t1]?response ^-> Promise.[t2])?successCallback * (HttpPromiseCallbackArg.[Any]?response ^-> Any)?errorCallback ^-> Promise.[t2]
                Generic - fun t2 ->
                    "then"          => (HttpPromiseCallbackArg.[t1]?response ^-> t2)?successCallback * (HttpPromiseCallbackArg.[Any]?response ^-> Any)?errorCallback ^-> Promise.[t2]
            ]

    let ResourceClassClass =
        Generic / fun t ->
            let successCallbackType = Void ^-> Void
            let errorCallbackType = Optional (Void ^-> Void)
            let zeroDef returnType = successCallbackType * errorCallbackType ^-> returnType
            let oneDef returnType = Object * successCallbackType * errorCallbackType ^-> returnType
            let twoDef returnType = Object * Object * successCallbackType * errorCallbackType ^-> returnType
            let resClass name returnType =
                [
                    name            => Void ^-> returnType :> CodeModel.Member
                    name            => Object ^-> returnType :> CodeModel.Member
                    name            => zeroDef returnType :> CodeModel.Member
                    name            => oneDef returnType :> CodeModel.Member
                    name            => twoDef returnType :> CodeModel.Member
                ]
            let classDef =
                [ ("get", t); ("query", ResourceArray<_>); ("save", t); ("remove", t); ("delete", t) ]     // TODO: make IResourceArray<_> appear as the appropriate type
                |> List.map (fun e ->
                    match e with
                        | (s, returnType) -> resClass s returnType
                )
                |> List.collect (fun e -> e)

            Class "ng.resource.ResourceClass"
            |=> _ResourceClass
            |+> [] // TODO: implement new(..)
            |+> Protocol classDef

    let ResourceClass =
        Generic / fun t ->
            let successCallbackType = Optional (Void ^-> Void)
            let errorCallbackType = Optional (Void ^-> Void)
            let zeroDef returnType = successCallbackType * errorCallbackType ^-> returnType
            let oneDef returnType = Optional Object * successCallbackType * errorCallbackType ^-> returnType
            let res name returnType =
                [
                    // name            =>! Void ^-> Promise.[t] :> CodeModel.IInterfaceMember
                ]

            Class "ng.resource.Resource"
            |=> Resource
            |+> Protocol [
                "$get"              => Void ^-> Promise.[t]
            ]

    (*
        Angular definitions
        ===================
    *)

    let Angular =
        Class "angular"
        |+> [
            "bind"                  => Any?context * Function?fn *+ Any ^-> Function
            "bootstrap"             => (String + JQuery + Element + Document)?element * Optional String?modules * Optional AngularBootstrapConfig?config ^-> InjectorService
            "bootstrap"             => (String + JQuery + Element + Document)?element * Optional Function?modules * Optional AngularBootstrapConfig?config ^-> InjectorService
            "bootstrap"             => (String + JQuery + Element + Document)?element * Optional (ArrayOf String)?modules * Optional AngularBootstrapConfig?config ^-> InjectorService
            Generic - fun t ->
                "copy"              => t?source * Optional t?destination ^-> t
            "element"               =? AugmentedJQueryStatic
            "equals"                => Any?value1 * Any?value2 ^-> Bool
            "extend"                => Any?destination *+ Any ^-> Any
            Generic - fun t ->
                "forEach"           => (ArrayOf t)?obj * (t?value * Number?key ^-> Any)?iterator * Optional Any?context ^-> Any
            Generic - fun t ->
                "forEach"           => (Dictionary String t)?obj * (t?value * String?key ^-> Any) * Optional Any?context ^-> Any
            "forEach"               => Any?obj * (Any?value * Any?key ^-> Any) * Optional Any?context ^-> Any
            "fromJson"              => String?json ^-> Any
            "identity"              => Optional Any?arg ^-> Any
            "injector"              => Optional (ArrayOf Any)?modules ^-> InjectorService
            "isArray"               => Any?value ^-> Bool
            "isDate"                => Any?value ^-> Bool
            "isDefined"             => Any?value ^-> Bool
            "isElement"             => Any?value ^-> Bool
            "isFunction"            => Any?value ^-> Bool
            "isNumber"              => Any?value ^-> Bool
            "isObject"              => Any?value ^-> Bool
            "isString"              => Any?value ^-> Bool
            "isUndefined"           => Any?value ^-> Bool
            "lowercase"             => String?str ^-> String
            "module"                => String?name * Optional (ArrayOf String)?requires * Optional Function?configFn ^-> Module
            "noop"                  => ParamArrayOf Any ^-> Void
            "reloadWithDebugInfo"   => Void ^-> Void
            "toJson"                => Any?obj * Optional Bool?pretty ^-> String
            "uppercase"             => String?str ^-> String
            "version"               =? AngularStaticVersion  // Some creative licence used here
        ]
        |=> Nested [

            Class "ng.AngularStaticVersion"
            |=> AngularStaticVersion
            |+> Protocol [
                "full"                  =? String
                "major"                 =? Number
                "minor"                 =? Number
                "dot"                   =? Number
                "codeName"              =? String
            ]

            Class "ng.Attributes"
            |=> Attributes
            // ...

            Class "ng.Module"
            |=> Module
            |+> Protocol [
                "animation"             => String?name * Function?animationFactory ^-> Module
                "animation"             => String?name * (ArrayOf Any)?inlineAnnotatedFunction ^-> Module
                "animation"             => Object?``object`` ^-> Module
                "config"                => Function?configFn ^-> Module
                "config"                => (ArrayOf Any)?inlineAnnotatedFunction ^-> Module
                "constant"              => String?name * Any?value ^-> Module
                "constant"              => Object?``object`` ^-> Module
                "controller"            => String?name * Function?controllerConstructor ^-> Module
                "controller"            => String?name * (ArrayOf Any)?inlineAnnotatedConstructor ^-> Module
                "controller"            => Object?``object`` ^-> Module
                "directive"             => String?name * DirectiveFactory?directiveFactory ^-> Module
                "directive"             => String?name * (ArrayOf Any)?inlineAnnotatedFunction ^-> Module
                "directive"             => Object?``object`` ^-> Module
                "factory"               => String?name * Function?getFn ^-> Module
                "factory"               => String?name * (ArrayOf Any)?inlineAnnotatedFunction ^-> Module
                "factory"               => Object?``object`` ^-> Module
                Generic - fun t ->
                    "factory"           => String * (ResourceService ^-> ResourceClass t) ^-> Module     // Imported from angular-resource (method signature questionable)
                Generic - fun t ->
                    "factory"           => String * (ResourceService ^-> t) ^-> Module                   // Imported from angular-resource (method signature questionable)
                "filter"                => String?name * Function?filterFactoryFunction ^-> Module
                "filter"                => String?name * (ArrayOf Any)?inlineAnnotatedFunction ^-> Module
                "filter"                => Object?``object`` ^-> Module
                "provider"              => String?name * (ParamArrayOf Any ^-> ServiceProvider)?serviceProviderFactory ^-> Module    // IServiceProviderFactory
                "provider"              => String?name * ServiceProvider?serviceProviderConstructor ^-> Module
                "provider"              => String?name * (ArrayOf Any)?inlineAnnotatedConstructor ^-> Module
                "provider"              => String?name * ServiceProvider?providerObject ^-> Module
                "provider"              => Object?``object`` ^-> Module
                "run"                   => Function?initialisationFunction ^-> Module
                "run"                   => (ArrayOf Any)?inlineAnnonatedFunction ^-> Module
                "service"               => String?name * Function?serviceConstructor ^-> Module
                "service"               => String?name * (ArrayOf Any)?inlineAnnonatedConstructor ^-> Module
                "service"               => Object?``object`` ^-> Module
                "value"                 => String?name * Any?value ^-> Module
                "value"                 => Object?``object`` ^-> Module
                "name"                  =? String
                "requires"              =? ArrayOf String
            ]

            Class "ng.FormController"
            |=> FormController
            // ...

            Generic - HttpPromiseClass

            Class "ng.LocationService"
            |=> LocationService
            |+> Protocol [
                "absUrl"                => Void ^-> String
                "hash"                  => Void ^-> String
                "hash"                  => String ^-> LocationService
                "host"                  => Void ^-> String
                "path"                  => Void ^-> String
                "path"                  => String ^-> LocationService
                "port"                  => Void ^-> Number
                "protocol"              => Void ^-> String
                "replace"               => Void ^-> LocationService
                "search"                => Void ^-> Any
                "search"                => Any ^-> LocationService
                "search"                => String * String ^-> LocationService
                "search"                => String * Number ^-> LocationService
                "search"                => String * ArrayOf String ^-> LocationService
                "search"                => String * Bool ^-> LocationService
                "state"                 => Void ^-> Any
                "state"                 => Any ^-> LocationService
                "url"                   => Void ^-> String
                "url"                   => String ^-> LocationService
            ]

            Class "ng.LocaleService"
            |=> LocaleService
            |+> Protocol [
                "id"                    =? String
                "NUMBER_FORMATS"        =? LocaleNumberFormatDescriptor
                "DATETIME_FORMATS"      =? LocaleDateTimeFormatDescriptor
                "pluralCat"             =? Any ^-> String
            ]

            Generic - PromiseClass

            Class "ng.ServiceProvider"
            |=> ServiceProvider
            |+> Protocol [
                "$get"                   =? Any
            ]

            Class "ng.auto"
            |=> Nested [
                Class "ng.auto.InjectorService"
                |=> AutoInjectorService
                // ...

                Class "ng.auto.ProvideService"
                |=> AutoProvideService
                // ...
            ]            

            Class "ng.resource"
            |=> Nested [
                Class "ng.resource.ResourceOptions"
                |=> ResourceOptions
                |+> Protocol [
                    "stripTrailingSlashes"  =@ Bool
                ]

                Class "ng.resource.ResourceService"
                |=> ResourceService
                // ...
                // Unclear how to implement this signature

                Class "ng.resource.ActionDescriptor"
                |=> ActionDescriptor
                |+> Protocol [
                    "method"                =? String
                    "isArray"               =? Bool
                    "params"                =? Any
                    "headers"               =? Any
                ]

                Generic - ResourceClassClass
                Generic - ResourceClass
            ]

            Class "ng.route"
            |=> Nested [
                Class "ng.route.RouteParamsService"
                |=> RouteParamsService
                |+> Protocol [
                    "item"                  =@ Any |> Indexed String
                ]
            ]
            |=> Nested [
                Class "ng.route.RouteService"
                |=> RouteService
                |+> Protocol [
                    "reload"                => Void ^-> Void
                    "routes"                =? Any
                    "current"               =? CurrentRoute
                ]

                Class "ng.route.Route"
                |=> Route
                |+> Protocol [
                    "controller"            =? Any
                    "controllerAs"          =? String
                    "name"                  =? String
                    "template"              =? String
                    "templateUrl"           =? Any
                    "resolve"               =? Dictionary String Any
                    "redirectTo"            =? Any
                    "reloadOnSearch"        =? Bool
                    "caseInsensitiveMatch"  =? Bool
                ]

                Class "ng.route.CurrentRoute"
                |=> CurrentRoute
                |=> Inherits Route
                |+> Protocol [
                    "locals"                =? Any // Needs proper implementation
                    "params"                =? Any
                ]

                Class "ng.route.RouteProvider"
                |=> RouteProvider
                |=> Inherits ServiceProvider
                |+> Protocol [
                    "otherwise"             => Route ^-> RouteProvider
                    "when"                  => String * Route ^-> RouteProvider
                ]
            ]        
        ]

    let AngularBootstrapConfigConfig =
        Pattern.Config "AngularBootstrapConfig" {
            Required = []
            Optional =
            [
                "strictDi", Bool
            ]
        }
        |=> AngularBootstrapConfig

    let DirectiveConfig =
        Pattern.Config "DirectiveConfig" {
            Required = []
            Optional =
            [
                "compile", DirectiveCompileFn
                "controller", Any
                "controllerAs", String
                "bindToController", Bool
                "link", DirectiveLinkFn
                "name", String
                "priority", Number
                "replace", Bool
                "require", Any
                "restrict", String
                "scope", Any
                "template", Any
                "templateUrl", Any
                "terminal", Bool
                "transclude", Any
            ]
        }
        |=> Inherits Directive

    let RouteConfig =
        Pattern.Config "RouteConfig" {
            Required = []
            Optional = 
            [
                "controller", Any
                "controllerAs", String
                "name", String
                "template", String
                "templateUrl", String
                "resolve", Dictionary String Any
                "redirectTo", Any
                "reloadOnSearch", Bool
                "caseInsensitiveMatch", Bool
            ]
        }
        |=> Inherits Route

    let Assembly =
        Assembly [
            Namespace "ellipsoid.org.SharpAngles" [
                Angular

                // Configuration objects
                RouteConfig
                DirectiveConfig
            ]
            Namespace "ellipsoid.org.SharpAngles.Resources" [
                AngularJs
                AngularJsResource
                AngularJsRoute
            ]
        ]
        |> Requires [ AngularJs; AngularJsRoute ]

open IntelliFactory.WebSharper.InterfaceGenerator

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
