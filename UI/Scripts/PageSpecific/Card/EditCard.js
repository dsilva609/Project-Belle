(function() {
  Namespace("Views.Card");

  Views.Card.Edit = function() {};

  Views.Card.Edit = (function() {
    function Edit() {}

    Edit.prototype.init = function() {
      var parent;
      parent = this;
      parent.disableAndEnableFields();
      $("#btnSubmit").on("click", function(event) {
        if ((parseInt($("#cardTypeDropDown").val()) > 0 && parseInt($("#cardTypeDropDown").val()) < 8) && (parseInt($("#rankDropDown").val()) === 0 || parseInt($("#suitDropDown").val()) === 0)) {
          bootbox.alert("Rank and suit must be selected");
          event.preventDefault();
        }
        if (parseInt($("#cardTypeDropDown").val()) === 0) {
          bootbox.alert("Card type must be selected");
          event.preventDefault();
        }
        if (parseInt($("#expansionDropDown").val()) === 0) {
          bootbox.alert("Expansion must be selected");
          return event.preventDefault();
        }
      });
      return $("#cardTypeDropDown").on("change", function() {
        return parent.disableAndEnableFields();
      });
    };

    Edit.prototype.disableAndEnableFields = function() {
      if (parseInt($("#cardTypeDropDown").val()) >= 8) {
        $("#rankDropDown").val(0);
        $("#rankDropDown").attr("readonly", true);
        $("#rankDropDown").attr("disabled", true);
        $("#suitDropDown").val(0);
        $("#suitDropDown").attr("readonly", true);
        $("#suitDropDown").attr("disabled", true);
        $("#actionField").attr("readonly", true);
        $("#actionField").val(null);
        return $("#rangeField").attr("disabled", true);
      } else {
        $("#rankDropDown").attr("readonly", false);
        $("#rankDropDown").attr("disabled", false);
        $("#suitDropDown").attr("readonly", false);
        $("#suitDropDown").attr("disabled", false);
        $("#actionField").attr("readonly", false);
        return $("#rangeField").attr("disabled", false);
      }
    };

    return Edit;
  })();

  $(function() {
    var edit;
    edit = new Views.Card.Edit;
    return edit.init();
  });
}).call(this);

//# sourceMappingURL=EditCard.js.map