using Godot;
using System;

public class Game : Node
{
    public override void _Ready()
    {
        GetTree().ChangeScene("res://ui/main_menu/MainMenu.tscn");
    }
}
