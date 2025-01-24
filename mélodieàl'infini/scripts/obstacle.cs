using Godot;
using System;

public partial class obstacle : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void show_obstacle()
	{
		Show();
		// enable collision
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

	public void hide_obstacle()
	{
		Hide();
		// disable collision
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
	}

	public void _on_area_2d_area_entered(Area2D area)
	{
		if (area.GetParent().IsInGroup("enemy"))
		{
			area.GetParent().QueueFree();
			//Animation destruction ennemi
		} 
		if (area.GetParent().IsInGroup("player"))
		{
			hide_obstacle();
			area.GetParent().GetParent().GetNode<Player>("player").CollideWithEnemy();
		} 
	}
}
