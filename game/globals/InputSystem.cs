using Godot;

public class InputSystem : Node
{
    public static Vector2 GetPlayerInputVector()
    {
        var inputVector = Vector2.Zero;
        inputVector.x = Input.GetActionStrength("ui_right") - Input.GetActionStrength("ui_left");
        inputVector.y = Input.GetActionStrength("ui_down") - Input.GetActionStrength("ui_up");
        return inputVector.Normalized();
    }
}
