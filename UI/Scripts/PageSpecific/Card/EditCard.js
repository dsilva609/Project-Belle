(function() {
  Namespace("Views.Card");

  Views.Card.Edit = function() {};

  Views.Card.Edit = (function() {
    function Edit() {}

    Edit.prototype.init = function() {
      var parent;
      parent = this;
      return $("#btnSubmit").on("click", function(event) {
        if (parseInt($("#rankDropDown").val()) === 0) {
          bootbox.alert("Rank must be selected");
          return event.preventDefault();
        }
      });
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
