using Godot;
using System;

public partial class RetryMenu : Control
{

	GameManager gm;
	Label score;

	public override void _Ready()
	{
		score = GetNode<Label>("CanvasLayer/Text/Label");
		gm = GetParent().GetNode<GameManager>("GameManager");
		score.Text = gm.Score.ToString();
	}

	public void _on_texture_button_retry_button_up()
	{
		GetTree().ChangeSceneToFile("res://scenes/map.tscn");
	}

	public void _on_texture_butto_mm_button_up()
	{
		CallDeferred("GoToMenu");
	}

	private void GoToMenu()
	{
		GetTree().ChangeSceneToFile("res://UI/HUD_MainMenu/MainMenu.tscn");
	}
}
