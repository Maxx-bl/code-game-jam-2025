using Godot;
using System;

public partial class MusicManager : Node
{
	public AudioStreamPlayer asp;

    public override void _Ready()
    {
		asp = GetNode<AudioStreamPlayer>("AudioStreamPlayer");	
    }

	public float GetPitch() {
		return asp.PitchScale;
	}

	public void SetPitch(float pitch) {
		asp.PitchScale = pitch;
	}

	public void _on_audio_stream_player_finished() {
		asp.Play();
	}
}
