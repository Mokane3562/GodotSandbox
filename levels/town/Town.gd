extends ColorRect

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


func get_lower_bound():
	var vector = Vector2()
	vector.x = margin_left
	vector.y = margin_top
	return vector


func get_upper_bound():
	var vector = Vector2()
	vector.x = margin_right
	vector.y = margin_bottom
	return vector
