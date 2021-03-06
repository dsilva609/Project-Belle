﻿(function() {
  Namespace("Views.Card");

  Views.Card.Index = function() {};

  Views.Card.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      $('#cardNameHeader').on("click", function() {
        return $.get("/Card/SortPlayers", {
          sortPreference: "Name"
        }, function() {
          return location.reload();
        });
      });
      $('#rankHeader').on("click", function() {
        return $.get("/Card/SortPlayers", {
          sortPreference: "Rank"
        }, function() {
          return location.reload();
        });
      });
      $('[id=card]').on("click", function() {
        return window.location.href = detailsUrl + "/" + $(this).data("id");
      });
      return $('[id=deleteCard]').on("click", function() {
        var ID;
        ID = $(this).data("id");
        bootbox.dialog({
          message: "Are you sure you want to delete this card?",
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
    index = new Views.Card.Index;
    return index.init();
  });

}).call(this);

//# sourceMappingURL=CardIndex.js.map
