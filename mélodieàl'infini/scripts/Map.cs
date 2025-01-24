using Godot;
using System;

public partial class Map : Node2D
{

	private GameManager gm;

	public override void _Ready()
	{
		var scene = GD.Load<PackedScene>("res://scenes/game_manager.tscn");
		var sceneInstance = scene.Instantiate();
		AddChild(sceneInstance);

		var player = GD.Load<PackedScene>("res://scenes/player.tscn");
		var playerInstance = player.Instantiate();
		AddChild(playerInstance);

		gm = GetNode<GameManager>("GameManager");
		gm.SetDifficulty(25);
		GD.Print(gm.Difficulty);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
