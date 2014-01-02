//define(['plugins/http', 'durandal/app', 'knockout'], function (http, app, ko) {
define(['plugins/http', 'knockout', 'jquery', 'bookblock', 'bxslider', 'range-slider'], 
    function (http, ko, $, bookblock, bxslider, slider) {
    var Home = function () {
        this.BookTitle = ko.observable("Book name");
    };

    var setSliders = function () {
        /* BX slider 1*/
        if ($('.slider1').length) {
            $('.slider1').bxSlider({ slideWidth: 142, minSlides: 1, maxSlides: 8, slideMargin: 18, speed: 1500 });
        }
        if ($('.slider2').length) {
            $('.slider2').bxSlider({ slideWidth: 270, mode: 'horizontal', useCSS: false, easing: 'easeOutElastic', speed: 2000 });
        }
        if ($('.slider3').length) {
            $('.slider3').bxSlider({ slideWidth: 425, minSlides: 1, maxSlides: 2, slideMargin: 0, slideMargin: 18 });
        }
        if ($('.slider4').length) {
            $('.slider4').bxSlider({ mode: 'fade', slideWidth: 270, minSlides: 1, maxSlides: 1, slideMargin: 1, slideMargin: 0 });
        }
        if ($('.slider5').length) {
            $('.slider5').bxSlider({ slideWidth: 870, mode: 'horizontal', useCSS: false, easing: 'easeOutElastic', speed: 2000 });
        }
        if ($('.slider6').length) {
            $('.slider6').bxSlider({ slideWidth: 155, minSlides: 1, maxSlides: 4, slideMargin: 18, speed: 1500 });
        }
        if ($('.slider7').length) {
            $('.slider7').bxSlider({ slideWidth: 1170, mode: 'horizontal', useCSS: false, easing: 'easeOutElastic', speed: 2000 });
        }
        /* BX slider 1*/
        /*Slider Range*/
        $("#slider-range").slider({
            range: true,
            min: 0,
            max: 500,
            values: [75, 300],
            slide: function (event, ui) {
                $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
            }
        });
        $("#amount").val("$" + $("#slider-range").slider("values", 0) +
            " - $" + $("#slider-range").slider("values", 1));
        /*Slider Range**/
    };

    var setFlipSlider = function () {

        var event = $.event,

            //helper that finds handlers by type and calls back a function, this is basically handle
            // events - the events object
            // types - an array of event types to look for
            // callback(type, handlerFunc, selector) - a callback
            // selector - an optional selector to filter with, if there, matches by selector
            //     if null, matches anything, otherwise, matches with no selector
            findHelper = function (events, types, callback, selector) {
                var t, type, typeHandlers, all, h, handle,
                    namespaces, namespace,
                    match;
                for (t = 0; t < types.length; t++) {
                    type = types[t];
                    all = type.indexOf(".") < 0;
                    if (!all) {
                        namespaces = type.split(".");
                        type = namespaces.shift();
                        namespace = new RegExp("(^|\\.)" + namespaces.slice(0).sort().join("\\.(?:.*\\.)?") + "(\\.|$)");
                    }
                    typeHandlers = (events[type] || []).slice(0);

                    for (h = 0; h < typeHandlers.length; h++) {
                        handle = typeHandlers[h];

                        match = (all || namespace.test(handle.namespace));

                        if (match) {
                            if (selector) {
                                if (handle.selector === selector) {
                                    callback(type, handle.origHandler || handle.handler);
                                }
                            } else if (selector === null) {
                                callback(type, handle.origHandler || handle.handler, handle.selector);
                            }
                            else if (!handle.selector) {
                                callback(type, handle.origHandler || handle.handler);

                            }
                        }


                    }
                }
            };

        /**
         * Finds event handlers of a given type on an element.
         * @param {HTMLElement} el
         * @param {Array} types an array of event names
         * @param {String} [selector] optional selector
         * @return {Array} an array of event handlers
         */
        event.find = function (el, types, selector) {
            var events = ($._data(el) || {}).events,
                handlers = [],
                t, liver, live;

            if (!events) {
                return handlers;
            }
            findHelper(events, types, function (type, handler) {
                handlers.push(handler);
            }, selector);
            return handlers;
        };
        /**
         * Finds all events.  Group by selector.
         * @param {HTMLElement} el the element
         * @param {Array} types event types
         */
        event.findBySelector = function (el, types) {
            var events = $._data(el).events,
                selectors = {},
                //adds a handler for a given selector and event
                add = function (selector, event, handler) {
                    var select = selectors[selector] || (selectors[selector] = {}),
                        events = select[event] || (select[event] = []);
                    events.push(handler);
                };

            if (!events) {
                return selectors;
            }
            //first check live:
            /*$.each(events.live || [], function( i, live ) {
                if ( $.inArray(live.origType, types) !== -1 ) {
                    add(live.selector, live.origType, live.origHandler || live.handler);
                }
            });*/
            //then check straight binds
            findHelper(events, types, function (type, handler, selector) {
                add(selector || "", type, handler);
            }, null);

            return selectors;
        };
        event.supportTouch = "ontouchend" in document;

        $.fn.respondsTo = function (events) {
            if (!this.length) {
                return false;
            } else {
                //add default ?
                return event.find(this[0], $.isArray(events) ? events : [events]).length > 0;
            }
        };
        $.fn.triggerHandled = function (event, data) {
            event = (typeof event == "string" ? $.Event(event) : event);
            this.trigger(event, data);
            return event.handled;
        };
        /**
         * Only attaches one event handler for all types ...
         * @param {Array} types llist of types that will delegate here
         * @param {Object} startingEvent the first event to start listening to
         * @param {Object} onFirst a function to call 
         */
        event.setupHelper = function (types, startingEvent, onFirst) {
            if (!onFirst) {
                onFirst = startingEvent;
                startingEvent = null;
            }
            var add = function (handleObj) {

                var bySelector, selector = handleObj.selector || "";
                if (selector) {
                    bySelector = event.find(this, types, selector);
                    if (!bySelector.length) {
                        $(this).delegate(selector, startingEvent, onFirst);
                    }
                }
                else {
                    //var bySelector = event.find(this, types, selector);
                    if (!event.find(this, types, selector).length) {
                        event.add(this, startingEvent, onFirst, {
                            selector: selector,
                            delegate: this
                        });
                    }
                }
            },
                remove = function (handleObj) {
                    var bySelector, selector = handleObj.selector || "";
                    if (selector) {
                        bySelector = event.find(this, types, selector);
                        if (!bySelector.length) {
                            $(this).undelegate(selector, startingEvent, onFirst);
                        }
                    }
                    else {
                        if (!event.find(this, types, selector).length) {
                            event.remove(this, startingEvent, onFirst, {
                                selector: selector,
                                delegate: this
                            });
                        }
                    }
                };
            $.each(types, function () {
                event.special[this] = {
                    add: add,
                    remove: remove,
                    setup: function () { },
                    teardown: function () { }
                };
            });
        };
    };

    var setBookBlocks = function () {
        var Page = (function () {
            var config = {
                $bookBlock: $('#bb-bookblock'),
                $navNext: $('#bb-nav-next'),
                $navPrev: $('#bb-nav-prev'),
                $folder: $('#folder'),
                $folderOpen: $('#folder > div.folder-cover > span'),
                $folderClose: $('#folder > div.folder-inner > a'),
                transEndEventNames: {
                    'WebkitTransition': 'webkitTransitionEnd',
                    'MozTransition': 'transitionend',
                    'OTransition': 'oTransitionEnd',
                    'msTransition': 'MSTransitionEnd',
                    'transition': 'transitionend'
                },
                // init bookBlock!
                bb: $('#bb-bookblock').bookblock({
                    speed: 700,
                    easing: 'ease-out',
                    perspective: 1500,
                    shadowSides: 0.8,
                    shadowFlip: 0.7
                }),
                transitionProperty: {
                    '-webkit-transition': '-webkit-transform 300ms ease-in-out',
                    '-moz-transition': '-moz-transform 300ms ease-in-out',
                    '-o-transition': '-o-transform 300ms ease-in-out',
                    '-ms-transition': '-ms-transform 300ms ease-in-out'
                }
            },
                init = function () {
                    initEvents();
                },
                initEvents = function () {
                    config.$navNext.on('click', function () {
                        checkFolder(function () {
                            config.bb.next();
                        });
                        return false;
                    });
                    config.$navPrev.on('click', function () {
                        checkFolder(function () {
                            config.bb.prev();
                        });
                        return false;
                    });
                    // swipe event : http://jquerypp.com/#swipe
                    config.$bookBlock.children().on({
                        'swipeleft': function (event) {
                            checkFolder(function () {
                                config.bb.next();
                            });
                            return false;
                        },
                        'swiperight': function (event) {
                            checkFolder(function () {
                                config.bb.prev();
                            });
                            return false;
                        }
                    });
                    // folder
                    config.$folderOpen.on('click', function () {
                        var $folder = $(this).closest('div.folder'),
                                open = $folder.data('isOpen');
                        if (config.bb.isActive()) return false;
                        if (!open) {
                            openFolder();
                        }
                        return false;
                    });
                    config.$folderClose.on('click', function () {
                        var $folder = $(this).closest('div.folder'),
                                open = $folder.data('isOpen');
                        if (config.bb.isActive()) return false;
                        if (open) {
                            closeFolder();
                        }
                        return false;
                    });
                },
                openFolder = function () {
                    var $fold = config.$folder.find('div.folder-fold').css(config.transitionProperty),
                        $inner = config.$folder.find('div.folder-inner'),
                        transEndEventName = config.transEndEventNames[Modernizr.prefixed('transition')];
                    setTimeout(function () {
                        $fold.css('transform', 'rotateY(180deg)').on(transEndEventName, function () {
                            $fold.off(transEndEventName).css('z-index', 1).css('transition', 'none').css('transform', 'rotateY(-180deg)');
                            $inner.css('transform', 'translateX(310px)');
                        });
                        config.$folder.data('isOpen', true);
                    }, 0);
                },
                closeFolder = function () {
                    var $fold = config.$folder.find('div.folder-fold'),
                            $inner = config.$folder.find('div.folder-inner'),
                            transEndEventName = config.transEndEventNames[Modernizr.prefixed('transition')];
                    $inner.css('transform', 'translateX(0px)').on(transEndEventName, function () {
                        $inner.off(transEndEventName);
                        $fold.css('transform', 'rotateY(180deg)');
                        setTimeout(function () {
                            $fold.css(config.transitionProperty).css({
                                transform: 'rotateY(0deg)',
                                zIndex: 4
                            }).on(transEndEventName, function () {
                                $fold.off(transEndEventName);
                            });
                        }, 0);
                    });
                    config.$folder.data('isOpen', false);
                },
                checkFolder = function (callback) {
                    var $fold = config.$folder.find('div.folder-fold'),
                            transEndEventName = config.transEndEventNames[Modernizr.prefixed('transition')];
                    if (config.$folder.data('isOpen')) {
                        $fold.on(transEndEventName, function () {
                            $fold.off(transEndEventName);
                            callback.call();
                        });
                        closeFolder();
                    }
                    else {
                        callback.call();
                    }
                };
            return { init: init };
        })();
        Page.init();
    };

    var loadStyles = function ()
    {
        setSliders();
        setFlipSlider();
        setBookBlocks();
    };

    loadStyles();

    return Home;
});