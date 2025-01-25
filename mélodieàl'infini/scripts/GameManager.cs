using Godot;
using System;

public partial class GameManager : Node
{

	public float Difficulty { get; set; }
	public int Score { get; set; }

	private double elapsedTime;
	private bool slowPowerUp = false;

	public override void _Ready()
	{
		Score = 0;
	}

    public override void _Process(double delta)
    {
        
		elapsedTime += delta;
		if (Math.Floor(elapsedTime) > Math.Floor(elapsedTime - delta))
		{
			IncrementScore();
		}
	}

    public void IncrementScore()
	{
		Score++;
	}

	public bool GetPowerUpSlow() {
		return slowPowerUp;
	}
	
	public async void EnableSlow() {
		slowPowerUp = true;
		await ToSignal(GetTree().CreateTimer(8f), "timeout");
		DisableSlow();
	}

	public void DisableSlow() {
		slowPowerUp = false;
	}
}
