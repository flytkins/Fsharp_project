module Ex7

open System
open System.Windows.Forms
open System.Drawing

type Ex7() as this =
    inherit Form(Text = "Флажки и кнопка", Size = Size(300, 200))

    // Элементы интерфейса
    let checkBox1 = new CheckBox(Text = "Первый флажок", Location = Point(50, 50), AutoSize = true)
    let checkBox2 = new CheckBox(Text = "Второй флажок", Location = Point(50, 80), AutoSize = true)
    let button = new Button(Text = "Проверить флажки", Location = Point(50, 120), Width = 200)

    do
        // Добавляем элементы на форму
        this.Controls.Add(checkBox1)
        this.Controls.Add(checkBox2)
        this.Controls.Add(button)

        // Обработчик события нажатия на кнопку
        button.Click.Add(fun _ ->
            let message =
                match checkBox1.Checked, checkBox2.Checked with
                | true, false -> "Установлен первый флажок"
                | false, true -> "Установлен второй флажок"
                | true, true -> "Установлены оба флажка"
                | false, false -> "Флажки не установлены"
            MessageBox.Show(message, "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information) |> ignore
        )
