using Godot;
using System;

public partial class MainMenu : Control
{
	public void _on_button_play_button_up() {
		GetTree().ChangeSceneToFile("res://scenes/map.tscn");
	}

	public void _on_button_quit_button_up() {
		GetTree().Quit();
	}

	public void _on_button_credits_button_up() {
		GetTree().ChangeSceneToFile("res://scenes/credits.tscn");
	}
}
