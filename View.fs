module AvaloniaEditor.View

open Avalonia.Controls
open Avalonia.FuncUI.DSL
open AvaloniaEdit

let view (model: Model) (dispatch) =
    let mutable editor = Unchecked.defaultof<TextEditor>

    DockPanel.create [
        DockPanel.children [
            Menu.view ()
            TextEditor.create [
                TextEditor.init (fun newEditor ->
                    editor <- newEditor)
                TextEditor.showLineNumbers true
                TextEditor.onTextInput (fun _ ->
                    dispatch (EditorChanged editor)
                )
            ]
        ]
    ]
