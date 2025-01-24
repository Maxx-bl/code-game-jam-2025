using Godot;
using System;

public partial class Camera : Camera2D
{
	[Export] private Node2D _target = null;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_target != null)
		{
			Position = _target.Position;
		}
	}
}
