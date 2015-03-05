(function() {
  Namespace("Views.Player");

  Views.Player.Details = function() {};

  Views.Player.Details = (function() {
    function Details() {}

    Details.prototype.init = function() {
      return $('[id=playerDeleteBtn]').on("click", function() {
        var ID;
        ID = $(this).data("id");
        bootbox.dialog({
          message: "Are you sure you want to remove this player?",
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
    details = new Views.Player.Details;
    return details.init();
  });

}).call(this);

//# sourceMappingURL=PlayerDetails.js.map
