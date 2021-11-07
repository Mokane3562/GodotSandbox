extends KinematicBody2D

var speed := 10
var player_width := 0
var player_height := 0
var upper_bound := Vector2()
var previous_position := Vector2()


func _ready() -> void:
	upper_bound = get_parent().get_upper_bound()
	player_height = $Sprite.texture.get_height()
	player_width = $Sprite.texture.get_width()
	var rectangle = $CollisionShape2D.shape
	rectangle.extents.x = player_width/2
	rectangle.extents.y = player_height/2
	previous_position = position


func _physics_process(delta: float) -> void:
	var velocity = get_velocity()
	move_and_collide(velocity)	


func get_velocity() -> Vector2:
	var velocity = Vector2()
	if Input.is_action_pressed("ui_down"):
		velocity.y = 1;
	if Input.is_action_pressed("ui_up"):
		velocity.y = -1;
	if Input.is_action_pressed("ui_left"):
		velocity.x = -1;
	if Input.is_action_pressed("ui_right"):
		velocity.x = 1;
	return velocity.normalized() * speed
