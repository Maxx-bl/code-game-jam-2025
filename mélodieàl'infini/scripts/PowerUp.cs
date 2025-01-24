using Godot;
using System;

public partial class PowerUp : Node2D
{
	private int _powerType;
	Random _rnd;

	public override void _Ready()
	{
		_rnd = new Random();
		_powerType = _rnd.Next(1, 2);
		GD.Print(_powerType);
	}

	private void _on_area_2d_body_entered(Player body)
	{
		QueueFree();
		switch(_powerType)
		{
			case 1:
				body.powerUpHealth();
				break;
			case 2:
				body.
				break;
		}
	}
}
