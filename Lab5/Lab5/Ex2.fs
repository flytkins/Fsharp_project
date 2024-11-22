module Ex2

open System
open System.Windows.Forms
open System.Drawing

type Ex2() as this =
    inherit Form(Text = "Квадратное уравнение")
    let labelA = new Label(Text = "a:", Location = Point(10, 20))
    let textBoxA = new TextBox(Location = Point(50, 20), Width = 100, Enabled = true, ReadOnly = false, TextAlign = HorizontalAlignment.Right)

    let labelB = new Label(Text = "b:", Location = Point(10, 60))
    let textBoxB = new TextBox(Location = Point(50, 60), Width = 100, Enabled = true, ReadOnly = false, TextAlign = HorizontalAlignment.Right)

    let labelC = new Label(Text = "c:", Location = Point(10, 100))
    let textBoxC = new TextBox(Location = Point(50, 100), Width = 100, Enabled = true, ReadOnly = false, TextAlign = HorizontalAlignment.Right)

    let solveButton = new Button(Text = "Решить", Location = Point(10, 140))
    let resultBox = new RichTextBox(Location = Point(10, 180), Width = 260, Height = 100)
    do
        //let label = new Label(Text = "a*x^2 + b * x + c")
        this.Controls.AddRange([|
                //label
                labelA; textBoxA
                labelB; textBoxB
                labelC; textBoxC
                solveButton
                resultBox
            |])
        
    let solveQuadratic a b c =
        let discriminant = b * b - 4.0 * a * c
        if discriminant > 0.0 then
            let x1 = (-b + sqrt discriminant) / (2.0 * a)
            let x2 = (-b - sqrt discriminant) / (2.0 * a)
            sprintf "Дискриминант: %f\nДва корня: x1 = %f, x2 = %f" discriminant x1 x2
        elif discriminant = 0.0 then
            let x = -b / (2.0 * a)
            sprintf "Дискриминант: %f\nОдин корень: x = %f" discriminant x
        else
            sprintf "Дискриминант: %f\nКорней нет" discriminant

    do
        solveButton.Click.Add(fun _ ->
            try
                let a = Convert.ToDouble(textBoxA.Text)
                let b = Convert.ToDouble(textBoxB.Text)
                let c = Convert.ToDouble(textBoxC.Text)

                if a = 0.0 then
                    if b = 0.0 then
                        resultBox.Text <- "Ошибка: некорректное уравнение"
                    else
                        resultBox.Text <- Convert.ToString(-c / b)
                else
                    let result = solveQuadratic a b c
                    resultBox.Text <- result
            with
            | :? FormatException ->
                resultBox.Text <- "Пожалуйста, введите корректные числовые значения для коэффициентов a, b и c."
        )