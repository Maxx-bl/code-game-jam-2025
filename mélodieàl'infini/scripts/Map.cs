using Godot;
using System;

public partial class Map : Node2D
{

	private GameManager gm;
	private MusicManager mm;
	private Player p;

	private float minPitch = 1.0f;
	private float maxPitch = 5.0f;

	private double elapsedTime;

	public override void _Ready()
	{
		elapsedTime = 0f;

		var scene = GD.Load<PackedScene>("res://scenes/game_manager.tscn");
		var sceneInstance = scene.Instantiate();
		AddChild(sceneInstance);

		var player = GD.Load<PackedScene>("res://scenes/player.tscn");
		var playerInstance = player.Instantiate();
		AddChild(playerInstance);

		var music = GD.Load<PackedScene>("res://scenes/music_manager.tscn");
		var musicInstance = music.Instantiate();
		AddChild(musicInstance);

		mm = GetNode<MusicManager>("MusicManager");

		gm = GetNode<GameManager>("GameManager");

		p = GetNode<Player>("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.Clamp(p.Speed / 7500f, 0f, 1f));  // Adjust the divisor to control sensitivity		mm.SetPitch(pitch);
		mm.SetPitch(pitch);

		elapsedTime += delta;
		if (Math.Floor(elapsedTime) > Math.Floor(elapsedTime - delta))
		{
			gm.IncrementScore(p.Speed);
		}
		GD.Print(gm.Score);
	}
}
