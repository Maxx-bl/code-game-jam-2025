using Godot;
using System;
using System.Diagnostics;

public partial class Enemy : CharacterBody2D
{
	CharacterBody2D player = null;

	[Export] float speed = 200.0f;

	bool stupid;

	int repeat_movement = 300;
	int current_repeat = 0;

	Vector2 ScreenSize;

	public override void _Ready(){
		// chose randomly if the enemy will be stupid or not
		RandomNumberGenerator rng = new RandomNumberGenerator();
		stupid = rng.RandiRange(0, 1) == 0;

		player = GetParent().GetNode<CharacterBody2D>("Player");


		ScreenSize = GetViewportRect().Size;
	}

	public override void _Process(double delta){

		if (stupid){
			if (player == null){
				return;
			}
			else{
				Vector2 direction = player.GlobalPosition - GlobalPosition;
				direction = direction.Normalized();
				Velocity = direction * speed;
				MoveAndSlide();
			}
		}
		else{
			// chose a random direction
			if (current_repeat == 0){
				RandomNumberGenerator rng = new RandomNumberGenerator();
				Vector2 direction = new Vector2(rng.RandfRange(-1.0f, 1.0f), rng.RandfRange(-1.0f, 1.0f));
				direction = direction.Normalized();
				Velocity = direction * speed;
				MoveAndSlide();
				current_repeat = repeat_movement;
			}
			else{
				current_repeat--;
				MoveAndSlide();
			}
		}

		if (GlobalPosition.DistanceTo(player.GlobalPosition) < 150f){
			// delete the enemy
			QueueFree();
			
		}


	}
}
