module Ex9

open System
open System.Windows.Forms
open System.Drawing

type Ex9() as this =
    inherit Form(Text = "Индикатор ввода текста", Size = Size(400, 200))

    // Элементы интерфейса
    let textBox = new TextBox(Location = Point(20, 30), Width = 350)
    let progressBar = new ProgressBar(Location = Point(20, 70), Width = 350)

    do
        // Настройка ProgressBar
        progressBar.Minimum <- 0
        progressBar.Maximum <- 100 // Максимальное значение индикатора (в процентах)
        progressBar.Value <- 0

        // Добавляем элементы на форму
        this.Controls.Add(textBox)
        this.Controls.Add(progressBar)

        // Обработчик события ввода текста
        textBox.TextChanged.Add(fun _ ->
            let textLength = textBox.Text.Length
            let maxTextLength = 50 // Задаём максимально допустимое количество символов
            let progressValue = 
                if textLength >= maxTextLength then 
                    maxTextLength
                else 
                    textLength
            progressBar.Value <- (progressValue * 100) / maxTextLength
        )
