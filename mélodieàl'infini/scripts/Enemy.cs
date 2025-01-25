using Godot;
using System;
using System.Diagnostics;

public partial class Enemy : CharacterBody2D
{
	CharacterBody2D player = null;
	Player pStats;

	[Export] float speed = 200.0f;

	bool stupid;

	int repeat_movement = 300;
	int current_repeat = 0;

	Vector2 ScreenSize;

	Sprite2D sprite;
	AudioStreamPlayer asp;
	GameManager gm;

	public override void _Ready(){
		RandomNumberGenerator rng = new RandomNumberGenerator();
		stupid = rng.RandiRange(0, 1) == 0;

		player = GetParent().GetNode<CharacterBody2D>("player");
		pStats = GetParent().GetNode<Player>("player");

		ScreenSize = GetViewportRect().Size;

		sprite = GetNode<Sprite2D>("Sprite2D");
		Random ran = new Random();
		Texture2D tex = GD.Load<Texture2D>("res://assets/enemy" + (ran.Next(0, 2) + 1).ToString() + ".png");
		sprite.Texture = tex;

		asp = GetNode<AudioStreamPlayer>("AudioStreamPlayer");

		gm = GetParent().GetNode<GameManager>("GameManager");
	}

	public override void _Process(double delta)
	{
		speed = pStats.Speed * 0.6f;
		if (gm.GetPowerUpSlow())  speed /= 10;
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

	}

	public void _on_area_2d_area_entered(Area2D area) {
		if (area.IsInGroup("player")) {
			pStats.CollideWithEnemy();
			asp.Play();
			GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
			GetNode<Area2D>("Area2D").QueueFree();
		}
		if (area.IsInGroup("explosion")) {
			QueueFree();
		}
	}

	public void _on_audio_stream_player_finished() {
		QueueFree();
	}

}
