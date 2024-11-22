module Program

open System
open System.Windows.Forms
open System.Drawing
open MainForm

[<STAThread>]
[<EntryPoint>]
let main _ =
    let mainForm = new MainForm()
    Application.Run(mainForm)
    0
