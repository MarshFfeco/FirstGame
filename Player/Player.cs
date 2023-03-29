using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 50.0f;
	public AnimationPlayer animationPlayer;

	private void UpdateAnimationPlayer(Vector2 velocity) {
		if(velocity.Length() == 0) {
			animationPlayer.Stop();
			return;
		}

		string direction = "Down";

		switch(velocity.X) {
			case > 0:
				direction = "Right";
			break;
			case < 0:
				direction = "Left";
			break;
		}

		switch(velocity.Y) {
			case > 0:
				direction = "Down";
			break;
			case < 0:
				direction = "Up";
			break;
		}

		animationPlayer.Play("Walk" + direction);
	}

	private void MovementPlayer(Vector2 velocity) {
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if(direction.X != 0 && direction.Y != 0) 
		{
			animationPlayer.Stop();
			return;
		} else {
			Velocity = Speed * direction;
			MoveAndSlide();
			UpdateAnimationPlayer(velocity);
		}
	}

	public override void _Ready() {
		animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		MovementPlayer(velocity);
	}
}
