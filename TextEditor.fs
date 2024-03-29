[<AutoOpen>]
module AvaloniaEditor.TextEditor

open Avalonia.FuncUI.Builder
open Avalonia.FuncUI.DSL
open Avalonia.FuncUI.Types
open AvaloniaEdit


module TextEditor =

    let create (attrs: IAttr<TextEditor> list): IView<TextEditor> =
        ViewBuilder.Create<TextEditor>(attrs)


type TextEditor with

    static member width<'t when 't :> TextEditor> (value: float) : IAttr<'t> =
        AttrBuilder<'t>.CreateProperty<float>(
            property = TextEditor.WidthProperty,
            value = value,
            comparer = ValueNone
        )

    static member height<'t when 't :> TextEditor> (value: float) : IAttr<'t> =
        AttrBuilder<'t>.CreateProperty<float>(
            property = TextEditor.HeightProperty,
            value = value,
            comparer = ValueNone
        )

    static member showLineNumbers<'t when 't :> TextEditor> (value: bool) : IAttr<'t> =
        AttrBuilder<'t>.CreateProperty<bool>(
            property = TextEditor.ShowLineNumbersProperty,
            value = value,
            comparer = ValueNone
        )
