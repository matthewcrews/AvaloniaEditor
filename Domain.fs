namespace AvaloniaEditor

open AvaloniaEdit

type Model =
    {
        Text: string
        Counter: int
    }

type Msg =
    | ApplyChanges of TextEditor
    | IncrementCounter

module Model =

    let init() =
        {
            Text = ""
            Counter = 0
        }

    let update msg model =
        match msg with
        | ApplyChanges textEditor ->
                { model with Text = textEditor.Text }
        | IncrementCounter ->
            { model with Counter = model.Counter + 1 }
