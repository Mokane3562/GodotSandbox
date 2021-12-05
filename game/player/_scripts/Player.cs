using Godot;

public class Player : KinematicBody2D
{
	[Export] private int _movementSpeed = 256;

	private AnimationNodeStateMachinePlayback _animationState;
	private AnimationTree _animationTree;

	public override void _Ready()
	{
		_animationTree = GetNode<AnimationTree>("AnimationTree");
		_animationState = (AnimationNodeStateMachinePlayback) _animationTree.Get("parameters/playback");
	}

	public override void _PhysicsProcess(float delta)
	{
		var movementVector = GetPlayerInputVector() * _movementSpeed;
		AnimatePlayerMovement(movementVector);
		MoveAndSlide(movementVector);
	}

	private static Vector2 GetPlayerInputVector()
	{
		Vector2 inputVector = Vector2.Zero;
		inputVector.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
		inputVector.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
		return inputVector.Normalized();
	}

	private void AnimatePlayerMovement(Vector2 movementVector)
	{
		if (movementVector != Vector2.Zero)
		{
			_animationTree.Set("parameters/Idle/blend_position", movementVector);
			_animationTree.Set("parameters/Run/blend_position", movementVector);
			_animationState.Travel("Run");
		}
		else
		{
			_animationState.Travel("Idle");
		}
	}
}
