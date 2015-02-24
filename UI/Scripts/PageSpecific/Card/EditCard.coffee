#Usings
Namespace "Views.Card"

#Initialization
Views.Card.Edit = ->

#Implementation
class Views.Card.Edit
	init: ->
		parent = this
		
		parent.disableAndEnableFields()
		
		$("#btnSubmit").on "click", (event) ->		 
			if (parseInt($("#cardTypeDropDown").val()) > 0 and parseInt($("#cardTypeDropDown").val()) < 8) and (parseInt($("#rankDropDown").val()) is 0 or parseInt($("#suitDropDown").val()) is 0)
				bootbox.alert "Rank and suit must be selected"
				event.preventDefault()
			
			if parseInt($("#cardTypeDropDown").val()) is 0
				bootbox.alert "Card type must be selected"
				event.preventDefault()		
		
			if parseInt($("#expansionDropDown").val()) is 0
				bootbox.alert "Expansion must be selected"
				event.preventDefault()
	
		$("#cardTypeDropDown").on "change", ->
			parent.disableAndEnableFields()
			
	disableAndEnableFields: ->
		#this conditional may be incorrect for string comparisons
		if parseInt($("#cardTypeDropDown").val()) >= 8
			$("#rankDropDown").val(0)
			$("#rankDropDown").attr "readonly", true
			$("#rankDropDown").attr "disabled", true
			$("#suitDropDown").val(0)
			$("#suitDropDown").attr "readonly", true
			$("#suitDropDown").attr "disabled", true
			$("#actionField").attr "readonly", true
			$("#actionField").val(null)
			$("#rangeField").attr "disabled", true
		else
			$("#rankDropDown").attr "readonly", false
			$("#rankDropDown").attr "disabled", false
			$("#suitDropDown").attr "readonly", false
			$("#suitDropDown").attr "disabled", false
			$("#actionField").attr "readonly", false
			$("#rangeField").attr "disabled", false

$ ->
	edit = new Views.Card.Edit
	
	edit.init()