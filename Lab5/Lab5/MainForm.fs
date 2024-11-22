module MainForm

open System
open System.Windows.Forms
open System.Drawing
open Ex2
open Ex3
open Ex4
open Ex5
open Ex6
open Ex7
open Ex8
open Ex9
open Ex10
open Form1
open Form2

type MainForm() as this =
    inherit Form(Text = "Главная форма", Size = System.Drawing.Size(300, 400))

    // Кнопки для открытия других форм
    let btnForm1 = new Button(Text = "Открыть Задание 2", Location = Point(50, 50), Size = Size(200, 40))
    let btnForm2 = new Button(Text = "Открыть Задание 3", Location = Point(50, 110), Size = Size(200, 40))
    let btnForm3 = new Button(Text = "Открыть Задание 4", Location = Point(50, 170), Size = Size(200, 40))
    let btnForm4 = new Button(Text = "Открыть Задание 5", Location = Point(50, 230), Size = Size(200, 40))
    let btnForm5 = new Button(Text = "Открыть Задание 6", Location = Point(50, 290), Size = Size(200, 40))
    let btnForm6 = new Button(Text = "Открыть Задание 7", Location = Point(300, 50), Size = Size(200, 40))
    let btnForm7 = new Button(Text = "Открыть Задание 8", Location = Point(300, 110), Size = Size(200, 40))
    let btnForm8 = new Button(Text = "Открыть Задание 9", Location = Point(300, 170), Size = Size(200, 40))
    let btnForm9 = new Button(Text = "Открыть Задание 10", Location = Point(300, 230), Size = Size(200, 40))
    let btnExit = new Button(Text = "Выход", Location = Point(300, 290), Size = Size(200, 40))

    let menuStrip = new MenuStrip()
    let form1MenuItem = new ToolStripMenuItem("Открыть Форму 1")
    let form2MenuItem = new ToolStripMenuItem("Открыть Форму 2")

    do
        menuStrip.Items.Add(form1MenuItem)
        menuStrip.Items.Add(form2MenuItem)
        
        this.MainMenuStrip <- menuStrip
        this.Controls.Add(menuStrip)

        form1MenuItem.Click.Add(fun _ -> 
            let form = new Form1() // Открыть Форму 1
            form.ShowDialog() |> ignore
        )
        form2MenuItem.Click.Add(fun _ -> 
            let form = new Form2() // Открыть Форму 2
            form.ShowDialog() |> ignore
        )
        // Добавляем кнопки на форму
        this.Controls.AddRange [| btnForm1; btnForm2; btnForm3; btnForm4; btnForm5; btnForm6; btnForm7; btnForm8; btnForm9; btnExit |]

        // Обработчики событий для кнопок
        btnForm1.Click.Add(fun _ ->
            let form1 = new Ex2() // Открыть форму Задание 2
            form1.ShowDialog() |> ignore
        )
        btnForm2.Click.Add(fun _ ->
            let form2 = new Ex3() // Открыть форму Задание 3
            form2.ShowDialog() |> ignore
        )
        btnForm3.Click.Add(fun _ ->
            let form3 = new Ex4() // Открыть форму Задание 4
            form3.ShowDialog() |> ignore
        )
        btnForm4.Click.Add(fun _ ->
            let form4 = new Ex5() // Открыть форму Задание 5
            form4.ShowDialog() |> ignore
        )
        btnForm5.Click.Add(fun _ ->
            let form5 = new Ex6() // Открыть форму Задание 6
            form5.ShowDialog() |> ignore
        )
        btnForm6.Click.Add(fun _ ->
            let form6 = new Ex7() // Открыть форму Задание 7
            form6.ShowDialog() |> ignore
        )
        btnForm7.Click.Add(fun _ ->
            let form7 = new Ex8() // Открыть форму Задание 7
            form7.ShowDialog() |> ignore
        )
        btnForm8.Click.Add(fun _ ->
            let form8 = new Ex9() // Открыть форму Задание 7
            form8.ShowDialog() |> ignore
        )
        btnForm9.Click.Add(fun _ ->
            let form9 = new Ex10() // Открыть форму Задание 7
            form9.ShowDialog() |> ignore
        )
        btnExit.Click.Add(fun _ ->
            this.Close() // Закрыть главную форму
            Application.Exit()
        )
