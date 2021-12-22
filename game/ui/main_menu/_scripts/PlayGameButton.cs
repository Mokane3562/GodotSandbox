using Godot;

public class NewGameButton : Button
{
	[Export] 
	private string _sceneToLoad = "Scene Path";

	public override void _Ready()
	{
		Connect("pressed", this, nameof(LoadScene));
	}

	private void LoadScene()
	{
		GetTree().ChangeScene(_sceneToLoad);
	}
}
