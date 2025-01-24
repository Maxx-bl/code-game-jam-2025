using Godot;
using System;

public partial class Map : Node2D
{

	private GameManager gm;
	private MusicManager mm;

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
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (gm.Score < 5) {
			mm.SetPitch(1f);
		} else if (gm.Score < 10) {
			mm.SetPitch(1.5f);
		} else if (gm.Score < 15) {
			mm.SetPitch(2f);
		} else if (gm.Score < 20) {
			mm.SetPitch(2.5f);
		} else if (gm.Score < 25) {
			mm.SetPitch(3f);
		} else if (gm.Score < 30) {
			mm.SetPitch(3.5f);
		} else if (gm.Score < 35) {
			mm.SetPitch(4f);
		}
	}
}
