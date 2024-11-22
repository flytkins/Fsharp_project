module Ex5

open System
open System.Windows.Forms
open System.Drawing

type Ex5() as this =
    inherit Form(Text = "Времена года", Size = Size(300, 200))

    // Элементы интерфейса
    let comboBox = new ComboBox(DropDownStyle = ComboBoxStyle.DropDownList, Location = Point(50, 50), Width = 200)
    let button = new Button(Text = "Узнать время года", Location = Point(50, 100), Width = 200)
    let label = new Label(Text = "", Location = Point(50, 150), AutoSize = true, ForeColor = Color.DarkBlue)

    do
        // Заполнение ComboBox
        comboBox.Items.AddRange([|
            "Январь"; "Февраль"; "Март"; "Апрель"; "Май"; "Июнь";
            "Июль"; "Август"; "Сентябрь"; "Октябрь"; "Ноябрь"; "Декабрь"
        |])
        comboBox.SelectedIndex <- 0 // Установим первый элемент как выбранный

        // Добавляем элементы на форму
        this.Controls.Add(comboBox)
        this.Controls.Add(button)
        this.Controls.Add(label)

        // Логика обработки нажатия на кнопку
        button.Click.Add(fun _ ->
            let month = comboBox.SelectedItem.ToString()
            let season =
                match month with
                | "Декабрь" | "Январь" | "Февраль" -> "Зима"
                | "Март" | "Апрель" | "Май" -> "Весна"
                | "Июнь" | "Июль" | "Август" -> "Лето"
                | "Сентябрь" | "Октябрь" | "Ноябрь" -> "Осень"
                | _ -> "Неизвестный месяц"
            label.Text <- $"{month} - это {season}"
        )
