using Godot;
using System;
using System.Linq;

public partial class DialogManager : Node
{
    [Export] private DialogList dialogs;
    [Export] private RichTextLabel richTextLabel;
    [Export] private Button optionBtn1;
    [Export] private Button optionBtn2;
    [Export] private Button optionBtn3;
    [Export] private Button nextBtn;
    [Export] private DialogData currentData;
    [Export] private Texture2D defaultImage;
    [Export] private TextureRect image;

    private int currentIndex = 0;

    [Export] private Timer timer;
    public override void _Ready()
    {
        base._Ready();
        nextBtn.Pressed += NextText;
        optionBtn1.Pressed += NextOpt1;
        optionBtn2.Pressed += NextOpt2;
        optionBtn3.Pressed += NextOpt3;
        timer.Timeout += OnTimerTimeout;
        Init(1);
    }
    private void Init(int id)
    {
        var data = dialogs.dialogsList.FirstOrDefault(i => i.id == id);

        if (data == null)
        {
            GD.PrintErr("cant find" + id.ToString());
            return;
        }
        currentData = data;
        ShowText(id);
    }

    private void ShowText(int id)
    {
        if (id == 0)
        {
            return;
        }
        var diag = dialogs.dialogsList.FirstOrDefault(i => i.id == id);
        if (diag == null)
        {
            GD.PrintErr("cant find" + id.ToString());
            return;
        }
        timer.Stop();
        currentIndex = 0;
        if (!diag.option1.Equals(string.Empty))
        {
            optionBtn1.Text = diag.option1;
            optionBtn1.Show();
        }
        else
        {
            optionBtn1.Hide();
        }
        if (!diag.option2.Equals(string.Empty))
        {
            optionBtn2.Text = diag.option2;
            optionBtn2.Show();
        }
        else
        {
            optionBtn2.Hide();
        }
        if (!diag.option3.Equals(string.Empty))
        {
            optionBtn3.Text = diag.option3;
            optionBtn3.Show();
        }
        else
        {
            optionBtn3.Hide();
        }
        if (diag.texture == null)
        {
            image.Texture = defaultImage;
        }
        else
        {
            image.Texture = diag.texture;
        }
        currentData = diag;
        richTextLabel.Text = "";
        timer.Start();
        
    }
    private void OnTimerTimeout()
    {
        if (currentIndex < currentData.mainText.Length)
        {
            // 追加下一个字符到 RichTextLabel
            richTextLabel.Text += currentData.mainText[currentIndex];
            currentIndex++;
        }
        else
        {
            // 停止 Timer 当所有字符都已显示
            timer.Stop();
        }
    }
    private void NextText()
    {
        if (currentData.isOver)
        {
            GD.Print("Over");
            return;
        }
        int id = currentData.nextId;
        currentData =  dialogs.dialogsList.FirstOrDefault(i => i.id == id);
        ShowText(id);
    }
    private void NextOpt1()
    {
        int id = currentData.nextIdop1;
        currentData = dialogs.dialogsList[id];
        ShowText(id);
    }
    private void NextOpt2()
    {
        int id = currentData.nextIdop2;
        currentData =  dialogs.dialogsList.FirstOrDefault(i => i.id == id);
        ShowText(id);
    }
    private void NextOpt3()
    {
        int id = currentData.nextIdop3;
        currentData = dialogs.dialogsList[id];
        ShowText(id);
    }
}
