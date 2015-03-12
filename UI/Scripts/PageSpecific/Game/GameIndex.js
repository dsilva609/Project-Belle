(function() {
  Namespace("Views.Game");

  Views.Game.Index = function() {
    var $deck, cardTemplate, dragId;
    $deck = null;
    cardTemplate = null;
    cardTemplate = null;
    return dragId = null;
  };

  Views.Game.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      var dragId, parent;
      parent = this;
      window.$deck = $("#deck");
      window.cardTemplate = '<div class="card draggable">' + '<div class="front"></div>' + '<div class="back">' + '<span>back</span>' + '</div>' + '</div>';
      dragId = "";
      window.$deck.on("click", function() {
        var card;
        card = window.$deck.find("div.card").detach().hide();
        card.appendTo("#openSlot").show("slow");
        return parent.populateDeck();
      });
      $("div.cardContainer").on("mouseover", "div.card", function() {
        return $(this).draggable({
          revert: true,
          cursor: "move",
          snap: true,
          snapMode: "inner",
          stack: "#card",
          start: function(event, ui) {
            return window.dragId = $(event.target).closest("#deck").attr('id');
          },
          stop: function() {
            if (window.dragId === "deck") {
              return parent.populateDeck();
            }
          }
        });
      });
      $("div.card").droppable({
        stack: "#card",
        drop: function(event, ui) {
          return ui.draggable.insertAfter(this);
        }
      });
      return $("div.droppable").droppable({
        tolerance: "intersect",
        accept: ".card",
        stack: ".card",
        snap: true,
        snapMode: "inner",
        drop: function(event, ui) {
          var target;
          target = $(event.target);
          return $(ui.draggable).appendTo(target);
        }
      });
    };

    Index.prototype.populateDeck = function() {
      $(window.cardTemplate).appendTo("#deck div:eq(0)");
      return window.$deck.find("div.card").hide().fadeIn("slow");
    };

    return Index;

  })();

  $(document).ready(function() {
    var index;
    index = new Views.Game.Index;
    return index.init();
  });

}).call(this);

//# sourceMappingURL=GameIndex.js.map
