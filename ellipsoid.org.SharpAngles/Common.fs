namespace ellipsoid.org.SharpAngles

open IntelliFactory.WebSharper.Dom
open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

module Common =

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