class_name Item extends Node2D

enum ItemType {CONSUMABLE, QUEST_ITEM, TOOL}
enum ItemState {EQUIPPED, DROPPED, STORED, CARRIED}

export var item_name := ""
export var item_owner := ""
export var description := ""
var weight := 0.0
var icon := ImageTexture.new()
var type := ItemType.CONSUMABLE as int

