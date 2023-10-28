namespace AvaloniaEditor

open Avalonia.FuncUI

type State = {
    Text: string option
}

type Msg =
    | NewText of string

module State =

    let init () =
        {
            Text = None
        }

    let update (msg: Msg) (state: State) : State =

        match msg with
        | Msg.NewText newText ->
            { state with
                Text = Some newText }
