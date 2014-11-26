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
    let IHttpPromiseCallback = Type.New ()
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
        Type definitions: route
        =======================
    *)

    let IRouteParamsService = Type.New ()
    let IRouteService = Type.New ()
    let IRoute = Type.New ()
    let ICurrentRoute = Type.New ()
    let IRouteProvider = Type.New ()

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

        ]
        |=> Nested [    // Cannot nest both classes an interfaces together above (huh?)
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

            Class "ng.auto"
            |=> Nested [
                Interface "ng.auto.IInjectorService"
                |=> IAutoInjectorService
                // ...

                Interface "ng.auto.IProvideService"
                |=> IAutoProvideService
                // ...
            ]            

            Class "route"
            |=> Nested [
                Interface "ng.route.IRouteParamsService"
                |=> IRouteParamsService
                // ...

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

    let Assembly =
        Assembly [
            Namespace "ellipsoid.org.SharpAngles" [
                Angular

                // Configuration objects
                RouteConfig
            ]
            Namespace "ellipsoid.org.SharpAngles.Resources" [
                AngularJs
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
