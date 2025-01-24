using Godot;
using System;
using System.Threading;

public partial class PowerUp : Node2D
{
	private int _powerType;
	PowerUp _pwr;

	public override void _Ready()
	{
		Random rnd = new Random();
		_powerType = rnd.Next(0, 3);
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
				body.powerUpDouble();
				break;
			case 3:
				// ralenti les ennemis
				break;
			default: break;
		}
	}
}
