using Godot;
using System;

public partial class Slime : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 20.0f;

	[Export]
	Marker2D endPoint;

	public AnimatedSprite2D animationSlime;

	public Vector2 StartPosition {get; set;} 
	public Vector2 EndPosition {get; set;}

	private float Limit {get;} = 0.5f;
	
	public override void _Ready()
	{
		animationSlime = (AnimatedSprite2D)GetNode("AnimationSlime");

		StartPosition = Position;
		EndPosition = endPoint.GlobalPosition;
	}

	public void Changedirectional()
	{
        (StartPosition, EndPosition) = (EndPosition, StartPosition);
    }

    public void UpdateAnimation()
	{
        string animationString = "walkDown";

		if(Velocity.Y < 0) animationString = "walkUp"; 

		animationSlime.Play(animationString);
	}

	public void UpdateVelocity()
	{
		Vector2 moveDirectional = EndPosition - Position;

		if(moveDirectional.Length() < Limit)
		{
			Changedirectional();
		}

		Velocity = moveDirectional.Normalized() * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateVelocity();
		MoveAndSlide();
		UpdateAnimation();
	}
}
