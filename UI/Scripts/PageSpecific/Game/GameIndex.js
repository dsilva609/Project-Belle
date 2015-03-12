(function() {
  Namespace("Views.Game");

  Views.Game.Index = function() {
    var $deck, cardTemplate, deckIsEmpty;
    $deck = null;
    cardTemplate = null;
    deckIsEmpty = null;
    return cardTemplate = null;
  };

  Views.Game.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      var parent;
      parent = this;
      window.$deck = $("#deck");
      window.deckIsEmpty = false;
      window.cardTemplate = '<div class="card draggable">' + '<div class="front"></div>' + '<div class="back">' + '<span>back</span>' + '</div>' + '</div>';
      $("div.card").draggable({
        revert: true,
        cursor: "move",
        snap: true,
        snapMode: "inner",
        stack: "#card"
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
          $(ui.draggable).appendTo(target);
          window.deckIsEmpty = true;
          return parent.populateDeck();
        }
      });
    };

    Index.prototype.populateDeck = function() {
      if (window.deckIsEmpty === true) {
        window.$deck.find("div.cardContainer").append(window.cardTemplate);
        return window.deckIsEmpty = false;
      }
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
