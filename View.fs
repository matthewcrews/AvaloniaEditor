module AvaloniaEditor.View

open Avalonia.Controls
open Avalonia.FuncUI.DSL
open AvaloniaEditor
open AvaloniaEdit

let view (state: State) dispatch =
    DockPanel.create [
        DockPanel.children [
            Menu.view ()
            TextEditor.create [
                TextEditor.showLineNumbers true
            ]
        ]
    ]
