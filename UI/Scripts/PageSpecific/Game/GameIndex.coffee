#Usings	
Namespace("Views.Game")

#Initialization
Views.Game.Index = ->
	$deck = null
	cardTemplate = null
	cardTemplate = null
	dragId = null
	
##Implementation
class Views.Game.Index
	init: ->	
		parent = this
		window.$deck = $("#deck")
		window.cardTemplate = 
			'<div class="card draggable">' +
				'<div class="front"></div>' +

				'<div class="back">' +
					'<span>back</span>' +
				'</div>' +
			'</div>'	
		dragId = ""
		
		$("div.card").draggable
			revert: true
			cursor: "move"
			snap: true
			snapMode: "inner"
			stack: "#card"
			start: (event, ui) ->
				window.dragId = $(event.target).parent().parent().attr('id')
			stop: ->
				alert window.dragId
				if window.dragId is "deck"
					alert "empty"
					parent.populateDeck()
			#css: "z-index= 9999"
	
#		$("div#droppable").draggable
#			revert: true
#			cursor: "move"
#			snap: true
#			snapMode: 'inner'
#			stack: "#card"


		$("div.card").droppable
			stack: "#card"
			drop: (event, ui) ->
				ui.draggable.insertAfter this
				#$(this).droppable "option", "droppable", false
						
		$("div.droppable").droppable 
			tolerance: "intersect"
			accept: ".card"
			stack: ".card"
			snap: true
			snapMode: "inner"
			drop: (event, ui) ->
				target = $(event.target);
				$(ui.draggable).appendTo target

		window.$deck.on "click", ->
			alert "new card"
			
	populateDeck: ->
			window.$deck.find("div.cardContainer").append window.cardTemplate
				
$(document).ready ->
	index = new Views.Game.Index
	
	index.init()	