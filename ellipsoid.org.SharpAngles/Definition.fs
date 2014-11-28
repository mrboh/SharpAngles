namespace ellipsoid.org.SharpAngles

open ellipsoid.org.SharpAngles.Resources
open IntelliFactory.WebSharper
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
    let JQuery = T<JQuery.JQuery>
    let Number = T<float>
    let Object = T<obj>
    let Config = T<obj> // Expressed by {}
    let String = T<string>
    let Void = T<unit>

    let Optional x = !? x
    let ArrayOf x = Type.ArrayOf x    
    let ParamArrayOf x = !+ x
    let FunctionOf x y z = x -* y ^-> z
    
    // Used because WebSharper does not lowercase interface elements (despite doing so for classes)
    let (=>|) x y = x => y |> WithSourceName x   
    let (=?|) x y = x =? y |> WithSourceName x
    let (=!|) x y = x =! y |> WithSourceName x
    let (=@|) x y = x =@ y |> WithSourceName x
    let (=%|) x y = x =% y |> WithSourceName x

    let (=>|!) x y = x => y |> WithSourceName (x.TrimStart('$'))      // For dollarised members
    let (=?|!) x y = x =? y |> WithSourceName (x.TrimStart('$'))      // For dollarised members
    let (=!|!) x y = x =! y |> WithSourceName (x.TrimStart('$'))      // For dollarised members
    let (=@|!) x y = x =@ y |> WithSourceName (x.TrimStart('$'))      // For dollarised members
    let (=%|!) x y = x =% y |> WithSourceName (x.TrimStart('$'))      // For dollarised members

    (*
        Type definitions: core
        ======================
    *)
    
    let IAnchorScrollProvider = Type.New ()
    let IAnchorScrollService = Type.New ()
    let IAngularBootstrapConfig = Type.New ()
    let IAngularEvent = Type.New ()
    let IAngularStatic = Type.New ()
    let IAngularStaticVersion = Type.New ()
    let IAnimateCallbackObject = Type.New ()
    let IAnimateProvider = Type.New ()
    let IAnimateService = Type.New ()
    let IAsyncModelValidators = Type.New ()
    let IAttributes = Type.New ()
    let IAugmentedJQuery = Type.New ()
    let IAugmentedJQueryStatic = Type.New ()
    let IAutoInjectorService = Type.New ()
    let IAutoProvideService = Type.New ()
    let IBrowserService = Type.New ()
    let ICacheFactoryService = Type.New ()
    let ICacheObject = Type.New ()
    let ICloneAttachFunction = Type.New ()
    let ICompiledExpression = Type.New ()
    let ICompileProvider = Type.New ()
    let ICompileService = Type.New ()
    let IControllerProvider = Type.New ()
    let iControllerService = Type.New ()
    let IDeferred = Type.New ()
    let IDirective = Type.New ()
    let IDirectiveCompileFn = Type.New ()
    let IDirectiveFactory = Type.New ()
    let IDirectiveLinkFn = Type.New ()
    let IDirectivePrePost = Type.New ()
    let IDocumentService = Type.New ()
    let IExceptionHandlerService = Type.New ()
    let IFilterProvider = Type.New ()
    let IFilterService = Type.New ()
    let IFormController = Type.New ()
    let IHttpBackendService = Type.New ()
    let IHttpHeadersGetter = Type.New ()
    let IHttpPromise = Type.New ()
    let IHttpPromiseCallbackArg = Type.New ()
    let IHttpProvider = Type.New ()
    let IHttpProviderDefaults = Type.New ()
    let IHttpService = Type.New ()
    let IIntervalService = Type.New ()
    let IInjectorService = Type.New ()
    let IInterpolateProvider = Type.New ()
    let IInterpolateService = Type.New ()
    let IInterpolationFunction = Type.New ()
    let ILocaleDateTimeFormatDescriptor = Type.New ()
    let ILocaleNumberFormatDescriptor = Type.New ()
    let ILocaleNumberPatternDescriptor = Type.New ()
    let ILocaleService = Type.New ()
    let ILocationProvider = Type.New ()
    let ILocationService = Type.New ()
    let ILogCall = Type.New ()
    let ILogService = Type.New ()
    let IModelFormatter = Type.New ()
    let IModelParser = Type.New ()
    let IModelValidators = Type.New ()
    let IModelViewChangeListener = Type.New ()
    let IModule = Type.New ()
    let INgModelController = Type.New ()
    let IParseProvider = Type.New ()
    let IParseService = Type.New ()
    let IPromise = Type.New ()
    let IQResolveReject = Type.New ()
    let IQService = Type.New ()
    let IRequestConfig = Type.New ()
    let IRequestShortcutConfig = Type.New ()
    let IRootElementService = Type.New ()
    let IRootScopeService = Type.New ()
    let IScope = Type.New ()
    let ISCEDelegateProvider = Type.New ()
    let ISCEDelegateService = Type.New ()
    let ISCEProvider = Type.New ()
    let ISCEService = Type.New ()
    let IServiceProvider = Type.New ()
    let IServiceProviderClass = Type.New ()
    let IServiceProviderFactory = Type.New ()
    let ITemplateCacheService = Type.New ()
    let ITemplateLinkingFunction = Type.New ()
    let ITemplateRequestService = Type.New ()
    let ITimeoutService = Type.New ()
    let ITranscludeFunction = Type.New ()
    let IWindowService = Type.New ()

    (*
        Type definitions: resource
        ==========================
    *)

    let IResourceOptions = Type.New ()
    let IResourceService = Type.New ()
    let IActionDescriptor = Type.New ()
    let IResourceClass<'T> = Type.New ()
    let IResource<'T> = Type.New ()
    let IResourceArray<'T> = Type.New ()
    let IArray<'T> = Type.New ()

    (*
        Type definitions: route
        =======================
    *)

    let IRouteParamsService = Type.New ()
    let IRouteService = Type.New ()
    let IRoute = Type.New ()
    let ICurrentRoute = Type.New ()
    let IRouteProvider = Type.New ()

    (*
        Generic definitions
        ===================
    *)

    let IHttpPromiseInterface =
        Generic / fun t1 ->
            let iHttpPromiseCallback ofType = ofType * Number * IHttpHeadersGetter * IRequestConfig ^-> Void

            Interface "ng.IHttpPromise"
            // |=> Extends [ IPromise.[t1] ] // TODO: figure out how to extend generic types
            |=> IHttpPromise
            |+> [
                "success"           =>| iHttpPromiseCallback t1 ^-> IHttpPromise.[t1]
                "error"             =>| iHttpPromiseCallback Any ^-> IHttpPromise.[t1]
                Generic - fun t2 ->
                    "then"          =>| (IHttpPromiseCallbackArg.[t1] ^-> IPromise.[t2]) * (IHttpPromiseCallbackArg.[Any] ^-> Any) ^-> IPromise.[t2]
                Generic - fun t2 ->
                    "then"          =>| (IHttpPromiseCallbackArg.[t1] ^-> t2) * (IHttpPromiseCallbackArg.[Any] ^-> Any) ^-> IPromise.[t2]
            ]

    let IPromiseInterface =
        Generic / fun t1 ->
            Interface "ng.IPromise"
            |=> IPromise
            |+> [
                Generic - fun t2 ->
                    "then"          =>| (t1 ^-> IHttpPromise.[t2]) * Optional (Any ^-> Any) * Optional (Any ^-> Any) ^-> IPromise.[t2]
                Generic - fun t2 ->
                    "then"          =>| (t1 ^-> IPromise.[t2]) * Optional (Any ^-> Any) * Optional (Any ^-> Any) ^-> IPromise.[t2]
                Generic - fun t2 ->
                    "then"          =>| (t1 ^-> t2) * Optional (Any ^-> t2) * Optional (Any ^-> Any) ^-> IPromise.[t2]
                Generic - fun t2 ->
                    "catch"         =>| (Any ^-> IHttpPromise.[t2]) ^-> IPromise.[t2]
                Generic - fun t2 ->
                    "catch"         =>| (Any ^-> IHttpPromise.[t2]) ^-> IPromise.[t2]
                Generic - fun t2 ->
                    "catch"         =>| (Any ^-> t2) ^-> IPromise.[t2]
                Generic - fun t2 ->
                    "finally"       =>| (Void ^-> Any) ^-> IPromise.[t2]
            ]

    let IResourceClassInterface =
        Generic / fun t ->
            let successCallbackType = Void ^-> Void
            let errorCallbackType = Optional (Void ^-> Void)
            let zeroDef returnType = successCallbackType * errorCallbackType ^-> returnType
            let oneDef returnType = Object * successCallbackType * errorCallbackType ^-> returnType
            let twoDef returnType = Object * Object * successCallbackType * errorCallbackType ^-> returnType
            let resClass name returnType =
                [
                    name            =>| Void ^-> returnType :> CodeModel.IInterfaceMember
                    name            =>| Object ^-> returnType :> CodeModel.IInterfaceMember
                    name            =>| zeroDef returnType :> CodeModel.IInterfaceMember
                    name            =>| oneDef returnType :> CodeModel.IInterfaceMember
                    name            =>| twoDef returnType :> CodeModel.IInterfaceMember
                ]
            let interfaceDef =
                [ ("get", t); ("query", IResourceArray<_>); ("save", t); ("remove", t); ("delete", t) ]     // TODO: make IResourceArray<_> appear as the appropriate type
                |> List.map (fun e ->
                    match e with
                        | (s, returnType) -> resClass s returnType
                )
                |> List.collect (fun e -> e)

            Interface "ng.resource.IResourceClass"
            |=> IResourceClass
            |+> [] // TODO: implement new(..)
            |+> interfaceDef

    let IResourceInterface =
        Generic / fun t ->
            let successCallbackType = Optional (Void ^-> Void)
            let errorCallbackType = Optional (Void ^-> Void)
            let zeroDef returnType = successCallbackType * errorCallbackType ^-> returnType
            let oneDef returnType = Optional Object * successCallbackType * errorCallbackType ^-> returnType
            let res name returnType =
                [
                    // name            =>|! Void ^-> IPromise.[t] :> CodeModel.IInterfaceMember
                ]

            Interface "ng.resource.IResource"
            |=> IResource
            |+> [
                "$get"              =>|! Void ^-> IPromise.[t]
            ]

    (*
        Angular definitions
        ===================
    *)


    let Angular =
        Class "angular"
        |=> Implements [ IAngularStatic ]
        |+> [
            "bind"                  => Any * Function *+ Any ^-> Function
            "bootstrap"             => String * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => String * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => String * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => JQuery * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => JQuery * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => JQuery * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => Element * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => Element * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => Element * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => Document * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => Document * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
            "bootstrap"             => Document * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
            Generic - fun t ->
                "copy"              => t * Optional t ^-> t
            "element"               =? IAugmentedJQueryStatic
            "equals"                => Any * Any ^-> Bool
            "extend"                => Any *+ Any ^-> Any
            Generic - fun t ->
                "forEach"           => ArrayOf t * (t * Number ^-> Any) * Optional Any ^-> Any
            Generic - fun t ->
                "forEach"           => (Dictionary String t) * (t * String ^-> Any) * Optional Any ^-> Any
            "forEach"               => Any * (Any * Any ^-> Any) * Optional Any ^-> Any
            "fromJson"              => String ^-> Any
            "identity"              => Optional Any ^-> Any
            "injector"              => Optional (ArrayOf Any) ^-> IInjectorService
            "isArray"               => Any ^-> Bool
            "isDate"                => Any ^-> Bool
            "isDefined"             => Any ^-> Bool
            "isElement"             => Any ^-> Bool
            "isFunction"            => Any ^-> Bool
            "isNumber"              => Any ^-> Bool
            "isObject"              => Any ^-> Bool
            "isString"              => Any ^-> Bool
            "isUndefined"           => Any ^-> Bool
            "lowercase"             => String ^-> String
            "module"                => String * Optional (ArrayOf String) * Optional Function ^-> IModule
            "noop"                  => ParamArrayOf Any ^-> Void
            "reloadWithDebugInfo"   => Void ^-> Void
            "toJson"                => Any * Optional Bool ^-> String
            "uppercase"             => String ^-> String
            "version"               => IAngularStaticVersion  // Some creative licence used here
        ]
        |=> Nested [
                
            Interface "ng.IServiceProviderClass"
            |=> IServiceProviderClass
            // ...

            Interface "ng.IServiceProviderFactory"
            |=> IServiceProviderFactory
            // ...

            Interface "ng.IServiceProvider"
            |=> IServiceProvider
            |+> [
                "get"                   =? Any
                |> WithSourceName "$get"
            ]

            Interface "ng.IAngularBootstrapConfig"
            |=> IAngularBootstrapConfig
            |+> [
                "strictDi"              =@ Bool
            ]

            Interface "ng.IAngularStaticVersion"
            |=> IAngularStaticVersion
            |+> [
                "full"                  =? String
                "major"                 =? Number
                "minor"                 =? Number
                "dot"                   =? Number
                "codeName"              =? String
            ]

            Interface "ng.IModule"
            |=> IModule
            |+> [
                "animation"             =>| String * Function ^-> IModule
                "animation"             =>| String * ArrayOf Any ^-> IModule
                "animation"             =>| Object ^-> IModule
                "config"                =>| Function ^-> IModule
                "config"                =>| ArrayOf Any ^-> IModule
                "constant"              =>| String * Any ^-> IModule
                "constant"              =>| Object ^-> IModule
                "controller"            =>| String * Function ^-> IModule
                "controller"            =>| String * ArrayOf Any ^-> IModule
                "controller"            =>| Object ^-> IModule
                "directive"             =>| String * IDirectiveFactory ^-> IModule
                "directive"             =>| String * ArrayOf Any ^-> IModule
                "directive"             =>| Object ^-> IModule
                "factory"               =>| String * Function ^-> IModule
                "factory"               =>| String * ArrayOf Any ^-> IModule
                "factory"               =>| Object ^-> IModule
                Generic - fun t ->
                    "factory"           =>| String * (IResourceService ^-> IResourceClass<_>) ^-> IModule   // Imported from angular-resource (method signature questionable)
                Generic - fun t ->
                    "factory"           =>| String * (IResourceService ^-> t) ^-> IModule                   // Imported from angular-resource (method signature questionable)
                "filter"                =>| String * Function ^-> IModule
                "filter"                =>| String * ArrayOf Any ^-> IModule
                "filter"                =>| Object ^-> IModule
                "provider"              =>| String * IServiceProviderFactory ^-> IModule
                "provider"              =>| String * IServiceProviderClass ^-> IModule
                "provider"              =>| String * ArrayOf Any ^-> IModule
                "provider"              =>| String * IServiceProvider ^-> IModule
                "provider"              =>| Object ^-> IModule
                "run"                   =>| Function ^-> IModule
                "run"                   =>| ArrayOf Any ^-> IModule
                "service"               =>| String * Function ^-> IModule
                "service"               =>| String * ArrayOf Any ^-> IModule
                "service"               =>| Object ^-> IModule
                "value"                 =>| String * Any ^-> IModule
                "value"                 =>| Object ^-> IModule
                "name"                  =? String
                "requires"              =? ArrayOf String
            ]

            Interface "ng.IAttributes"
            |=> IAttributes
            // ...

            Interface "ng.IFormController"
            |=> IFormController
            // ...

            Generic - IPromiseInterface
            Generic - IHttpPromiseInterface

            Interface "ng.ILocationService"
            |=> ILocationService
            |+> [
                "absUrl"                =>| Void ^-> String
                "hash"                  =>| Void ^-> String
                "hash"                  =>| String ^-> ILocationService
                "host"                  =>| Void ^-> String
                "path"                  =>| Void ^-> String
                "path"                  =>| String ^-> ILocationService
                "port"                  =>| Void ^-> Number
                "protocol"              =>| Void ^-> String
                "replace"               =>| Void ^-> ILocationService
                "search"                =>| Void ^-> Any
                "search"                =>| Any ^-> ILocationService
                "search"                =>| String * String ^-> ILocationService
                "search"                =>| String * Number ^-> ILocationService
                "search"                =>| String * ArrayOf String ^-> ILocationService
                "search"                =>| String * Bool ^-> ILocationService
                "state"                 =>| Void ^-> Any
                "state"                 =>| Any ^-> ILocationService
                "url"                   =>| Void ^-> String
                "url"                   =>| String ^-> ILocationService
            ]

        ]
        |=> Nested [    // Cannot nest both classes an interfaces together above (huh?)
            
            // Some interfaces have to be implemented as 'pseudointerfaces' (i.e. classes) because the default
            // representation of a property in an interface appears to be get_Property() and set_Property()
            // rather than just property = xyz

            Class "ng.ILocaleService"
            |=> ILocaleService
            |+> Protocol [
                "id"                    =?| String
                "NUMBER_FORMATS"        =?| ILocaleNumberFormatDescriptor
                "DATETIME_FORMATS"      =?| ILocaleDateTimeFormatDescriptor
                "pluralCat"             =?| Any ^-> String
            ]

            Class "ng.IAngularStatic"
            |=> IAngularStatic
            |+> [
                "bind"                  => Any * Function *+ Any ^-> Function
                "bootstrap"             => String * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => String * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => String * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => JQuery * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => JQuery * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => JQuery * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => Element * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => Element * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => Element * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => Document * Optional String * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => Document * Optional Function * Optional IAngularBootstrapConfig ^-> IInjectorService
                "bootstrap"             => Document * Optional (ArrayOf String) * Optional IAngularBootstrapConfig ^-> IInjectorService
                Generic - fun t ->
                    "copy"              => t * Optional t ^-> t
                "element"               =? IAugmentedJQueryStatic
                "equals"                => Any * Any ^-> Bool
                "extend"                => Any *+ Any ^-> Any
                Generic - fun t ->
                    "forEach"           => ArrayOf t * (t * Number ^-> Any) * Optional Any ^-> Any
                Generic - fun t ->
                    "forEach"           => (Dictionary String t) * (t * String ^-> Any) * Optional Any ^-> Any
                "forEach"               => Any * (Any * Any ^-> Any) * Optional Any ^-> Any
                "fromJson"              => String ^-> Any
                "identity"              => Optional Any ^-> Any
                "injector"              => Optional (ArrayOf Any) ^-> IInjectorService
                "isArray"               => Any ^-> Bool
                "isDate"                => Any ^-> Bool
                "isDefined"             => Any ^-> Bool
                "isElement"             => Any ^-> Bool
                "isFunction"            => Any ^-> Bool
                "isNumber"              => Any ^-> Bool
                "isObject"              => Any ^-> Bool
                "isString"              => Any ^-> Bool
                "isUndefined"           => Any ^-> Bool
                "lowercase"             => String ^-> String
                "module"                => String * Optional (ArrayOf String) * Optional Function ^-> IModule
                "noop"                  => ParamArrayOf Any ^-> Void
                "reloadWithDebugInfo"   => Void ^-> Void
                "toJson"                => Any * Optional Bool ^-> String
                "uppercase"             => String ^-> String
                "version"               => IAngularStaticVersion  // Some creative licence used here
            ]

            Class "auto"
            |=> Nested [
                Interface "ng.auto.IInjectorService"
                |=> IAutoInjectorService
                // ...

                Interface "ng.auto.IProvideService"
                |=> IAutoProvideService
                // ...
            ]            

            Class "resource"
            |=> Nested [
                Interface "ng.resource.IResourceOptions"
                |=> IResourceOptions
                |+> [
                    "stripTrailingSlashes"  =@| Bool
                ]

                Interface "ng.resource.IResourceService"
                |=> IResourceService
                // ...
                // Unclear how to implement this signature

                Interface "ng.resource.IActionDescriptor"
                |=> IActionDescriptor
                |+> [
                    "method"                =?| String
                    "isArray"               =?| Bool
                    "params"                =?| Any
                    "headers"               =?| Any
                ]

                Generic - IResourceClassInterface
                Generic - IResourceInterface
            ]

            Class "route"
            |=> Nested [
                Class "ng.route.IRouteParamsService"
                |=> IRouteParamsService
                |+> [
                    "item"                  =@ Any |> Indexed String
                ]
            ]
            |=> Nested [
                Interface "ng.route.IRouteService"
                |=> IRouteService
                |+> [
                    "reload"                =>| Void ^-> Void
                    "routes"                =?| Any
                    "current"               =?| ICurrentRoute
                ]

                Interface "ng.route.IRoute"
                |=> IRoute
                |+> [
                    "controller"            =?| Any
                    "controllerAs"          =?| String
                    "name"                  =?| String
                    "template"              =?| String
                    "templateUrl"           =?| Any
                    "resolve"               =?| Dictionary String Any
                    "redirectTo"            =?| Any
                    "reloadOnSearch"        =?| Bool
                    "caseInsensitiveMatch"  =?| Bool
                ]

                Interface "ng.route.ICurrentRoute"
                |=> ICurrentRoute
                |=> Extends [ IRoute ]
                |+> [
                    "locals"                =?| Any // Needs proper implementation
                    "params"                =?| Any
                ]

                Interface "ng.route.IRouteProvider"
                |=> IRouteProvider
                |=> Extends [ IServiceProvider ]
                |+> [
                    "otherwise"             =>| IRoute ^-> IRouteProvider
                    "when"                  =>| String * IRoute ^-> IRouteProvider
                ]
            ]        
        ]

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
        |=> Implements [ IRoute ]

    let DirectiveConfig =
        Pattern.Config "DirectiveConfig" {
            Required = []
            Optional =
            [
                "compile", IDirectiveCompileFn
                "controller", Any
                "controllerAs", String
                "bindToController", Bool
                "link", IDirectiveLinkFn
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
        |=> Implements [ IDirective ]

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
