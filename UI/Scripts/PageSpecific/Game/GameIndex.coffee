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
		
		window.$deck.on "click", ->
			card = window.$deck.find("div.card").detach().hide()
			card.appendTo("#openSlot").show "slow"
			parent.populateDeck()
		
		$("div.cardContainer").on "mouseover", "div.card", ->
			$(this).draggable
				revert: true
				cursor: "move"
				snap: true
				snapMode: "inner"
				stack: "#card"
				start: (event, ui) ->
					window.dragId = $(event.target).closest("#deck").attr('id')
				stop: ->
					if window.dragId is "deck"
						parent.populateDeck()
	
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
			
	populateDeck: ->		
		$(window.cardTemplate).appendTo("#deck div:eq(0)")
		window.$deck.find("div.card").hide().fadeIn "slow"
		
$(document).ready ->
	index = new Views.Game.Index
	
	index.init()	