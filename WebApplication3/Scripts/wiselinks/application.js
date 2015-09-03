$(document).ready(function () {
    window.wiselinks = new Wiselinks($('#main-content'));
    $(document).off('page:loading').on('page:loading', function (event, url, target, render) {
        return console.log("Wiselinks loading: " + url + " to " + target + " within '" + render + "'");
    });
    $(document).off('page:complete').on('page:complete', function (event, xhr, settings) {
        $("a").attr("data-push", true);
        return console.log("Wiselinks page loading completed");
    });
    $(document).off('page:success').on('page:success', function (event, $target, status) {
        return console.log("Wiselinks status: '" + status + "'");
    });
    return $(document).off('page:error').on('page:error', function (event, data, status) {
        return console.log("Wiselinks status: '" + status + "'");
    });
});