using Godot;
using System;

public partial class MainMenu : Control
{
	public void _on_button_play_button_down() {
		GetTree().ChangeSceneToFile("res://scenes/map.tscn");
	}
}
