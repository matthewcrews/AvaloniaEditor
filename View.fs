module AvaloniaEditor.View

open Elmish
open System
open Avalonia.FuncUI.Elmish
open Avalonia.Layout
open Avalonia.Controls
open Avalonia.FuncUI
open Avalonia.FuncUI.DSL
open Avalonia.FuncUI.Types
open Avalonia.FuncUI.Elmish.ElmishHook
open System.Reactive.Subjects
open System.Reactive.Linq
open AvaloniaEdit


let private subscriptions (model: Model) : Sub<Msg> =
    let editorChangeStream (dispatch: Msg -> unit) =
        model.EditorChangeStream
            .Throttle(TimeSpan.FromSeconds 1)
            .Subscribe(fun txt ->
                dispatch IncrementCounter
            )

    [
        [ nameof editorChangeStream ], editorChangeStream
    ]


let view (model: Model) (dispatch) =
    Component (fun ctx ->
        let model, dispatch = ctx.useElmish(Model.init, Model.update, Program.withSubscription subscriptions)
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
        ])
