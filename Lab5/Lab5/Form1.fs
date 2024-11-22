module Form1

open System.Windows.Forms
open System.Drawing

type Form1() as this =
    inherit Form(Text = "Форма 1", Width = 300, Height = 200)

    do
        let label = new Label(Text = "Это Форма 1", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter)
        this.Controls.Add(label)