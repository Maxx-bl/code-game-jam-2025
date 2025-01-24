using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 _targetPosition;
	private bool _isMoving = false;
	private bool _isMovingWithKeyboard = false;

	public float _defaultSpeed = 750f;
	public float Speed;
	private double _timerCount;

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

		if (@event is InputEventMouseButton eventMouseClick && eventMouseClick.Pressed)
		{
			_targetPosition = GetGlobalMousePosition();
			_isMoving = true;
		}
		else if (@event is InputEventMouseButton eventMouseClicke && !eventMouseClicke.Pressed)
		{
			_isMoving = false;
			Speed = 0f;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_isMoving)
		{
			Vector2 move = _targetPosition - Position;
			if (move.Length() > 10f)
			{
				Velocity = move.Normalized() * Speed;
				MoveAndSlide();
			}
		}
	}

	public override void _Process(double delta)
	{
		Vector2 velocity = new Vector2();

		if (!_isMoving)
		{
			if (Input.IsActionPressed("player_up") || Input.IsActionPressed("player_down") || Input.IsActionPressed("player_right") || Input.IsActionPressed("player_left")) { _isMovingWithKeyboard = true; } else {_isMovingWithKeyboard = false; Speed = 0f; }

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

			velocity = velocity.Normalized() * Speed;
			Position += velocity * (float)delta;
		}

		_timerCount += delta;

		if ((_isMoving || _isMovingWithKeyboard) && _timerCount >= 1.0f)
		{
			_timerCount = 0f;
			if (Speed == 0f) Speed = _defaultSpeed;
			else Speed += 50;
		}

	}
}
