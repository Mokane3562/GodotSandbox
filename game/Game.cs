using Godot;
using System;


	public class Game : Node
	{

		public override void _Ready()
		{
			GD.Print("Hello World!");
			PlayTownDebug();
		}

		private void PlayTownDebug()
		{
			GetTree().ChangeScene("res://ui/main_menu/MainMenu.tscn");
		}
	}


