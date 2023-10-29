namespace AvaloniaEditor


open System.Reactive.Subjects
open Avalonia
open Avalonia.Themes.Fluent
open Avalonia.Threading
open AvaloniaEdit
open Elmish
open Avalonia.FuncUI.Hosts
open Avalonia.FuncUI
open Avalonia.FuncUI.Elmish
open Avalonia.Controls.ApplicationLifetimes
open System
open System.Reactive.Linq

type MainWindow() as this =
    inherit HostWindow()
    do
        base.Title <- "Avalonia Editor"
        base.Height <- 600.0
        base.Width <- 800.0

        let editorChangeStream = new Subject<TextEditor>()

        let subscriptions (model: Model) : Sub<Msg> =
            let editorChangeStream (dispatch: Msg -> unit) =
                editorChangeStream
                    .Throttle(TimeSpan.FromSeconds 1)
                    .Subscribe(fun (editor: TextEditor) ->
                        dispatch (ApplyChanges editor)
                    )

            [
                [ nameof editorChangeStream ], editorChangeStream
            ]

        Elmish.Program.mkSimple Model.init Model.update (View.view editorChangeStream)
        |> Program.withHost this
        |> Program.withConsoleTrace
        |> Program.withSubscription subscriptions
        |> Program.runWithAvaloniaSyncDispatch ()

type App() =
    inherit Application()

    override this.Initialize() =
        this.Styles.Add (FluentTheme())
        this.Styles.Load "avares://AvaloniaEdit/Themes/Fluent/AvaloniaEdit.xaml"
        // this.RequestedThemeVariant <- Styling.ThemeVariant.Light

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            let mainWindow = MainWindow()
            desktopLifetime.MainWindow <- mainWindow
        | _ -> ()


module Program =

    [<EntryPoint>]
    let main (args: string[]) =
        AppBuilder
            .Configure<App>()
            .UsePlatformDetect()
            .StartWithClassicDesktopLifetime(args)
