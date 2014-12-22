namespace ellipsoid.org.SharpAngles

open ellipsoid.org.SharpAngles.Common
open ellipsoid.org.SharpAngles.Resources
open IntelliFactory.WebSharper.InterfaceGenerator

module Definition =

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
    let SceDelegateProvider = Type.New ()
    let SceDelegateService = Type.New ()
    let SceProvider = Type.New ()
    let SceService = Type.New ()
    let ServiceProvider = Type.New ()
    let TemplateCacheService = Type.New ()
    let TemplateLinkingFunction = Type.New ()
    let TemplateRequestService = Type.New ()
    let TimeoutService = Type.New ()
    let TranscludeFunction = Type.New ()
    let WindowService = Type.New ()

    (*
        Type definitions: mocks
        =======================
    *)

    let ExceptionHandlerProvider = Type.New ()
    let MockStatic = Type.New ()
    let RequestHandler = Type.New ()

    (*
        Type definitions: resource
        ==========================
    *)

    let ActionDescriptor = Type.New ()
    let Array = Type.New ()
    let _ResourceClass = Type.New ()
    let Resource = Type.New ()
    let ResourceArray = Type.New ()
    let ResourceFactory = Type.New ()
    let ResourceOptions = Type.New ()
    let ResourceService = Type.New ()

    (*
        Type definitions: route
        =======================
    *)

    let CurrentRoute = Type.New ()
    let CurrentRouteLocals = Type.New ()
    let Route = Type.New ()
    let RouteProvider = Type.New ()
    let RouteService = Type.New ()

    (*
        Generic definitions: core
        =========================
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

    (*
        Generic definitions: resource
        =============================
    *)

    let ResourceArrayClass =
        Generic / fun t ->
            Class "ng.resource.ResourceArray"
            |=> ResourceArray
            // ...

    let ResourceClass =
        Generic / fun t ->
            let successCallbackType = Optional (Void ^-> Void)?success
            let errorCallbackType = Optional (Void ^-> Void)?error
            let resClass name returnType =
                [
                    name            =>| Void ^-> PromiseClass returnType :> CodeModel.Member
                    name            =>| successCallbackType * Optional errorCallbackType ^-> returnType :> CodeModel.Member
                    name            =>| Object?``params`` * Optional successCallbackType * Optional errorCallbackType ^-> PromiseClass returnType :> CodeModel.Member
                ]
            let classDef =
                [ "$get"; "$query"; "$save"; "$remove"; "$delete" ]
                |> List.map (fun e ->
                    match e with
                        | s when s <> "query" -> resClass s (PromiseClass t)
                        | s -> resClass s (PromiseClass (ResourceArrayClass t))
                )
                |> List.collect (fun e -> e)

            Class "ng.resource.Resource"
            |=> Resource
            |+> Protocol classDef

    let ResourceClassClass =
        Generic / fun t ->
            let successCallbackType = (Void ^-> Void)?success
            let errorCallbackType = Optional (Void ^-> Void)?error
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
                [ "get"; "query"; "save"; "remove"; "delete" ]
                |> List.map (fun e ->
                    match e with
                        | s when s <> "query" -> resClass s t
                        | s -> resClass s (ResourceArrayClass t)
                )
                |> List.collect (fun e -> e)

            Class "ng.resource.ResourceClass"
            |=> _ResourceClass
            |+> [] // TODO: implement new(..)
            |+> Protocol classDef

    let ResourceFactoryClass =
        Generic / fun t ->
            Class "ng.resource.ResourceFactory"
            |=> ResourceFactory
            |+> Protocol [
                "create"                => String?url ^-> ResourceClassClass t
                |> WithInline "$this($url)"
                "create"                => String?url * Any?paramDefaults ^-> ResourceClassClass t
                |> WithInline "$this($url, $paramDefaults)"
                "create"                => String?url * Any?paramDefaults * Any?actions ^-> ResourceClassClass t
                |> WithInline "$this($url, $paramDefaults, $actions)"
                "create"                => String?url * Any?paramDefaults * Any?actions * ResourceOptions?options ^-> ResourceClassClass t
                |> WithInline "$this($url, $paramDefaults, $actions, $options)"
            ]
            
    (*
        Angular definitions: core
        =========================
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

            // angular-mocks extensions
            "mock"                  =? MockStatic
        ]

    let AngularStaticVersionClass =
        Class "ng.AngularStaticVersion"
        |=> AngularStaticVersion
        |+> Protocol [
            "full"                  =? String
            "major"                 =? Number
            "minor"                 =? Number
            "dot"                   =? Number
            "codeName"              =? String
        ]

    let AttributesClass =
        Class "ng.Attributes"
        |=> Attributes
        // ...

    let FormControllerClass =
        Class "ng.FormController"
        |=> FormController
        // ...

    let HttpBackendServiceClass =
        Class "ng.HttpBackendService"
        |=> HttpBackendService
        |+> Protocol [
            // angular-mocks extensions
            "flush"                             => Optional Number?count ^-> Void
            "resetExpectations"                 => Void ^-> Void
            "verifyNoOutstandingExpectation"    => Void ^-> Void
            "verifyNoOutstandingRequest"        => Void ^-> Void
            // ...
        ]

    let IntervalServiceClass =
        Class "ng.IntervalService"
        |=> IntervalService
        |+> Protocol [
            // angular-mocks extensions
            "flush"                 => Optional Number?millis ^-> Number
        ]

    let LogCallClass =
        Class "ng.LogCall"
        |=> LogCall
        |+> Protocol [
            // angular-mocks extensions
            "logs"                  =? ArrayOf String
        ]

    let LogServiceClass =
        Class "ng.LogService"
        |=> LogService
        |+> Protocol [
            // angular-mocks extensions
            "assertEmpty"           => Void ^-> Void
            "reset"                 => Void ^-> Void
        ]

    let LocationProviderClass =
        Class "ng.LocationProvider"
        |=> Inherits ServiceProvider
        |=> LocationProvider
        |+> Protocol [
            "hashPrefix"            => Void ^-> String
            "hashPrefix"            => String?prefix ^-> LocationProvider
            "html5Mode"             => Void ^-> Bool
            "html5Mode"             => Bool?active ^-> LocationProvider
        ]

    let LocationServiceClass =
        Class "ng.LocationService"
        |=> LocationService
        |+> Protocol [
            "absUrl"                => Void ^-> String
            "hash"                  => Void ^-> String
            "hash"                  => String?newHash ^-> LocationService
            "host"                  => Void ^-> String
            "path"                  => Void ^-> String
            "path"                  => String?path ^-> LocationService
            "port"                  => Void ^-> Number
            "protocol"              => Void ^-> String
            "replace"               => Void ^-> LocationService
            "search"                => Void ^-> Any
            "search"                => Any?search ^-> LocationService
            "search"                => String?search * (String + Number + ArrayOf String + Bool)?paramValue ^-> LocationService
            "state"                 => Void ^-> Any
            "state"                 => Any?state ^-> LocationService
            "url"                   => Void ^-> String
            "url"                   => String?url ^-> LocationService
        ]

    let LocaleServiceClass =
        Class "ng.LocaleService"
        |=> LocaleService
        |+> Protocol [
            "id"                    =? String
            "NUMBER_FORMATS"        =? LocaleNumberFormatDescriptor
            "DATETIME_FORMATS"      =? LocaleDateTimeFormatDescriptor
            "pluralCat"             =? Any ^-> String
        ]

    let ModuleClass =
        let resourceLhs = String?url * Optional Any?paramDefaults * Optional Any?actions * Optional ResourceOptions?options

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
                "factory"           => String?name * ((resourceLhs ^-> (t + ResourceClassClass t + ResourceClassClass (ResourceClass t)))?``$resource`` ^-> ResourceClassClass t)?resourceServiceFactoryFunction ^-> Module     // Imported from angular-resource (method signature questionable)
            // Generic - fun t ->
            //     "factory"           => String * (ResourceService ^-> t) ^-> Module                  // Imported from angular-resource (method signature questionable); probably not necessary because of generic above
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

    let RootScopeServiceClass =
        Class "ng.RootScopeService"
        |=> RootScopeService
        |+> Protocol [
            "item"                  =@ Any |> Indexed String
            "$apply"                =>| Void ^-> Any
            "$apply"                =>| String?exp ^-> Any
            "$apply"                =>| (Scope?scope ^-> Any)?exp ^-> Any
            "$applyAsync"           =>| Void ^-> Any
            "$applyAsync"           =>| String?exp ^-> Any
            "$applyAsync"           =>| (Scope?scope ^-> Any)?exp ^-> Any
            "$broadcast"            =>| String?name *+ Any ^-> AngularEvent
            "$destroy"              =>| Void ^-> Void
            "$digest"               =>| Void ^-> Void
            "$emit"                 =>| String?name *+ Any ^-> AngularEvent
            "$eval"                 =>| Void ^-> Any
            "$eval"                 =>| String?expression * Optional Object?locals ^-> Any
            "$eval"                 =>| (Scope?scope ^-> Any)?expression * Optional Object?locals ^-> Any
            "$evalAsync"            =>| Void ^-> Any
            "$evalAsync"            =>| String?expression * Optional Object?locals ^-> Any
            "$evalAsync"            =>| (Scope?scope ^-> Any)?expression * Optional Object?locals ^-> Any
            "$new"                  =>| Optional Bool?isolate * Optional Scope?parent ^-> Scope
            "$on"                   =>| String?name * (AngularEvent?event *+ Any ^-> Any)?listener ^-> Function
            "$watch"                =>| (String + (Scope?scope ^-> Any))?watchExpression * Optional (String + (Any?newValue * Any?oldValue * Scope?scope ^-> Any))?listener * Optional Bool?objectEquality ^-> Function
            "$watchCollection"      =>| (String + (Scope?scope ^-> Any))?watchExpression * (Any?newValue * Any?oldValue * Scope?scope ^-> Any)?listener ^-> Function
            "$watchGroup"           =>| ArrayOf Any * (Any?newValue * Any?oldValue * Scope?scope ^-> Any)?listener ^-> Function      // Has another override but it (?) amounts to the same thing
            "$parent"               =?| Scope
            "$root"                 =?| RootScopeService
            "$id"                   =?| Number
            "$$isolateBindings"     =?| Any
            "$$phase"               =?| Any
        ]

    let SceDelegateProviderClass =
        Class "ng.SCEDelegateProvider"
        |=> Inherits ServiceProvider
        |=> SceDelegateProvider
        |+> Protocol [
            "resourceUrlBlacklist"  => (ArrayOf Any)?blacklist ^-> Void
            "resourceUrlWhitelist"  => (ArrayOf Any)?whitelist ^-> Void
        ]

    let SceDelegateServiceClass =
        Class "ng.SCEDelegateService"
        |=> SceDelegateService
        |+> Protocol [
            "getTrusted"            => String?``type`` * Any?mayBeTrusted ^-> Any
            "trustAs"               => String?``type`` * Any?value ^-> Any
            "valueOf"               => Any?value ^-> Any
        ]

    let SceProviderClass =
        Class "ng.SCEProvider"
        |=> Inherits ServiceProvider
        |=> SceProvider
        |+> Protocol [
            "enabled"               => Bool?value ^-> Void
        ]

    let SceServiceClass =
        let simplify baseName ofType =
            [ "Css"; "Html"; "Js"; "ResourceUrl"; "Url" ]
            |> List.map (fun e -> baseName + e => ofType :> CodeModel.Member)
        Class "ng.SCEService"
        |=> SceService
        |+> Protocol [
            "getTrusted"            => String?``type`` * Any?mayBeTrusted ^-> Any
            "parse"                 => String?``type`` * String?expression ^-> (Any?context * Any?locals ^-> Any)
            "trustAs"               => String?``type`` * Any?value ^-> Any
            "isEnabled"             => Void ^-> Bool
        ]
        |+> Protocol (simplify "getTrusted" (Any?value ^-> Any))
        |+> Protocol (simplify "parseAs" (String?expression ^-> (Any?context * Any?locals ^-> Any)))
        |+> Protocol (simplify "trustAs" (Any?value ^-> Any))

    let ScopeClass =
        Class "ng.Scope"
        |=> Inherits RootScopeService
        |=> Scope

    let ServiceProviderClass =
        Class "ng.ServiceProvider"
        |=> ServiceProvider
        |+> Protocol [
            "$get"                   =?| Any
        ]

    let TimeoutServiceClass =
        Class "ng.TimeoutService"
        |=> TimeoutService
        |+> Protocol [
            // angular-mocks extensions
            "flush"                 => Optional Number?delay ^-> Void
            "flushNext"             => Optional Number?expectedDelay ^-> Void
            "verifyNoPendingTasks"  => Void ^-> Void
        ]

    let InjectorServiceClass =
        Class "ng.auto.InjectorService"
        |=> AutoInjectorService
        // ...

    let ProvideServiceClass =
        Class "ng.auto.ProvideService"
        |=> AutoProvideService
        // ...

    (*
        Angular definitions: mocks
        ==========================
    *)

    let ExceptionHandlerProviderClass =
        Class "ng.ExceptionHandlerProvider"
        |=> Inherits ServiceProvider
        |=> ExceptionHandlerProvider
        |+> [
            "mode"                  => String?mode ^-> Void
        ]

    let MockStaticClass =
        Class "ng.MockStatic"
        |=> MockStatic
        |+> Protocol [
            "dump"                  => Any?obj ^-> String
            "inject"                => ParamArrayOf Function ^-> Any
            "inject"                => ParamArrayOf Any ^-> Any
            "module"                => ParamArrayOf Any ^-> Any
            "TzDate"                => Number?offset * (Number + String)?timestamp ^-> Date
        ]

    let RequestHandlerClass =
        Class "ng.mocks.RequestHandler"
        |=> RequestHandler
        |+> Protocol [
            "respond"               => Function?func ^-> Void
            "respond"               => Any?data * Optional Any?headers ^-> Void
            "respond"               => Number?status * Optional Any?data * Optional Any?headers ^-> Void
            "passThrough"           => Void ^-> Void
        ]

    (*
        Angular definitions: resource
        =============================
    *)

    let ActionDescriptorClass =
        Class "ng.resource.ActionDescriptor"
        |=> ActionDescriptor
        |+> Protocol [
            "method"                =? String
            "isArray"               =? Bool
            "params"                =? Any
            "headers"               =? Any
        ]

    let ResourceOptionsClass =
        Class "ng.resource.ResourceOptions"
        |=> ResourceOptions
        |+> Protocol [
            "stripTrailingSlashes"  =@ Bool
        ]

    (*
        Angular definitions: route
        ==========================
    *)

    let CurrentRouteClass =
        Class "ng.route.CurrentRoute"
        |=> CurrentRoute
        |=> Inherits Route
        |+> Protocol [
            "locals"                =? CurrentRouteLocals
            "params"                =? Any
        ]

    let CurrentRouteLocalsClass =
        Class "ng.route.CurrentRouteLocals"
        |=> CurrentRouteLocals
        |+> Protocol [
            "$scope"                =?| Scope
            "$template"             =?| String
        ]

    let RouteClass =
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

    let RouteProviderClass =
        Class "ng.route.RouteProvider"
        |=> RouteProvider
        |=> Inherits ServiceProvider
        |+> Protocol [
            "otherwise"             => Route?``params`` ^-> RouteProvider
            "when"                  => String?path * Route?route ^-> RouteProvider
        ]

    let RouteServiceClass =
        Class "ng.route.RouteService"
        |=> RouteService
        |+> Protocol [
            "reload"                => Void ^-> Void
            "routes"                =? Any
            "current"               =? CurrentRoute
        ]

    (*
        Configuration objects: core
        ===========================
    *)

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

    (*
        Configuration objects: resource
        ===============================
    *)

    let ResourceOptionsConfig =
        Pattern.Config "ResourceOptionsConfig" {
            Required = []
            Optional =
            [
                "stripTrailingSlashes", Bool
            ]
        }
        |=> Inherits ResourceOptions

    (*
        Configuration objects: route
        ============================
    *)

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
                AngularBootstrapConfigConfig
                DirectiveConfig
            ]
            Namespace "ellipsoid.org.SharpAngles" [
                AngularStaticVersionClass
                AttributesClass
                FormControllerClass
                Generic - HttpPromiseClass
                HttpBackendServiceClass
                IntervalServiceClass
                ModuleClass
                LocationProviderClass
                LocationServiceClass
                LocaleServiceClass
                LogCallClass
                LogServiceClass
                Generic - PromiseClass
                RootScopeServiceClass
                SceDelegateProviderClass
                SceDelegateServiceClass
                SceProviderClass
                SceServiceClass
                ScopeClass
                ServiceProviderClass
                TimeoutServiceClass

                // angular-mocks extensions
                ExceptionHandlerProviderClass
                MockStaticClass
            ]
            Namespace "ellipsoid.org.SharpAngles.Auto" [
                InjectorServiceClass
                ProvideServiceClass
            ]
            Namespace "ellipsoid.org.SharpAngles.Mock" [
                RequestHandlerClass
            ]
            Namespace "ellipsoid.org.SharpAngles.Resource" [
                ActionDescriptorClass
                Generic - ResourceClassClass
                Generic - ResourceClass
                Generic - ResourceFactoryClass
                ResourceOptionsClass
            ]
            Namespace "ellipsoid.org.SharpAngles.Route" [
                 CurrentRouteClass
                 RouteClass
                 RouteProviderClass
                 RouteServiceClass

                 // Configuration objects
                 RouteConfig
            ]
            Namespace "ellipsoid.org.SharpAngles.Resources" [
                AngularJs
                AngularJsResource
                AngularJsRoute
            ]
        ]
        |> Requires [ AngularJs; AngularJsMocks; AngularJsResource; AngularJsRoute ]

open IntelliFactory.WebSharper.InterfaceGenerator

[<Sealed>]
type Extension() =
    interface IExtension with
        member ext.Assembly =
            Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
