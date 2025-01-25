using Godot;
using System;

public partial class RetryMenu : Control
{

	GameManager gm;
	Label score;
	MusicManager mm;

	ColorRect animRect;
	DeathAnim deathAnim;

	public override void _Ready()
	{
		score = GetNode<Label>("CanvasLayer/Text/Label");
		gm = GetParent().GetNode<GameManager>("GameManager");
		score.Text = gm.Score.ToString();
		mm = GetParent().GetNode<MusicManager>("MusicManager");
		mm.asp.Stop();
		animRect = GetNode<ColorRect>("CanvasLayer/AnimRect");
		deathAnim = animRect.GetNode<DeathAnim>("Death");
		deathAnim.PlayDeathFromRetryMenu();
	}

	public async void WaitTime(float time) {
		await ToSignal(GetTree().CreateTimer(time), "timeout");
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
