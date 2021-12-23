using Godot;
using System;

public class MainMenu : Control
{
	public override void _Ready()
	{
		GD.Print("Hello World!");
	}
	
	private void _on_PlayGameButton_pressed()
	{
		GD.Print(new NotImplementedException(nameof(_on_PlayGameButton_pressed)));
	}

	private void _on_LoadGameButton_pressed()
	{
		GD.Print(new NotImplementedException(nameof(_on_LoadGameButton_pressed)));
	}
	
	private void _on_CreditsButton_pressed()
	{
		GD.Print(new NotImplementedException(nameof(_on_CreditsButton_pressed)));
	}

	private void _on_ExitButton_pressed()
	{
		GetTree().Quit(0);
	}
}
