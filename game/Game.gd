extends Node

func _ready() -> void:
	play_town_debug()


func play_town_debug() -> void: 
	get_tree().change_scene("res://ui/main_menu/MainMenu.tscn")
