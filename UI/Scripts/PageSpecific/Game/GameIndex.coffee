#Usings	
Namespace("Views.Game")

#Initialization
Views.Game.Index = ->

##Implementation
class Views.Game.Index
	init: ->
		$("div#card").draggable
			revert: true
			cursor: "move"
			snap: true
			snapMode: "inner"
			stack: "#card"
			#css: "z-index= 9999"
	
#		$("div#droppable").draggable
#			revert: true
#			cursor: "move"
#			snap: true
#			snapMode: 'inner'
#			stack: "#card"


		$("div#card").droppable
			stack: "#card"
			drop: (event, ui) ->
				ui.draggable.insertAfter this
				#$(this).droppable "option", "droppable", false
						
		$("div#droppable").droppable 
			tolerance: "intersect"
			accept: "#card"
			stack: "#card"
			snap: true
			snapMode: "inner"
			drop: (event, ui) ->
				alert "qwefghj"
				ui.draggable.insertAfter this	
		
		$(".deck").on "click", ->
			alert "new card"
			
		$(".discard").on "click", ->
			alert "Send 'em to the brig!"
					     			     
                				
$(document).ready ->
	index = new Views.Game.Index
	
	index.init()	