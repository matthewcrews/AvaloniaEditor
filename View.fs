module AvaloniaEditor.View

open System.Timers
open Avalonia.Controls
open Avalonia.FuncUI
open Avalonia.FuncUI.DSL
open AvaloniaEditor
open AvaloniaEdit

let view (state: State) (dispatch: Msg -> State -> State) =
    let mutable editor = Unchecked.defaultof<TextEditor>

    DockPanel.create [
        DockPanel.children [
            Menu.view ()
            Component.create ("text editor", fun ctx ->
                let timer =
                    ctx.useState (
                        initialValue = (
                            let timer = new Timer(Interval = 1_000, AutoReset = false)
                            timer.Elapsed.Add (fun _ ->
                                let editorText = editor.Text
                                dispatch (Msg.NewText editorText) state
                            )
                            timer
                        ),
                        renderOnChange = false
                    )

                TextEditor.create [
                    TextEditor.init (fun newEditor ->
                        editor <- newEditor)
                    TextEditor.showLineNumbers true
                    TextEditor.onTextInput (fun _ ->
                        timer.Current.Interval <- 1_000.0
                        timer.Current.Start()
                    )
                ])
        ]
    ]
