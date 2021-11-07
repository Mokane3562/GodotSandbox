extends ColorRect


func get_lower_bound() -> Vector2:
	var vector = Vector2()
	vector.x = margin_left
	vector.y = margin_top
	return vector


func get_upper_bound() -> Vector2:
	var vector = Vector2()
	vector.x = margin_right
	vector.y = margin_bottom
	return vector
