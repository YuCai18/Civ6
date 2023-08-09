extends CharacterBody2D


var movement_speed: float = 200.0
# Target 的坐标
var movement_target_position: Vector2 = Vector2(563.0, 310.0)

@onready var navigation_agent: NavigationAgent2D = $NavigationAgent2D

var path_line: Line2D = null

func _ready():
	# These values need to be adjusted for the actor's speed
	# and the navigation layout.
	navigation_agent.path_desired_distance = 4.0
	navigation_agent.target_desired_distance = 4.0
	
	navigation_agent.path_changed.connect(handle_path_changed)

	# Make sure to not await during _ready.
	call_deferred("actor_setup")

func actor_setup():
	# Wait for the first physics frame so the NavigationServer can sync.
	await get_tree().physics_frame

	# Now that the navigation map is no longer empty, set the movement target.
#	set_movement_target(movement_target_position)


func handle_path_changed():
	# 绘制一条路径线
	var path := navigation_agent.get_current_navigation_path()
	var line := Line2D.new()
	line.points = path
	line.default_color = Color.LIGHT_GREEN
	line.width = 5
	if path_line != null:
		path_line.queue_free()
	path_line = line
	get_parent().add_child(line)


func set_movement_target(movement_target: Vector2):
	navigation_agent.target_position = movement_target

func _physics_process(delta):
	if Input.is_action_pressed("shoot"):
		# 向点击的目标点移动
		var target_position: Vector2 = get_global_mouse_position()
		set_movement_target(target_position)
		# 不能在这里绘制路径线，估计是这个时候路径还没生成
	
	if navigation_agent.is_navigation_finished():
		return

	var current_agent_position: Vector2 = global_position
	var next_path_position: Vector2 = navigation_agent.get_next_path_position()

	var new_velocity: Vector2 = next_path_position - current_agent_position
	new_velocity = new_velocity.normalized()
	new_velocity = new_velocity * movement_speed

	velocity = new_velocity
	move_and_slide()
