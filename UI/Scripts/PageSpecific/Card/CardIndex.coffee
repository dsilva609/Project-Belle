#Usings
Namespace("Views.Card")

#Initialization
Views.Card.Index  = ->

#Implementation
class Views.Card.Index
	init: ->
		$('#cardNameHeader').on "click", ->
			$.get "/Card/SortPlayers", sortPreference: "Name", -> location.reload()	
			
		$('#cardTypeHeader').on "click", ->
			$.get "/Card/SortPlayers", sortPreference: "CardType", -> location.reload()	
	
		$('#cardExpansionHeader').on "click", ->
			$.get "/Card/SortPlayers", sortPreference: "Expansion", -> location.reload()	
	
		$('[id=card]').on "click", ->
			window.location.href = redirectURL + "/" + $(this).data "id"

		$('[id=deleteCard]').on "click", ->
			ID = $(this).data "id"
	
			bootbox.dialog 
				message: "Are you sure you want to delete this card?",
				buttons: 
					cancel: 
						label: "No"
					confirm: 
						label: "Yes"
						className: "btn-danger"
						callback: ->
							window.location.href = deleteURL + "/" + ID
			return false

$ ->
	index = new Views.Card.Index
	
	index.init()

