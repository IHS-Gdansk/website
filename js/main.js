jQuery(function($) {'use strict';

    // Navigation Scroll
    $(window).scroll(function(event) {
        Scroll();
    });


    $('.slowscroll a').on('click', function(e) {
        e.preventDefault();
        $('html, body').animate({scrollTop: $(this.hash).offset().top - 5}, 1000);
        return false;
    });

    // User define function
    function Scroll() {
        var contentTop   =   [];
        var contentBottom   =   [];
        var winTop      =   $(window).scrollTop();
        var rangeTop    =   200;
        var rangeBottom =   500;
        $('.navbar-collapse').find('.scroll a').each(function(){
            var offTop = $( $(this).attr('href') ).offset().top;
            contentTop.push(offTop);
            contentBottom.push(offTop + $( $(this).attr('href') ).height() );
        })
        $.each( contentTop, function(i){
            if ( winTop > contentTop[i] - rangeTop ){
                $('.navbar-collapse li.scroll')
                .removeClass('active')
                .eq(i).addClass('active');
            }
        })
    }


    // accordian
    $('.accordion-toggle').on('click', function(){
        $(this).closest('.panel-group').children().each(function(){
        $(this).find('>.panel-heading').removeClass('active');
         });

         $(this).closest('.panel-heading').toggleClass('active');
    });

    //Initiat WOW JS
    new WOW().init();

    $(document).ready(function() {
        //Animated Progress
        $('.progress-bar').bind('inview', function(event, visible, visiblePartX, visiblePartY) {
            if (visible) {
                $(this).css('width', $(this).data('width') + '%');
                $(this).unbind('inview');
            }
        });

        //Animated Number
        $.fn.animateNumbers = function(stop, commas, duration, ease) {
            return this.each(function() {
                var $this = $(this);
                var start = parseInt($this.text().replace(/,/g, ""));
                commas = (commas === undefined) ? true : commas;
                $({value: start}).animate({value: stop}, {
                    duration: duration == undefined ? 1000 : duration,
                    easing: ease == undefined ? "swing" : ease,
                    step: function() {
                        $this.text(Math.floor(this.value));
                        if (commas) { $this.text($this.text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,")); }
                    },
                    complete: function() {
                        if (parseInt($this.text()) !== stop) {
                            $this.text(stop);
                            if (commas) { $this.text($this.text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,")); }
                        }
                    }
                });
            });
        };

        $('.animated-number').bind('inview', function(event, visible, visiblePartX, visiblePartY) {
            var $this = $(this);
            if (visible) {
                $this.animateNumbers($this.data('digit'), false, $this.data('duration'));
                $this.unbind('inview');
            }
        });
    });


    var owlCiekawostki = $("#owl-ciekawostki");
    owlCiekawostki.owlCarousel({
        autoPlay : true,
        items : 4, //10 items above 1400px browser width
        itemsDesktop : [1400,3], //3 items between 1400px and 1001px
        itemsDesktopMedium : [1000,2], //2 items between 1000px and 901px
        itemsDesktopSmall : [900,1], //1 item betweem 900px and 601px
        itemsTablet: [600,1], //1 item between 600 and 0
        itemsMobile : false // itemsMobile disabled - inherit from itemsTablet option
    });

    // Custom Navigation Events
    $(".ciekawostki-next").click(function(){
      owlCiekawostki.trigger('owl.next');
    });
    $(".ciekawostki-prev").click(function(){
      owlCiekawostki.trigger('owl.prev');
    });


    var owlWydarzenia = $("#owl-wydarzenia");
    owlWydarzenia.owlCarousel({
        items : 3, //10 items above 1400px browser width
        itemsDesktop : [1400,3], //3 items between 1400px and 1001px
        itemsDesktopMedium : [1000,2], //2 items between 1000px and 901px
        itemsDesktopSmall : [900,1], //1 item betweem 900px and 601px
        itemsTablet: [600,1], //1 item between 600 and 0
        itemsMobile : false // itemsMobile disabled - inherit from itemsTablet option
    });

    // Custom Navigation Events
    $(".wydarzenia-next").click(function(){
      owlWydarzenia.trigger('owl.next');
    });
    $(".wydarzenia-prev").click(function(){
      owlWydarzenia.trigger('owl.prev');
    });

    $('.jumbotron h1')
      .textillate({ in: { effect: 'flipInY' } });

    $('.jumbotron p')
      .textillate({ initialDelay: 1000, in: { delay: 1, shuffle: true } });

    setTimeout(function () {
        $('.fade').addClass('in');
    }, 250);

    setTimeout(function () {
        $('h1.glow').removeClass('in');
    }, 2000);


    $('.collapse').collapse({
         toggle: false
    });

    $('.collapse').on('shown.bs.collapse', function () {
           $('.collapse').not($(this)).collapse('hide');
    });

    //Google Map
    /*
    var latitude = $('#google-map').data('latitude');
    var longitude = $('#google-map').data('longitude');
    function initialize_map() {
        var myLatlng = new google.maps.LatLng(latitude,longitude);
        var mapOptions = {
            zoom: 14,
            scrollwheel: false,
            center: myLatlng
        };
        var map = new google.maps.Map(document.getElementById('google-map'), mapOptions);
        google.maps.event.addDomListener(window, 'resize', function() {
            var center = map.getCenter();
            google.maps.event.trigger(map, 'resize');
            map.setCenter(center);
        });
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map
        });
    }
    google.maps.event.addDomListener(window, 'load', initialize_map);
    */
});
