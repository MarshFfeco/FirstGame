using Godot;
using System;

public partial class Camera2D : Godot.Camera2D
{
	[Export]
	public TileMap tilemap;
	public override void _Ready()
	{
		Godot.Rect2I mapRect = tilemap.GetUsedRect();
		int mapSize = tilemap.CellQuadrantSize;
		Godot.Vector2I worldsizePixel = mapRect.Size * mapSize;

		LimitRight = worldsizePixel.X;
		LimitBottom= worldsizePixel.Y;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
