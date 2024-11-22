module Form2

open System.Windows.Forms
open System.Drawing

type Form2() as this =
    inherit Form(Text = "Форма 2", Width = 300, Height = 200)

    do
        let label = new Label(Text = "Это Форма 2", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter)
        this.Controls.Add(label)