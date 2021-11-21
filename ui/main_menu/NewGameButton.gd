extends Button

export(String) var scene_to_load

func _ready():
	self.connect("pressed", self, "_load_scene")

func _load_scene() -> void:
	get_tree().change_scene(scene_to_load)
