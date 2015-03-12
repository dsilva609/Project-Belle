#Usings	
Namespace("Views.Game")

#Initialization
Views.Game.Index = ->
	$deck = null
	cardTemplate = null
	deckIsEmpty = null
	cardTemplate = null

##Implementation
class Views.Game.Index
	init: ->	
		parent = this
		window.$deck = $("#deck")
		window.deckIsEmpty = false;
		window.cardTemplate = 
			'<div class="card draggable">' +
				'<div class="front"></div>' +

				'<div class="back">' +
					'<span>back</span>' +
				'</div>' +
			'</div>'	
		
		$("div.card").draggable
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
				window.deckIsEmpty = true
				parent.populateDeck()

		
#		this.$deck.find("div.cardContainer").draggable
#			#disabled: true
#			out: ->

#				$("#deck").find("div.cardContainer").append this.cardTemplate
#		

#		this.$deck.on "click", ->
#			alert "new card"

			
	populateDeck: ->
		if window.deckIsEmpty is true
			window.$deck.find("div.cardContainer").append window.cardTemplate
			window.deckIsEmpty = false
				
$(document).ready ->
	index = new Views.Game.Index
	
	index.init()	