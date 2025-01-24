using Godot;
using System;

public partial class PowerUp : Node2D
{
	private int _powerType;
	Random _rnd;

	public override void _Ready()
	{
		_rnd = new Random();
		_powerType = _rnd.Next(1, 5);
	}

	private void _on_area_2d_body_entered(Node2D body)
	{
		//QueueFree();
		GD.Print(_powerType);
	}
}

