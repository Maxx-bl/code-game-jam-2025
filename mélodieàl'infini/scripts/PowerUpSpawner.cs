using Godot;
using System;

public partial class PowerUpSpawner : Node2D
{

	[Export] Node2D[] spawn_points;

	float spawn_interval = 1.0f;
	float spawn_rate;
	float time_until_spawn;

	[Export] int max_powerup = 2;
	int count_powerup = 0;

	PackedScene powerup;

	public override void _Ready()
	{
		spawn_rate = 1 / spawn_interval;
		time_until_spawn = 0;
		powerup = GD.Load<PackedScene>("res://scenes/powerup.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (time_until_spawn > spawn_rate)
		{
			if (count_powerup < max_powerup)
			{
				Spawn();
				count_powerup++;
				time_until_spawn = 0;
			}

		}
		else
		{
			time_until_spawn += (float)delta;
		}

		// get the number of enemies
		count_powerup = GetParent().GetChildren().Count;
	}

	private void Spawn()
	{
		RandomNumberGenerator rng = new RandomNumberGenerator();
		Vector2 location = spawn_points[rng.Randi() % spawn_points.Length].GlobalPosition;
		PowerUp pup = (PowerUp)powerup.Instantiate();
		pup.GlobalPosition = location;
		GetParent().AddChild(pup);
	}
}
