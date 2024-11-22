module Ex8

open System
open System.Windows.Forms
open System.Drawing

type Ex8() as this =
    inherit Form(Text = "Добавление в список", Size = Size(300, 300))

    // Элементы интерфейса
    let textBox = new TextBox(Location = Point(20, 20), Width = 200)
    let button = new Button(Text = "Добавить", Location = Point(230, 18), Width = 50)
    let listBox = new ListBox(Location = Point(20, 60), Width = 260, Height = 180)

    do
        // Добавляем элементы на форму
        this.Controls.Add(textBox)
        this.Controls.Add(button)
        this.Controls.Add(listBox)

        // Обработчик события нажатия на кнопку
        button.Click.Add(fun _ ->
            let text = textBox.Text.Trim()
            if text <> "" then
                listBox.Items.Add(text) |> ignore
                textBox.Clear() // Очистить текстовое поле после добавления
            else
                MessageBox.Show("Поле ввода пустое!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning) |> ignore
        )
