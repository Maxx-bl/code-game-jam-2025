using Godot;
using System;

public partial class Hud : Control
{
	GameManager gm;
	Player p;
	Label score;
	Label health;
	Sprite2D heart;
	public override void _Ready()
	{
		gm = GetParent().GetParent().GetNode<GameManager>("GameManager");
		p = GetParent().GetParent().GetNode<Player>("player");
		score = GetNode<Label>("CanvasLayer/score");
		health = GetNode<Label>("CanvasLayer/health");
		heart = GetNode<Sprite2D>("CanvasLayer/Sprite2D");
		heart.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		score.Text = "Score: " + gm.Score.ToString();
		health.Text = "Health: " + p.Hp.ToString();
	}

	public async void ShowHeart() {
		heart.Show();
		await ToSignal(GetTree().CreateTimer(1.5f), "timeout");
		heart.Hide();
	}
}
