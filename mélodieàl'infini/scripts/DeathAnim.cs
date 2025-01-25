using Godot;
using System;

public partial class DeathAnim : Node2D
{
	AnimationPlayer ap;

    public override void _Ready()
    {
        ap = GetNode<AnimationPlayer>("Lifebar16x16/AnimationPlayer");
    }

	public void PlayDeathFromRetryMenu() {
		ap.Play("Death");
	}

	public void _on_animation_player_animation_finished(String name) {
		if (GetParent().Name == "AnimRect") {
			GetParent().QueueFree();
		}
	}
}
