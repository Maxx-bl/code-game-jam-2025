using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 _targetPosition;
	private bool _isMoving = false;
	public float _defaultSpeed = 800f;
	public float _maxSpeed = 6000f;
	public float Speed;
	private double _elapsedTime;

	public int Hp;

	Vector2 ScreenSize;

	public override void _Ready()
	{
		Speed = _defaultSpeed;
		_targetPosition = Position;
		ScreenSize = GetViewportRect().Size;
		Hp = 1;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion eventMouseMotion && _isMoving)
		{
			_targetPosition = GetGlobalMousePosition();
		}

		if (@event is InputEventMouseButton eventMouseClick && eventMouseClick.Pressed){
		 	_targetPosition = GetGlobalMousePosition();
		 	_isMoving = true;
		}
		else if (@event is InputEventMouseButton eventMouseClicke && !eventMouseClicke.Pressed){
			_isMoving = false;
		}
	}

	public override void _PhysicsProcess(double delta){
		if (_isMoving){
			Vector2 move = _targetPosition - Position;
			if (move.Length() > 10f){
				Velocity = move.Normalized() * Speed;
				MoveAndCollide(Velocity);
			}
		}
	}

	public void powerUpHealth()
	{
		Hp++;
	}

	public override void _Process(double delta)
	{
		Vector2 velocity = new Vector2();

		if (!_isMoving)
		{
			if (Input.IsActionPressed("player_up"))
			{
				velocity.Y -= 1;
			}
			if (Input.IsActionPressed("player_down"))
			{
				velocity.Y += 1;
			}
			if (Input.IsActionPressed("player_left"))
			{
				velocity.X -= 1;
			}
			if (Input.IsActionPressed("player_right"))
			{
				velocity.X += 1;
			}

			velocity = velocity.Normalized() * Speed * (float)delta;
			MoveAndCollide(velocity);
			//Position += velocity * (float)delta;
		}

		_elapsedTime += delta;
		if (Math.Floor(_elapsedTime) > Math.Floor(_elapsedTime - delta))
		{
			if (Speed < _maxSpeed) {
				Speed+=50f;
			}
		}
	}
}
