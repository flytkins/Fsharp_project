module Ex6

open System
open System.Windows.Forms
open System.Drawing

type Ex6() as this =
    inherit Form(Text = "Изменение ширины кнопки", Size = Size(400, 200))

    // Элементы интерфейса
    let trackBar = new TrackBar(Location = Point(50, 50), Width = 300)
    let button = new Button(Text = "Изменяемая кнопка", Location = Point(50, 100), Size = Size(100, 30))

    do
        // Настройка трекбара
        trackBar.Minimum <- 50    // Минимальная ширина кнопки
        trackBar.Maximum <- 300  // Максимальная ширина кнопки
        trackBar.Value <- button.Width // Установим начальное значение трекбара

        // Добавляем элементы на форму
        this.Controls.Add(trackBar)
        this.Controls.Add(button)

        // Событие изменения значения трекбара
        trackBar.Scroll.Add(fun _ ->
            button.Width <- trackBar.Value
        )
