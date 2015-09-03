﻿# CoffeeScript

$(document).ready ->
    # DOM element with id = "content" will be replaced after data load.
    window.wiselinks = new Wiselinks($('#content'))

    $(document).off('page:always').on(
            'page:always'
            (event, xhr, settings) ->
                $("a").attr("data-push", true)
                $(".nav.navbar-top-links.navbar-right > li > a").removeAttr("data-push")
                $(".sidebar-nav>ul li>ul").prev().removeAttr("data-push")
                $('#content :input[type!=hidden]').first().focus()
                loadNewMessages();
        )