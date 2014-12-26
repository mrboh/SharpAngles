#r "../packages/NuGet.Core.2.8.1/lib/net40-Client/NuGet.Core.dll"
#r "../packages/IntelliFactory.Core.0.2.51.66-alpha/lib/net40/IntelliFactory.Core.dll"
#r "../packages/IntelliFactory.Build.0.2.53.66-alpha/lib/net45/IntelliFactory.Build.dll"

open IntelliFactory.Build

let bt = BuildTool().PackageId("SinglePageApplication", "0.1-alpha")

let myBundleWebsite =
    bt.WebSharper.BundleWebsite("SinglePageApplication")
        .SourcesFromProject()

bt.Solution [
    myBundleWebsite
]
|> bt.Dispatch