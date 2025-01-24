using Godot;
using System;
using System.Diagnostics;

public partial class Enemy : CharacterBody2D
{
	CharacterBody2D player = null;

	[Export] float speed = 100.0f;

	bool stupid;

	public override void _Ready(){
		// chose randomly if the enemy will be stupid or not
		RandomNumberGenerator rng = new RandomNumberGenerator();
		stupid = rng.RandiRange(0, 1) == 0;



		player = GetParent().GetNode<CharacterBody2D>("Player");

		//afficher la position du joueur
		GD.Print(player.GlobalPosition);

		if (stupid){
			speed = 50.0f;
		}
		else{
			speed = 100.0f;
		}
	}

	public override void _Process(double delta){
		// move to the player
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
}
