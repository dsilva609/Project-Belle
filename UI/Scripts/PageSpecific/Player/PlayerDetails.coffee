#Usings
Namespace "Views.Player"

#Initialization
Views.Player.Details = ->

#Implementation
class Views.Player.Details
	init: ->
		$('[id=playerDeleteBtn]').on "click", ->
			ID = $(this).data "id"
	
			bootbox.dialog 
				message: "Are you sure you want to remove this player?",
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
	details = new Views.Player.Details
	details.init()