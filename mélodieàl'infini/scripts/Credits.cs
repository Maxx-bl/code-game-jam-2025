using Godot;
using System;

public partial class Credits : Control
{
    public void _on_button_button_down() {
        GetTree().ChangeSceneToFile("res://UI/HUD_MainMenu/MainMenu.tscn");
    }
}
