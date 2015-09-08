var showSuccess = function (title, message) {
    //new PNotify({
    //    title: title,
    //    text: false,
    //    type: 'success',
    //    icon: false,
    //    animate_speed: 'normal',
    //    delay: 3000,
    //    mouse_reset: false
    //});
    debugger;
    $.notify(message,
        { globalPosition: "top center", className: "success"});
}

var addTopMenusToSideMenu = function () {
    var orderedProducts = '<li class="top-menu"><a href="#"> Tellitud tooted</a></li>';
    var orders = '<li class="top-menu"><a href="#"> Tellimused</a></li>';
    var cart = '<li class="top-menu"><a href="#"><i class="fa fa-shopping-cart fa-lg"></i> Ostukorv</a></li>';
    var logOut = '<li class="top-menu"><a href="#"><i class="fa fa-sign-out fa-lg"></i> Logi välja</a></li>';

    $("#menu-content").children().first().before(logOut)
    $("#menu-content").children().first().before(cart)
    $("#menu-content").children().first().before(orders)
    $("#menu-content").children().first().before(orderedProducts)
}

var removeTopMenusFromSideMenu = function () {
    $("#menu-content").find(".top-menu").remove();
}

var getWindowWidth = function () {
    document.body.style.overflow = "hidden";
    var viewportWidth = $(window).width();
    document.body.style.overflow = "";
    return viewportWidth;
}

$(window).resize(function () {
    var windowWidth = getWindowWidth();
    var topMenusAdded = $("#menu-content").hasClass("collapsed-menu");

    if (windowWidth < 767) {
        if (!topMenusAdded) {
            $("#menu-content").addClass("collapsed-menu");
            addTopMenusToSideMenu();
        }
    }
    else {
        if (topMenusAdded) {
            $("#menu-content").removeClass("collapsed-menu");
            removeTopMenusFromSideMenu();
        }
    }
});

//$(document).ajaxStart(function () {
//    //use global:false on ajax calls that don't need a progress bar
//    alert("Ajax started");
//});
//$(document).ajaxStop(function () {
//    //use global:false on ajax calls that don't need a progress bar
//    alert("Ajax stopped");
//});

var updateCartBadge = function (sum) {
    $.ajax({
        type: "GET",
        url: '/Product/CartLink',
        global: false,
        success: function (data) {
            $("#cartLink").html(data);
            //$("#cart-sum-badge").text("(" + data.totalSum + " €)");
        }
    })
}

var formatDecimalNumber = function (number) {
    return number.replace(",", ".")
}

var addProductToCart = function (url, amount) {
    $.ajax({
        type: "POST",
        url: url,
        data: { amount: amount },
        global: false,
        success: function (data) {
            showSuccess("", "Lisatud ostukorvi!");
            updateCartBadge();
        }
    })
}

var removeProductFromCart = function (url) {
    $.ajax({
        type: "POST",
        url: url,
        global: false,
        success: function (data) {
            $.ajax({
                type: "GET",
                url: "/Product/Cart",
                global: false,
                success: function (data) {
                    $("#main-content").html(data);
                    updateCartBadge();
                }
            })
        }
    })
}

$("body").on("click", ".add-to-cart", function (e) {
    var button = e.target;
    var amountInput = $(button).parent().prev();
    var url = $(button).data("url");
    
    var amount = formatDecimalNumber($(amountInput).val());
    if (amount > 0 && amount != "") {
        amount = $(amountInput).val().replace(/\./g, ',');
        addProductToCart(url, amount);
        $(amountInput).val("");
    }
})
$("body").on("click", ".add-to-cart-details", function (e) {
    var button = e.target;
    var amountInput = $(".product-amount");
    var url = $(button).data("url");
    var amount = formatDecimalNumber($(amountInput).val());

    if (amount > 0 && amount != "") {
        amount = $(amountInput).val().replace(/\./g, ',');
        addProductToCart(url, amount);
        $(amountInput).val("0");
    }
})

$("body").on("mouseenter", "a.product-image",
    function (evt) {
        $('#preview').css({ left: $(this).offset().left - 210, top: $(this).offset().top + 10 }).show();
        $("#preview").attr("src", $(this).data("thumbnail-src"));
        $("#preview").show();
    }
);
$("body").on("mouseleave", "a.product-image",
    function () {
        $("#preview").hide();
    }
);
$("body").on("click", ".remove-from-cart", function (e) {
    var removeUrl = $(this).data("remove-url");
    $(this).closest("tr").hide(300, function () {
        removeProductFromCart(removeUrl);
    });
})

$("body").on("click", ".change-product-amount", function (e) {
    var targetInput = $($(this).data("target"));
    var operation = $(this).data("value");

    var value = parseFloat($(targetInput).val().replace(/\./g, '').replace(',', '.'));
    if (operation == "increase")
        value += 1;
    else
        value -= 1;

    if (value >= 0) {
        value = (Math.round(value * 1000) / 1000).toString().replace('.', ',');
        $(targetInput).val(value);
    }
});

$("body").on("submit", "#cart-update-form", function (e) {
    e.preventDefault();
    var form = e.target;

    $.ajax({
        type: "POST",
        url: form.action,
        data: $(form).serialize(),
        success: function (data) {
            $("#main-content").html(data);
            updateCartBadge();
        }
    })
})

$(document).ready(function () {
    var topMenusAdded = $("#menu-content").hasClass("collapsed-menu");
    if (getWindowWidth() < 767) {
        if (!topMenusAdded) {
            $("#menu-content").addClass("collapsed-menu");
            addTopMenusToSideMenu();
        }
    }
    $("a").attr("data-push", true);
});