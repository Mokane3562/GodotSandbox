extends Button

func _ready():
	self.connect("pressed", self, "_quit_game")

func _quit_game() -> void:
	get_tree().quit(0)
