;(function ($) {
  var colLeft = $('.col-left')
  var colRight = $('.col-right')
  var newHeight = $('.uif-listview', colRight).height() - $('.card-list .footer', colRight).outerHeight() - $('.card-list .header', colRight).height()

  $('.card-list .content', colRight).height(newHeight)

  $('.card-list .content', colLeft).slimScroll()

  $('.card-list .content', colRight).slimScroll({
    height: newHeight
  })
})(jQuery)

