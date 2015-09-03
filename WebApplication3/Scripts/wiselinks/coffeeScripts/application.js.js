(function() {
  $(document).ready(function() {
    window.wiselinks = new Wiselinks($('#content'));
    return $(document).off('page:always').on('page:always', function(event, xhr, settings) {
      $("a").attr("data-push", true);
      $(".nav.navbar-top-links.navbar-right > li > a").removeAttr("data-push");
      $(".sidebar-nav>ul li>ul").prev().removeAttr("data-push");
      $('#content :input[type!=hidden]').first().focus();
      return loadNewMessages();
    });
  });

}).call(this);

//# sourceMappingURL=application.js.js.map
