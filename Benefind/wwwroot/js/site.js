// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.




//Navbar is tranparent on top and setted bg-color when scoll down
//(function ($) {

//    var navbar = $('.navbar');
//    var lastScrollTop = 0;

//    $(window).scroll(function () {
//        var st = $(this).scrollTop();
//        // Scroll down
//        if (st > lastScrollTop) {
//            navbar.fadeOut();
//        }
//        // Scroll up but still lower than 200 (change that to whatever suits your need)
//        else if (st < lastScrollTop && st > 100) {
//            navbar.fadeIn();
//            navbar.removeClass('navbar-light bg-transparent').addClass('navbar-dark bg-custom');
//        }
//        // Reached top
//        else {
//            navbar.removeClass('navbar-dark bg-custom').addClass('navbar-light bg-transparent');
//        }
//        lastScrollTop = st;
//    });

//})(jQuery);