namespace AvaloniaEditor

open System
open AvaloniaEdit
open Elmish
open System.Reactive.Subjects
open Avalonia.FuncUI

type Model =
    {
        Text: string
        Counter: int
        EditorChangeStream: Subject<TextEditor>
    }

type Msg =
    | EditorChanged of TextEditor
    | ApplyChanges of TextEditor
    | IncrementCounter

module Model =

    let init() =
        {
            Text = ""
            Counter = 0
            EditorChangeStream = new Subject<TextEditor>()
        }, Cmd.none

    let update msg model =
        match msg with
        | EditorChanged textEditor ->
            { model with Counter = model.Counter + 1 },
                Cmd.ofEffect (fun _ -> model.EditorChangeStream.OnNext(textEditor))
        | ApplyChanges textEditor ->
                { model with Text = textEditor.Text },
                    Cmd.none
        | IncrementCounter ->
            { model with Counter = model.Counter + 1 },
                Cmd.none
