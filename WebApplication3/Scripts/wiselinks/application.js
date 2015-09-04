$(document).ready(function () {
    window.wiselinks = new Wiselinks($('#main-content'));
    $(document).off('page:loading').on('page:loading', function (event, url, target, render) {
    });
    $(document).off('page:done').on('page:done', function () {
        $("a").attr("data-push", true);
    });
    $(document).off('page:success').on('page:success', function (event, $target, status) {
        return console.log("Wiselinks status: '" + status + "'");
    });
    return $(document).off('page:error').on('page:error', function (event, data, status) {
        return console.log("Wiselinks status: '" + status + "'");
    });
});