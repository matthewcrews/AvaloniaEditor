module AvaloniaEditor.Menu

open System
open Avalonia.Layout
open Avalonia.Controls
open Avalonia.FuncUI.DSL

let view () =
    Menu.create [
        Menu.dock Dock.Top
        Menu.horizontalAlignment HorizontalAlignment.Left
        Menu.viewItems [
            // File menu
            MenuItem.create [
                MenuItem.header "File"
                MenuItem.viewItems [
                    MenuItem.create [
                        MenuItem.header "New"
                    ]
                    MenuItem.create [
                        MenuItem.header "Open File"
                    ]
                    MenuItem.create [
                        MenuItem.header "Save"
                    ]
                    MenuItem.create [
                        MenuItem.header "Save As"
                    ]
                    MenuItem.create [
                        MenuItem.header "Close"
                    ]
                ]
            ]
            // Edit menu
            MenuItem.create [
                MenuItem.header "Edit"
                MenuItem.viewItems [
                    MenuItem.create [
                        MenuItem.header "Undo"
                    ]
                    MenuItem.create [
                        MenuItem.header "Redo"
                    ]
                ]
            ]
            // View menu
            MenuItem.create [
                MenuItem.header "View"
                MenuItem.viewItems [
                    MenuItem.create [
                        MenuItem.header "Zoom In"
                    ]
                    MenuItem.create [
                        MenuItem.header "Zoom Out"
                    ]
                ]
            ]
            // View menu
            MenuItem.create [
                MenuItem.header "Setup"
                MenuItem.viewItems [
                    MenuItem.create [
                        MenuItem.header "Zoom In"
                    ]
                    MenuItem.create [
                        MenuItem.header "Zoom Out"
                    ]
                ]
            ]
        ]
    ]
