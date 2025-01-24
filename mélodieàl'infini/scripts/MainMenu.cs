using Godot;
using System;

public partial class MainMenu : Control
{
	public void _on_button_play_button_down() {
		GetTree().ChangeSceneToFile("res://scenes/map.tscn");
	}

	public void _on_button_quit_button_down() {
		GetTree().Quit();
	}
}
