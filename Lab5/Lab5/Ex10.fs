module Ex10

open System
open System.Windows.Forms
open System.Drawing

type Ex10() as this =
    inherit Form(Text = "Площадь прямоугольника", Size = Size(300, 200))

    // Элементы интерфейса
    let lengthLabel = new Label(Text = "Длина:", Location = Point(20, 20), AutoSize = true)
    let widthLabel = new Label(Text = "Ширина:", Location = Point(20, 60), AutoSize = true)
    let lengthTextBox = new TextBox(Location = Point(100, 20), Width = 150)
    let widthTextBox = new TextBox(Location = Point(100, 60), Width = 150)
    let calculateButton = new Button(Text = "Вычислить", Location = Point(20, 100), Width = 230)
    let resultLabel = new Label(Text = "Площадь: ", Location = Point(20, 140), AutoSize = true)

    do
        // Добавляем элементы на форму
        this.Controls.Add(lengthLabel)
        this.Controls.Add(widthLabel)
        this.Controls.Add(lengthTextBox)
        this.Controls.Add(widthTextBox)
        this.Controls.Add(calculateButton)
        this.Controls.Add(resultLabel)

        // Обработчик события нажатия на кнопку
        calculateButton.Click.Add(fun _ ->
            try
                // Преобразуем текст в числа
                let length = Convert.ToDouble(lengthTextBox.Text)
                let width = Convert.ToDouble(widthTextBox.Text)

                if length > 0.0 && width > 0.0 then
                    let area = length * width
                    resultLabel.Text <- sprintf "Площадь: %.2f" area
                else
                    MessageBox.Show("Введите положительные числа для длины и ширины!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning) |> ignore
            with
            | :? FormatException ->
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error) |> ignore
        )
