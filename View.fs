module AvaloniaEditor.View

open System.Reactive.Subjects
open Avalonia.Controls
open Avalonia.FuncUI.DSL
open AvaloniaEdit

let view (subject: Subject<TextEditor>) (model: Model) (dispatch) =
    let mutable editor = Unchecked.defaultof<TextEditor>

    DockPanel.create [
        DockPanel.children [
            Menu.view ()
            TextEditor.create [
                TextEditor.init (fun newEditor ->
                    editor <- newEditor)
                TextEditor.showLineNumbers true
                TextEditor.onTextInput (fun _ ->
                    subject.OnNext editor
                )
            ]
        ]
    ]
