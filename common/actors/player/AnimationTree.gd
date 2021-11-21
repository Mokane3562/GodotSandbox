extends AnimationTree

onready var animation_state = self.get("parameters/playback")

func animate_player_movement(movement_vector: Vector2) -> void:
	if movement_vector != Vector2.ZERO:
		self.set("parameters/Idle/blend_position", movement_vector)
		self.set("parameters/Run/blend_position", movement_vector)
		animation_state.travel("Run")
	else:
		animation_state.travel("Idle")
