using Godot;
using System;

public partial class GameManager : Node
{

	public float Difficulty { get; set; }
	public int Score { get; set; }


	public override void _Ready()
	{
		Score = 0;
	}

	public void IncrementScore(float speed)
	{
		int scoreIncrement = Mathf.FloorToInt(speed / 50f);

        if (scoreIncrement > 0)
        {
            Score += scoreIncrement;
        }
	}
}
