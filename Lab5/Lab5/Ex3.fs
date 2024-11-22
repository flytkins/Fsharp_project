module Ex3

open System
open System.Windows.Forms
open System.Drawing

type Ex3() as this =
    inherit Form(Text = "Калькулятор")
    // Элементы интерфейса
    let labelNum1 = new Label(Text = "Число 1:", Location = Point(10, 20))
    let textBoxNum1 = new TextBox(Location = Point(100, 20), Width = 150, TextAlign = HorizontalAlignment.Right)

    let labelNum2 = new Label(Text = "Число 2:", Location = Point(10, 60))
    let textBoxNum2 = new TextBox(Location = Point(100, 60), Width = 150, TextAlign = HorizontalAlignment.Right)

    let addButton = new Button(Text = "Сложить", Location = Point(10, 100), Width = 75)
    let subtractButton = new Button(Text = "Вычесть", Location = Point(100, 100), Width = 75)
    let multiplyButton = new Button(Text = "Умножить", Location = Point(190, 100), Width = 75)
    let divideButton = new Button(Text = "Разделить", Location = Point(10, 140), Width = 75)

    let resultBox = new RichTextBox(Location = Point(10, 180), Width = 260, Height = 100)

    // Добавление элементов на форму
    do
        this.Controls.AddRange([|
            labelNum1; textBoxNum1
            labelNum2; textBoxNum2
            addButton; subtractButton; multiplyButton; divideButton
            resultBox
        |])

    // Метод для выполнения вычислений
    let calculate (num1: float) (num2: float) (operation: string) =
        match operation with
        | "Сложить" -> num1 + num2
        | "Вычесть" -> num1 - num2
        | "Умножить" -> num1 * num2
        | "Разделить" ->
            if num2 = 0.0 then
                raise (DivideByZeroException("Ошибка: деление на ноль!"))
            else
                num1 / num2
        | _ -> 0.0

    // Обработчик ошибок
    let handleError (ex: Exception) =
        match ex with
        | :? FormatException -> resultBox.Text <- "Ошибка: введите корректные числа."
        | :? DivideByZeroException -> resultBox.Text <- "Ошибка: деление на ноль!"
        | _ -> resultBox.Text <- "Неизвестная ошибка."

    // Обработчик кнопки для вычисления
    let performCalculation operation =
        try
            let num1 = Convert.ToDouble(textBoxNum1.Text)
            let num2 = Convert.ToDouble(textBoxNum2.Text)
            let result = calculate num1 num2 operation
            resultBox.Text <- $"Результат: {result}"
        with
        | ex -> handleError ex

    // Добавление обработчиков для каждой кнопки
    do
        addButton.Click.Add(fun _ -> performCalculation "Сложить")
        subtractButton.Click.Add(fun _ -> performCalculation "Вычесть")
        multiplyButton.Click.Add(fun _ -> performCalculation "Умножить")
        divideButton.Click.Add(fun _ -> performCalculation "Разделить")