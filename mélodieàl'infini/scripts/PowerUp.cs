using Godot;
using System;

public partial class PowerUp : StaticBody2D
{

	Map map;
	AudioStreamPlayer asp;
	public override void _Ready()
	{
		map = GetParent<Map>();
		asp = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_area_2d_area_entered(Area2D area)
	{
		if (area.GetParent().IsInGroup("player"))
		{
			asp.Play();
			map.PuP.spawnCount--;
			map.p.Hp++;
			GetNode<Area2D>("Area2D").QueueFree();
		}
	}

	public void _on_audio_stream_player_finished() {
		QueueFree();
	}
}
