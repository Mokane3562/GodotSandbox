class_name Player extends KinematicBody2D

export var movement_speed := 256

func _physics_process(delta: float) -> void:
	var movement_vector := InputSystem.vectorize_player_input() * movement_speed
	$AnimationTree.animate_player_movement(movement_vector)
	move_and_slide(movement_vector)
