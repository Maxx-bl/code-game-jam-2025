using Godot;
using System;

public partial class Map : Node2D
{

	private GameManager gm;
	private MusicManager mm;
	public Player p;
	public PowerUpSpawner PuP;
	public AnimationPlayer glowMap;

	private float minPitch = 1.0f;
	private float maxPitch = 7.0f;

	public override void _Ready()
	{
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

		p = GetNode<Player>("player");

		PuP = GetNode<PowerUpSpawner>("PowerUpSpawner");

		glowMap = GetNode<AnimationPlayer>("path/AnimationPlayer");

		GetNode<AudioStreamPlayer>("AudioStreamPlayer").Play();
		GetNode<AnimationPlayer>("path/AnimationPlayer").Play("Glow anim");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		float pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.Clamp(gm.Score / 850f, 0f, 1f));
		mm.SetPitch(pitch);
	}
}
