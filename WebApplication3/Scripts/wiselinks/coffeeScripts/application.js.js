(function() {
  $(document).ready(function() {
    window.wiselinks = new Wiselinks($('#content'));
    return $(document).off('page:always').on('page:always', function(event, xhr, settings) {
      return $("a").attr("data-push", true);
    });
  });

}).call(this);

//# sourceMappingURL=application.js.js.map
