namespace AvaloniaEditor


open Avalonia
open Avalonia.Themes.Fluent
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

        let subscriptions (model: Model) : Sub<Msg> =
            let editorChangeStream (dispatch: Msg -> unit) =
                model.EditorChangeStream
                    .Throttle(TimeSpan.FromSeconds 1)
                    .Subscribe(fun txt ->
                        dispatch IncrementCounter
                    )

            [
                [ nameof editorChangeStream ], editorChangeStream
            ]

        Elmish.Program.mkProgram Model.init Model.update View.view
        |> Program.withHost this
        |> Program.withConsoleTrace
        |> Program.withSubscription subscriptions
        |> Program.run

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
