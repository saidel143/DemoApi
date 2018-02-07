var $page = $(".page");
var $menu = $("nav");
var $header = $('header');
var $menuScroll = $('.main-menu-container .slimScrollDiv');
var $notificationBar = $('.notification-bar');
var $mainContainer = $('.main-container');
var $footer = $('footer');
var menuState = 'closed';
var menuScrollStyle;

$('#datetimepicker1').datetimepicker();
$('#datetimepicker2').datetimepicker();
$('#datetimepicker3').datetimepicker();



//$header.width($header.width());
//$header.addClass('fixed');

$(".toggle-right-bar").click(function(e) {
	e.preventDefault();
	var $rightBar = $('.right-bar');
	var $rightBarToggleBtn = $('.right-bar .fa');
	if ($rightBar.hasClass('right-bar-open')) {
		$rightBarToggleBtn.removeClass('fa-chevron-right');
	} else {
		$rightBarToggleBtn.toggleClass('fa-chevron-right');
	}

	$rightBar.toggleClass('right-bar-open');

});


$(".btn-toggle-main-menu").click(function(e) {
	e.preventDefault();
	if ($("body").width() < 992) {
		if (menuState === 'closed') {
			$menu.attr('style', 'position: absolute; width: 300px; left: 0px;');
			$page.attr('style', 'position: absolute; width: 100%; left:300px;');
			menuState = 'opened';
		} else {
			$menu.attr('style', 'position: absolute; width: 300px; left: -300px;');
			$page.attr('style', 'position: absolute; width: 100%; left:0px;');
			menuState = 'closed';
		}

	} else {
		if ($menu.width() === 0) {
			$menu.width(300);
			$page.attr('style', 'margin-left:300px;');
		} else {
			$menu.width(0);
			$page.attr('style', 'margin-left:0;');
		}

	}

});


$('.scrollable-wrapper').slimScroll({
	height: 'auto'
});


$('.right-bar-scrollable-wrapper').slimScroll({
	height: 'auto'
});

$('.card-container .inner-content').slimScroll({
	height: 'auto'
});

menuScrollStyle = $('.main-menu-container .slimScrollDiv').attr('style');

function setupContent() {
	$('body').height('100%');
	if ($footer.length) {
		$mainContainer.height($('body').height() - $header.height() - $footer.height() - 30);
	} else {
		$mainContainer.height($('body').height() - $header.height());
	}
}

$(window).resize(function() {
	var pageWidth;
	if ($("body").width() < 992) {
		//$menu.removeClass('nav-medium');
		$menu.width(0);
		$page.attr('style', 'margin-left:0;');
	} else {
		$menu.width(300);
		$page.attr('style', 'position: relative; width:auto; margin-left: 300px;');
	}
	setupContent();
});

setupContent();


