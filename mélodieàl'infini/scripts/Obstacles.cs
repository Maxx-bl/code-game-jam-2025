using Godot;
using System;

public partial class Obstacles : Node
{
	[Export] PackedScene obstacle_scene;
	[Export] StaticBody2D[] obstacle_points;

	private int nb_obstacles;

	private int _delai_max = 100;
	private int _current_delai = 0;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (_current_delai > _delai_max){
			_current_delai = 0;
			nb_obstacles = GetParent().GetChildren().Count;
			GD.Print(obstacle_points.Length);
			// random choose if the obstacle will spawn
			for (int i = 0; i < obstacle_points.Length; i++){
				RandomNumberGenerator rng = new RandomNumberGenerator();
				bool rd_spawn = rng.RandiRange(0, 100) < 20;
				if (rd_spawn){
					obstacle_points[i].Show();
					// enable collision
					obstacle_points[i].GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
				}
				else{
					obstacle_points[i].Hide();
					// disable collision
					obstacle_points[i].GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
				}
				
			}
		
		}
		else{
			_current_delai += 1;
		}

		
	}
}
