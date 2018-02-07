function initMenu() {

    $(".main-menu .has-submenu").click(function () {

        var dropIcon = $(".drop-icon", this);
        var $next =  $(this).next();
        $next.slideUp();
        if (!$next.is(":visible")) {
            dropIcon.attr('class', 'fa fa-chevron-up drop-icon');
            $next.slideDown();
        } else {
            dropIcon.attr('class', 'fa fa-chevron-down drop-icon');
        }

    });

}

initMenu();
