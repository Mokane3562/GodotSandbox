extends KinematicBody2D

export var movement_speed := 256
onready var animation_state = $AnimationTree.get("parameters/playback")

func _physics_process(delta: float) -> void:
	var movement_vector := vectorize_player_input() * movement_speed
	animate_player_movement(movement_vector)
	move_and_slide(movement_vector)

func animate_player_movement(movement_vector: Vector2) -> void:
	if movement_vector != Vector2.ZERO:
		$AnimationTree.set("parameters/Idle/blend_position", movement_vector)
		$AnimationTree.set("parameters/Run/blend_position", movement_vector)
		animation_state.travel("Run")
	else:
		animation_state.travel("Idle")
		
		
static func vectorize_player_input() -> Vector2:
	var input_vector := Vector2.ZERO
	input_vector.x = Input.get_action_strength("ui_right") - Input.get_action_strength("ui_left")
	input_vector.y = Input.get_action_strength("ui_down") - Input.get_action_strength("ui_up")
	
	if input_vector != Vector2.ZERO:
		return input_vector.normalized()
	else:
		return Vector2.ZERO
