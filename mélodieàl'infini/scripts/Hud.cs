using Godot;
using System;

public partial class Hud : Control
{
	GameManager gm;
	Player p;
	Label score;
	Label health;
	public override void _Ready()
	{
		gm = GetParent().GetParent().GetNode<GameManager>("GameManager");
		p = GetParent().GetParent().GetNode<Player>("player");
		score = GetNode<Label>("CanvasLayer/score");
		health = GetNode<Label>("CanvasLayer/health");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		score.Text = "Score: " + gm.Score.ToString();
		health.Text = "Health: " + p.Hp.ToString();
	}
}
