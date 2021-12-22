using Godot;
using System;

public class MainMenu : Control
{
	
	private void _on_PlayGameButton_pressed()
	{
		// Replace with function body.
		GD.Print(new NotImplementedException(
			nameof(_on_PlayGameButton_pressed)));
	}

	private void _on_LoadGameButton_pressed()
	{
		// Replace with function body.
		GD.Print(new NotImplementedException(
			nameof(_on_LoadGameButton_pressed)));
	}
	
	private void _on_CreditsButton_pressed()
	{
		// Replace with function body.
		GD.Print(new NotImplementedException(
			nameof(_on_CreditsButton_pressed)));
	}

	private void _on_ExitButton_pressed()
	{
		GetTree().Quit(0);
	}
}
