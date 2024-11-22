module Ex4

open System
open System.Windows.Forms
open System.Drawing

type Ex4() as this =
    inherit Form(Text = "Рисунок и кнопка")

    let pictureBox = new PictureBox(Location = Point(50, 50), Size = Size(200, 200), BorderStyle = BorderStyle.FixedSingle)
    let changeButton = new Button(Text = "Сменить рисунок", Location = Point(100, 300))

    let images = [|
        "C:/Users/flytk/source/repos/Lab5/Lab5/Images/image1.png"
        "C:/Users/flytk/source/repos/Lab5/Lab5/Images/image2.png"
        "C:/Users/flytk/source/repos/Lab5/Lab5/Images/image3.png"
    |]

    let mutable currentImageIndex = 0

    let changeImage () =
        currentImageIndex <- (currentImageIndex + 1) % images.Length
        try
            pictureBox.Image <- Image.FromFile(images.[currentImageIndex])
        with
        | :? System.IO.FileNotFoundException ->
            MessageBox.Show($"Файл {images.[currentImageIndex]} не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore

    do
        this.Controls.Add(pictureBox)
        this.Controls.Add(changeButton)
        pictureBox.SizeMode <- PictureBoxSizeMode.StretchImage

    do
        changeButton.Click.Add(fun _ -> changeImage())