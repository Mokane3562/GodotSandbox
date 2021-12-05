using Godot;

public class ExitButton : Button
{
	public override void _Ready()
	{
		Connect("pressed", this, nameof(QuitGame));
	}

	private void QuitGame()
	{
		GetTree().Quit(0);
	}
}
