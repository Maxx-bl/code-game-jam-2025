using Godot;
using System;

public partial class PowerUp : Node2D
{
	private int _powerType;
	Random _rnd;
	PowerUp _pwr;
	private int _posX;
	private int _posY;

	public override void _Ready()
	{
		_rnd = new Random();
		_powerType = _rnd.Next(1, 5);
		_posX = _rnd.Next(-5000, 5000);
		_posY = _rnd.Next(-3000, 3000);
		Position = new Vector2(_posX, _posY);
		
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
			case 4:
				// repousse les ennemis alentour
				break;
			case 5:
				// troll! tu gagnes rien
				break;
		}
		body._collected = true;
//		GD.Print("booom");
	}
}
