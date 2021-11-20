class_name Item2D extends Node2D

enum ItemType {CONSUMABLE, QUEST_ITEM, TOOL}
enum ItemState {EQUIPPED, DROPPED, STORED, CARRIED}

var item_name := ""
var item_description := ""
var item_icon := ImageTexture.new()
var item_type: int = ItemType.CONSUMABLE
var item_weight := 0.0
var _use: FuncRef

func use() -> void:
	assert(_use != null)
	_use.call_func() 
