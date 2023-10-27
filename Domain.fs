namespace AvaloniaEditor

type State = {
    Items: string list
}

type Msg =
    | Hello of string

module State =

    let init () =
        {
            Items = []
        }

    let update (msg: Msg) (s: State) = s
