using Godot;
using System;

public partial class PowerUp : StaticBody2D
{

	Map map;
	GameManager gm;
	AudioStreamPlayer asp;
	CanvasLayer animCanva;
	AnimationPlayer ap;
	Player p;
	int pupType;
	public override void _Ready()
	{
		map = GetParent<Map>();
		asp = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		// animCanva = GetNode<CanvasLayer>("CanvasLayer");
		// ap = animCanva.GetNode<AnimationPlayer>("Bonus/Bonus/AnimationPlayer");
		// animCanva.Hide();
		p = GetParent().GetNode<Player>("player");
		Random ran = new Random();
		pupType = ran.Next(0, 3);
		gm = GetParent().GetNode<GameManager>("GameManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_area_2d_area_entered(Area2D area)
	{
		if (area.IsInGroup("player"))
		{
			if (pupType == 0)
			{
				map.p.Hp++;
			} else if (pupType == 1) {
				p.EnableShield();
			} else if (pupType == 2) {
				gm.EnableSlow();
			}
			// animCanva.Show();
			// ap.Play("Malus");

			asp.Play();
			map.PuP.spawnCount--;
			GetNode<Area2D>("Area2D").QueueFree();
		}
	}

	public void _on_audio_stream_player_finished()
	{
		QueueFree();
	}
}
