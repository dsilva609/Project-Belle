(function() {
  Namespace("Views.Player");

  Views.Card.Details = function() {};

  Views.Card.Details = (function() {
    function Details() {}

    Details.prototype.init = function() {
      return $('[id=cardDeleteBtn]').on("click", function() {
        var ID;
        ID = $(this).data("id");
        bootbox.dialog({
          message: "Are you sure you want to remove this card?",
          buttons: {
            cancel: {
              label: "No"
            },
            confirm: {
              label: "Yes",
              className: "btn-danger",
              callback: function() {
                return window.location.href = deleteUrl + "/" + ID;
              }
            }
          }
        });
        return false;
      });
    };

    return Details;

  })();

  $(function() {
    var details;
    details = new Views.Card.Details;
    return details.init();
  });

}).call(this);

//# sourceMappingURL=CardDetails.js.map
