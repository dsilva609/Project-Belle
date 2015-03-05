(function() {
  Namespace("Views.Player");

  Views.Player.Index = function() {};

  Views.Player.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      $('#playerNameHeader').on("click", function() {
        return $.get("/Player/SortPlayers", {
          sortPreference: "Name"
        }, function() {
          return location.reload();
        });
      });
      $('[id=player]').on("click", function() {
        return window.location.href = detailsUrl + "/" + $(this).data("id");
      });
      return $('[id=deletePlayerBtn]').on("click", function() {
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

    return Index;

  })();

  $(function() {
    var index;
    index = new Views.Player.Index;
    return index.init();
  });

}).call(this);

//# sourceMappingURL=PlayerIndex.js.map
