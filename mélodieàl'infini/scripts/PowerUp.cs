using Godot;
using System;

public partial class PowerUp : StaticBody2D
{

	Map map;
	public override void _Ready()
	{
		map = GetParent<Map>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_area_2d_area_entered(Area2D area)
	{
		if (area.GetParent().IsInGroup("player"))
		{
			map.PuP.spawnCount--;
			map.p.Hp++;
			QueueFree();
		}
	}
}
