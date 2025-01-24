using Godot;
using System;

public partial class EnemySpawner : Node2D
{
	[Export] PackedScene enemy_scene;
	[Export] Node2D[] spawn_points;
	[Export] float spawn_interval = 1.0f;

	float spawn_rate;
	float time_until_spawn;


	[Export] int max_enemies = 10;
	int count_enemies = 0;




	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spawn_rate = 10 / spawn_interval;
		time_until_spawn = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (time_until_spawn > spawn_rate){
			if (count_enemies < max_enemies){
				Spawn();
				count_enemies++;
				time_until_spawn = 0;
			}
			
		}
		else{
			time_until_spawn += (float)delta; 
		}

		// get the number of enemies
		count_enemies = GetParent().GetChildren().Count;
	}

	private void Spawn(){
		RandomNumberGenerator rng = new RandomNumberGenerator();
		Vector2 location = spawn_points[rng.Randi() % spawn_points.Length].GlobalPosition;
		Enemy enemy = (Enemy)enemy_scene.Instantiate();
		enemy.GlobalPosition = location;
		GetParent().AddChild(enemy);
	}
}
