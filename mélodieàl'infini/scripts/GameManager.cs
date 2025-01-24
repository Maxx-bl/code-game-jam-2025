using Godot;
using System;

public partial class GameManager : Node
{

	public float Difficulty {get; set;}
	public int Score {get; set;}

	public override void _Ready()
	{
		Difficulty = 25;
		Score = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void SetDifficulty(int value) {
		Difficulty = value;
	}
}
