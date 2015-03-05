#Usings
Namespace "Views.Player"

#Initialization
Views.Card.Details = ->

#Implementation
class Views.Card.Details
	init: ->
		$('[id=cardDeleteBtn]').on "click", ->
			ID = $(this).data "id"
	
			bootbox.dialog 
				message: "Are you sure you want to remove this card?",
				buttons: 
					cancel: 
						label: "No"
					confirm: 
						label: "Yes"
						className: "btn-danger"
						callback: ->
							window.location.href = deleteUrl + "/" + ID
			return false
$ ->
	details = new Views.Card.Details
	details.init()