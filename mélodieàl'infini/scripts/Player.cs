using Godot;
using System;

public partial class Player : CharacterBody2D
{
	private Vector2 _targetPosition;
	private bool _isMoving = false;

	private float _speed_mouse = 800f;
	private float _speed_keyboard = 800f;

	private Color _drawColor;

	Vector2 ScreenSize;

	public override void _Ready(){
		_targetPosition = Position;
		_drawColor = new Color(1, 1, 1, 0.75f);
		ScreenSize = GetViewportRect().Size;
	}

	public override void _Input(InputEvent @event){
		if (@event is InputEventMouseMotion eventMouseMotion && _isMoving){
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
				Velocity = move.Normalized() * _speed_mouse;
				MoveAndSlide();
				//QueueRedraw();
			}
			else{
				_isMoving = false;
			}
		}
	}

	public override void _Draw(){
		DrawLine(Vector2.Zero, _targetPosition - Position, _drawColor, 2, true);
		DrawCircle(_targetPosition - Position, 6, _drawColor);
	}

	public override void _Process(double delta){
		Vector2 velocity = new Vector2();

		if (!_isMoving){

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

			velocity = velocity.Normalized() * _speed_keyboard;
			Position += velocity * (float)delta;
		}

	}
}
