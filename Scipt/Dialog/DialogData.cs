using Godot;
using System;
[GlobalClass]
public partial class DialogData : Resource
{
    [Export(PropertyHint.MultilineText, "")] public string mainText;
    [Export(PropertyHint.MultilineText, "")] public string option1;
    [Export(PropertyHint.MultilineText, "")] public string option2;
    [Export(PropertyHint.MultilineText, "")] public string option3;
    [Export] public int id;
    [Export] public int nextId;
    [Export] public int nextIdop1;
    [Export] public int nextIdop2;
    [Export] public int nextIdop3;
    [Export] public bool isOver;
    [Export] public bool isStart;
    [Export] public Texture2D texture;
}
