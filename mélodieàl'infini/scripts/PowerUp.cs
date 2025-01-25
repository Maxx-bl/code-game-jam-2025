using Godot;
using System;

public partial class PowerUp : StaticBody2D
{

	Map map;
	GameManager gm;
	AudioStreamPlayer asp;
	AnimationPlayer ap;
	Player p;
	int pupType;

	public override void _Ready()
	{
		map = GetParent<Map>();
		asp = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
		ap = GetNode<AnimationPlayer>("BonusExplosion/AnimationPlayer");
		p = GetParent().GetNode<Player>("player");
		Random ran = new Random();
		pupType = ran.Next(0, 3);
		gm = GetParent().GetNode<GameManager>("GameManager");
		ap.Stop();
		GetNode<Node2D>("BonusExplosion").Hide();
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
				map.p.Hp+=2;
				p.GetNode<Hud>("hud").ShowHeart();
			} else if (pupType == 1) {
				p.EnableShield();
			} else if (pupType == 2) {
				gm.EnableSlow();
			}
			GetNode<Node2D>("BonusExplosion").Show();
			ap.Play("Explosion!");

			asp.Play();
			map.PuP.spawnCount--;
			GetNode<Sprite2D>("Sprite2D").QueueFree();
			GetNode<Area2D>("Area2D").QueueFree();
		}
	}

	public void _on_audio_stream_player_finished()
	{
		Destroy();
	}

	public async void Destroy() {
		await ToSignal(GetTree().CreateTimer(2f), "timeout");
		QueueFree();
	}
}
