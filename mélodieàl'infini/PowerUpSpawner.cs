using Godot;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

public partial class PowerUpSpawner : Node2D
{

	PackedScene pupScene;
	int _maxSpawn = 1;
	public int spawnCount;
	double _elapsedTime = 0f;
	List<Vector2> allPos = new List<Vector2>();


	public override void _Ready()
	{
		spawnCount = 0;
		pupScene = GD.Load<PackedScene>("res://scenes/power_up.tscn");
		allPos.Add(new Vector2(300, -400));
		allPos.Add(new Vector2(-5108, -491));
		allPos.Add(new Vector2(5810, -457));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_elapsedTime += delta;
		if ((Math.Floor(_elapsedTime) > Math.Floor(_elapsedTime - delta)) && spawnCount < _maxSpawn)
		{
			_elapsedTime = 0f;
			StaticBody2D pup = pupScene.Instantiate<StaticBody2D>();
			Random r = new Random();
			Vector2 pupPos = allPos[r.Next(0, allPos.Count)];
			GetParent().AddChild(pup);
			pup.Position = pupPos;
			spawnCount++;
		}
	}
}
