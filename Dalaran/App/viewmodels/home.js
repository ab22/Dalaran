define(['plugins/http', 'knockout', 'jquery', 'iosslider', 'webplugins', 'magnificpopup'],
    function (http, ko, $, iosslider, webplugins, magnificpopup) {
        var self;
        var Home = function () {
            self = this;
            this.BookTitle = ko.observable('');
        };

        var slideChange = function (args) {
            $(args.sliderContainerObject).find('.inner').each(function () {
                $(this).removeClass($(this).attr('data-animate'));
            });

            /* start text animation */
            $(args.currentSlideObject).find('.inner').addClass($(args.currentSlideObject).find('.inner').attr('data-animate'));

            /* change slider height */
            var slide_height = $(args.currentSlideObject).outerHeight();
            $(args.sliderContainerObject).css('min-height', slide_height);
            $(args.sliderContainerObject).css('height', 'auto');


            /* add current class to slide */
            $(args.sliderContainerObject).find('.ux_banner').removeClass('current');
            $(args.currentSlideObject).addClass('current');

            /* update bullets */
            $(args.sliderContainerObject).find('.sliderBullets .bullet').removeClass('active');
            $(args.sliderContainerObject).find('.sliderBullets .bullet:eq(' + (args.currentSlideNumber - 1) + ')').addClass('active');
        }

        var slideResize = function(args) {
            /* set height of first slide */
            setTimeout(function () {
                var slide_height = $(args.currentSlideObject).outerHeight();
                $(args.sliderContainerObject).css('min-height', slide_height);
                $(args.sliderContainerObject).css('height', 'auto');
                $(args.sliderContainerObject).find('.center').vAlign();
            }, 300);

        }

        var startSlider = function(args) {
            /* remove spinner when slider is loaded */
            $(args.sliderContainerObject).find('.loading').fadeOut();

            /* add current class to first slide */
            $(args.currentSlideObject).addClass('current');

            /* add parallax class if contains paralaxx slides */
            $(args.sliderContainerObject).find('.ux_parallax').parent().parent().parent().addClass('parallax_slider');

            /* animate first slide */
            $(args.currentSlideObject).find('.inner').addClass($(args.currentSlideObject).find('.inner').attr('data-animate'));

            /* set height of first slide */
            var slide_height = $(args.currentSlideObject).outerHeight();
            $(args.sliderContainerObject).css('min-height', slide_height);
            $(args.sliderContainerObject).css('height', 'auto');

            /* set text position */
            $(args.sliderContainerObject).find('.center').vAlign();


            /* add slider bullets */
            var slide_id = 1;
            $(args.sliderContainerObject).find(".slider > *").each(function () {
                $(args.sliderContainerObject).find('.sliderBullets').append('<div class="bullet" data-slide="' + slide_id + '"></div>');
                slide_id++;
            });

            /* add current class to bullets */
            $(args.sliderContainerObject).find('.sliderBullets .bullet:first').addClass('active');

            /* make bullets clickable */
            $(args.sliderContainerObject).find('.bullet').click(function () {
                $(args.sliderContainerObject).iosSlider('goToSlide', $(this).data('slide'));
            });
        }

        Home.prototype.compositionComplete = function(){
            $('#mainSlider').find('br').remove();

            /* full width slider */
            $('#mainSlider').iosSlider({
                snapToChildren: true,
                desktopClickDrag: true,
                snapFrictionCoefficient: 0.8,
                autoSlideTransTimer: 500,
                infiniteSlider: true,
                autoSlide: true,
                autoSlideTimer: 5000,
                navPrevSelector: $('.next_1305397119'),
                navNextSelector: $('.prev_1305397119'),
                onSliderLoaded: startSlider,
                onSlideChange: slideChange,
                onSliderResize: slideResize,
            });

            $('.ux_banner .center').vAlign();
            
            $('.row ~ br').remove();
            $('.columns ~ br').remove();
            $('.columns ~ p').remove();
        };


        return Home;
    });