class_name Player extends KinematicBody2D

export var movement_speed := 256


func _physics_process(delta: float) -> void:
	var movement_vector = vectorize_player_input(movement_speed)
	move_and_slide(movement_vector)	


func vectorize_player_input(movement_speed: int) -> Vector2:
	var input_vector = Vector2.ZERO
	input_vector.x = Input.get_action_strength("ui_right") - Input.get_action_strength("ui_left")
	input_vector.y = Input.get_action_strength("ui_down") - Input.get_action_strength("ui_up")
	
	if input_vector != Vector2.ZERO:
		return input_vector.normalized() * movement_speed
	else:
		return Vector2.ZERO
