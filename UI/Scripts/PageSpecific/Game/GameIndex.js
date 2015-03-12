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
      $("div.card").draggable({
        revert: true,
        cursor: "move",
        snap: true,
        snapMode: "inner",
        stack: "#card",
        start: function(event, ui) {
          return window.dragId = $(event.target).parent().parent().attr('id');
        },
        stop: function() {
          alert(window.dragId);
          if (window.dragId === "deck") {
            alert("empty");
            return parent.populateDeck();
          }
        }
      });
      $("div.card").droppable({
        stack: "#card",
        drop: function(event, ui) {
          return ui.draggable.insertAfter(this);
        }
      });
      $("div.droppable").droppable({
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
      return window.$deck.on("click", function() {
        return alert("new card");
      });
    };

    Index.prototype.populateDeck = function() {
      return window.$deck.find("div.cardContainer").append(window.cardTemplate);
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
