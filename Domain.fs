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
        EditorChangeStream: Subject<string>
    }

type Msg =
    | EditorChanged of TextEditor
    | IncrementCounter

module Model =

    let init() =
        {
            Text = ""
            Counter = 0
            EditorChangeStream = new Subject<string>()
        }, Cmd.none

    let update msg model =
        match msg with
        | EditorChanged textEditor ->
            { model with Text = textEditor.Text },
                Cmd.ofEffect (fun _ -> model.EditorChangeStream.OnNext(textEditor.Text))
        | IncrementCounter ->
            { model with Counter = model.Counter + 1 }, Cmd.none
