using Godot;
using System;
using System.Collections.Generic;
[GlobalClass]
public partial class DialogList : Resource
{
    [Export] public Godot.Collections.Array<DialogData> dialogsList = new Godot.Collections.Array<DialogData>();
}
