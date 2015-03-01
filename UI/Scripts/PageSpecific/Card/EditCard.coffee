#Usings
Namespace "Views.Card"

#Initialization
Views.Card.Edit = ->

#Implementation
class Views.Card.Edit
	init: ->
		parent = this
		
		$("#btnSubmit").on "click", (event) ->		 
			if parseInt($("#rankDropDown").val()) is 0 
				bootbox.alert "Rank must be selected"
				event.preventDefault()

$ ->
	edit = new Views.Card.Edit
	
	edit.init()