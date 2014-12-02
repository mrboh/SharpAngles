namespace ellipsoid.org.SharpAngles

open IntelliFactory.WebSharper.Dom
open IntelliFactory.WebSharper.EcmaScript
open IntelliFactory.WebSharper.InterfaceGenerator
open IntelliFactory.WebSharper.JQuery

module Common =

    (*
        Helper definitions
        ==================
    *)

    let Any = T<obj>
    let Bool = T<bool>
    let Date = T<Date>
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

    let dollarToCapitalised s =
        let capitaliser firstLetter remainder =
            firstLetter.ToString().ToUpper() + new string [| for c in remainder -> c |]
        match (s |> Seq.toList) with
            | '$' :: '$' :: firstLetter :: remainder -> capitaliser firstLetter remainder
            | '$' :: firstLetter :: remainder -> capitaliser firstLetter remainder
            | _ -> s

    // Operators to turn a dollarised function/property name (e.g. $get) into a capitalised .NET name (e.g. Get)
    let (=>|) x y = x => y |> WithSourceName (dollarToCapitalised x)
    let (=?|) x y = x =? y |> WithSourceName (dollarToCapitalised x)
    let (=!|) x y = x =! y |> WithSourceName (dollarToCapitalised x)
    let (=@|) x y = x =@ y |> WithSourceName (dollarToCapitalised x)