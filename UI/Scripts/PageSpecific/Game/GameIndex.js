(function() {
  Namespace("Views.Game");

  Views.Game.Index = function() {};

  Views.Game.Index = (function() {
    function Index() {}

    Index.prototype.init = function() {
      $("div#card").draggable({
        revert: true,
        cursor: "move",
        snap: true,
        snapMode: "inner",
        stack: "#card"
      });
      $("div#card").droppable({
        stack: "#card",
        drop: function(event, ui) {
          return ui.draggable.insertAfter(this);
        }
      });
      $("div#droppable").droppable({
        tolerance: "intersect",
        accept: "#card",
        stack: "#card",
        snap: true,
        snapMode: "inner",
        drop: function(event, ui) {
          alert("qwefghj");
          return ui.draggable.insertAfter(this);
        }
      });
      $(".deck").on("click", function() {
        return alert("new card");
      });
      return $(".discard").on("click", function() {
        return alert("Send 'em to the brig!");
      });
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