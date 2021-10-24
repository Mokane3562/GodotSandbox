extends KinematicBody2D

var speed = 10
var upper_bound
var player_width
var player_height
var previous_position

# Called when the node enters the scene tree for the first time.
func _ready():
	upper_bound = get_parent().get_upper_bound()
	player_height = $Sprite.texture.get_height()
	player_width = $Sprite.texture.get_width()
	var rectangle = $CollisionShape2D.shape
	rectangle.extents.x = player_width/2
	rectangle.extents.y = player_height/2
	previous_position = position


func get_velocity():
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


func _physics_process(delta):
	var velocity = get_velocity()
	move_and_collide(velocity)


