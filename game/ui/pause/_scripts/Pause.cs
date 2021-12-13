using Godot;
using System;

public class Pause : Control
{
	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("pause"))
		{
			var newPauseState = !GetTree().Paused;
			GetTree().Paused = newPauseState;
			Visible = newPauseState;
		}
	}
}
