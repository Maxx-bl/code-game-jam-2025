using Godot;
using System;

public partial class AudioStreamPlayerMenu : AudioStreamPlayer
{
	public void _on_finished() {
		Play();
	}
}
