var my_skins = ["skin-blue", "skin-black", "skin-red", "skin-yellow", "skin-purple", "skin-green"];
$(function () {
  /* For demo purposes */
  var demo = $("<div />").css({
    position: "fixed",
    top: "70px",
    right: "0",
    background: "#fff",
    "border-radius": "5px 0px 0px 5px",
    padding: "10px 15px",
    "font-size": "16px",
    "z-index": "99999",
    cursor: "pointer",
    color: "#3c8dbc",
    "box-shadow": "0 1px 3px rgba(0,0,0,0.1)"
  }).html("<i class='fa fa-gear'></i>").addClass("no-print");

  var demo_settings = $("<div />").css({
    "padding": "10px",
    position: "fixed",
    top: "70px",
    right: "-250px",
    background: "#fff",
    border: "0px solid #ddd",
    "width": "250px",
    "z-index": "99999",
    "box-shadow": "0 1px 3px rgba(0,0,0,0.1)"
  }).addClass("no-print");
  demo_settings.append(
          "<h4 class='text-light-blue' style='margin: 0 0 5px 0; border-bottom: 1px solid #ddd; padding-bottom: 15px;'>Layout Options</h4>"
          //Fixed layout
          + "<div class='form-group'>"
          + "<div class='checkbox'>"
          + "<label>"
          + "<input type='checkbox' onchange='change_layout(\"fixed\");'/> "
          + "Fixed layout"
          + "</label>"
          + "</div>"
          + "</div>"
          //Boxed layout
          + "<div class='form-group'>"
          + "<div class='checkbox'>"
          + "<label>"
          + "<input type='checkbox' onchange='change_layout(\"layout-boxed\");'/> "
          + "Boxed Layout"
          + "</label>"
          + "</div>"
          + "</div>"
          //Sidebar Collapse
          + "<div class='form-group'>"
          + "<div class='checkbox'>"
          + "<label>"
          + "<input type='checkbox' onchange='change_layout(\"sidebar-collapse\");'/> "
          + "Collapsed Sidebar"
          + "</label>"
          + "</div>"
          + "</div>"
          );
  var skins_list = $("<ul />", {"class": 'list-unstyled'});
  var skin_blue =
          $("<li />", {style: "float:left; width: 50%; padding: 5px;"})
          .append("<a href='javascript:void(0);' onclick='change_skin(\"skin-blue\")' style='display: block; box-shadow: -1px 1px 2px rgba(0,0,0,0.0);' class='clearfix full-opacity-hover'>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 10px; background: #367fa9;'></span><span class='bg-light-blue' style='display:block; width: 80%; float: left; height: 10px;'></span></div>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 40px; background: #222d32;'></span><span style='display:block; width: 80%; float: left; height: 40px; background: #f4f5f7;'></span></div>"
                  + "<p class='text-center'>Skin Blue</p>"
                  + "</a>");
  skins_list.append(skin_blue);
  var skin_black =
          $("<li />", {style: "float:left; width: 50%; padding: 5px;"})
          .append("<a href='javascript:void(0);' onclick='change_skin(\"skin-black\")' style='display: block; box-shadow: -1px 1px 2px rgba(0,0,0,0.0);' class='clearfix full-opacity-hover'>"
                  + "<div style='box-shadow: 0 0 2px rgba(0,0,0,0.1)' class='clearfix'><span style='display:block; width: 20%; float: left; height: 10px; background: #fefefe;'></span><span style='display:block; width: 80%; float: left; height: 10px; background: #fefefe;'></span></div>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 40px; background: #222;'></span><span style='display:block; width: 80%; float: left; height: 40px; background: #f4f5f7;'></span></div>"
                  + "<p class='text-center'>Skin Black</p>"
                  + "</a>");
  skins_list.append(skin_black);
  var skin_purple =
          $("<li />", {style: "float:left; width: 50%; padding: 5px;"})
          .append("<a href='javascript:void(0);' onclick='change_skin(\"skin-purple\")' style='display: block; box-shadow: -1px 1px 2px rgba(0,0,0,0.0);' class='clearfix full-opacity-hover'>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 10px;' class='bg-purple-active'></span><span class='bg-purple' style='display:block; width: 80%; float: left; height: 10px;'></span></div>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 40px; background: #222d32;'></span><span style='display:block; width: 80%; float: left; height: 40px; background: #f4f5f7;'></span></div>"
                  + "<p class='text-center'>Skin Purple</p>"
                  + "</a>");
  skins_list.append(skin_purple);
  var skin_green =
          $("<li />", {style: "float:left; width: 50%; padding: 5px;"})
          .append("<a href='javascript:void(0);' onclick='change_skin(\"skin-green\")' style='display: block; box-shadow: -1px 1px 2px rgba(0,0,0,0.0);' class='clearfix full-opacity-hover'>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 10px;' class='bg-green-active'></span><span class='bg-green' style='display:block; width: 80%; float: left; height: 10px;'></span></div>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 40px; background: #222d32;'></span><span style='display:block; width: 80%; float: left; height: 40px; background: #f4f5f7;'></span></div>"
                  + "<p class='text-center'>Skin Green</p>"
                  + "</a>");
  skins_list.append(skin_green);
    var skin_red =
          $("<li />", {style: "float:left; width: 50%; padding: 5px;"})
          .append("<a href='javascript:void(0);' onclick='change_skin(\"skin-red\")' style='display: block; box-shadow: -1px 1px 2px rgba(0,0,0,0.0);' class='clearfix full-opacity-hover'>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 10px;' class='bg-red-active'></span><span class='bg-red' style='display:block; width: 80%; float: left; height: 10px;'></span></div>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 40px; background: #222d32;'></span><span style='display:block; width: 80%; float: left; height: 40px; background: #f4f5f7;'></span></div>"
                  + "<p class='text-center'>Skin Red</p>"
                  + "</a>");
  skins_list.append(skin_red);
    var skin_yellow =
          $("<li />", {style: "float:left; width: 50%; padding: 5px;"})
          .append("<a href='javascript:void(0);' onclick='change_skin(\"skin-yellow\")' style='display: block; box-shadow: -1px 1px 2px rgba(0,0,0,0.0);' class='clearfix full-opacity-hover'>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 10px;' class='bg-yellow-active'></span><span class='bg-yellow' style='display:block; width: 80%; float: left; height: 10px;'></span></div>"
                  + "<div><span style='display:block; width: 20%; float: left; height: 40px; background: #222d32;'></span><span style='display:block; width: 80%; float: left; height: 40px; background: #f4f5f7;'></span></div>"
                  + "<p class='text-center'>Skin Yellow</p>"
                  + "</a>");
  skins_list.append(skin_yellow);

  demo_settings.append("<h4 class='text-light-blue' style='margin: 0 0 5px 0; border-bottom: 1px solid #ddd; padding-bottom: 15px;'>Skins</h4>");
  demo_settings.append(skins_list);

  demo.click(function () {
    if (!$(this).hasClass("open")) {
      $(this).animate({"right": "250px"});
      demo_settings.animate({"right": "0"});
      $(this).addClass("open");
    } else {
      $(this).animate({"right": "0"});
      demo_settings.animate({"right": "-250px"});
      $(this).removeClass("open");
    }
  });

  $("body").append(demo);
  $("body").append(demo_settings);

  setup();
});

function change_layout(cls) {
  $("body").toggleClass(cls);
  $.AdminLTE.layout.fixSidebar();  
}
function change_skin(cls) {  
  $.each(my_skins, function (i) {
    $("body").removeClass(my_skins[i]);
  });

  $("body").addClass(cls);
  store('skin', cls);
  return false;
}
function store(name, val) {
  if (typeof (Storage) !== "undefined") {
    localStorage.setItem(name, val);
  } else {
    alert('Please use a modern browser to properly view this template!');
  }
}
function get(name) {
  if (typeof (Storage) !== "undefined") {
    return localStorage.getItem(name);
  } else {
    alert('Please use a modern browser to properly view this template!');
  }
}

function setup() {
  var tmp = get('skin');
  if (tmp && $.inArray(tmp, my_skins))
    change_skin(tmp);
}


$(function () {

    /* initialize the external events
     -----------------------------------------------------------------*/
    function ini_events(ele) {
        ele.each(function () {

            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
            // it doesn't need to have a start or end
            var eventObject = {
                title: $.trim($(this).text()) // use the element's text as the event title
            };

            // store the Event Object in the DOM element so we can get to it later
            $(this).data('eventObject', eventObject);

            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 1070,
                revert: true, // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            });

        });
    }
    ini_events($('#external-events div.external-event'));

    /* initialize the calendar
     -----------------------------------------------------------------*/
    //Date for the calendar events (dummy data)
    var date = new Date();
    var d = date.getDate(),
        m = date.getMonth(),
        y = date.getFullYear();
    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        buttonText: {
            today: 'today',
            month: 'month',
            week: 'week',
            day: 'day'
        },
        //Random default events
        events: [
            {
                title: 'All Day Event',
                start: new Date(y, m, 1),
                backgroundColor: "#f56954", //red
                borderColor: "#f56954" //red
            },
            {
                title: 'Long Event',
                start: new Date(y, m, d - 5),
                end: new Date(y, m, d - 2),
                backgroundColor: "#f39c12", //yellow
                borderColor: "#f39c12" //yellow
            },
            {
                title: 'Meeting',
                start: new Date(y, m, d, 10, 30),
                allDay: false,
                backgroundColor: "#0073b7", //Blue
                borderColor: "#0073b7" //Blue
            },
            {
                title: 'Lunch',
                start: new Date(y, m, d, 12, 0),
                end: new Date(y, m, d, 14, 0),
                allDay: false,
                backgroundColor: "#00c0ef", //Info (aqua)
                borderColor: "#00c0ef" //Info (aqua)
            },
            {
                title: 'Birthday Party',
                start: new Date(y, m, d + 1, 19, 0),
                end: new Date(y, m, d + 1, 22, 30),
                allDay: false,
                backgroundColor: "#00a65a", //Success (green)
                borderColor: "#00a65a" //Success (green)
            },
            {
                title: 'Click for Google',
                start: new Date(y, m, 28),
                end: new Date(y, m, 29),
                url: 'http://google.com/',
                backgroundColor: "#3c8dbc", //Primary (light-blue)
                borderColor: "#3c8dbc" //Primary (light-blue)
            }
        ],
        editable: true,
        droppable: true, // this allows things to be dropped onto the calendar !!!
        drop: function (date, allDay) { // this function is called when something is dropped

            // retrieve the dropped element's stored Event Object
            var originalEventObject = $(this).data('eventObject');

            // we need to copy it, so that multiple events don't have a reference to the same object
            var copiedEventObject = $.extend({}, originalEventObject);

            // assign it the date that was reported
            copiedEventObject.start = date;
            copiedEventObject.allDay = allDay;
            copiedEventObject.backgroundColor = $(this).css("background-color");
            copiedEventObject.borderColor = $(this).css("border-color");

            // render the event on the calendar
            // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
            $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

            // is the "remove after drop" checkbox checked?
            if ($('#drop-remove').is(':checked')) {
                // if so, remove the element from the "Draggable Events" list
                $(this).remove();
            }

        }
    });

    /* ADDING EVENTS */
    var currColor = "#3c8dbc"; //Red by default
    //Color chooser button
    var colorChooser = $("#color-chooser-btn");
    $("#color-chooser > li > a").click(function (e) {
        e.preventDefault();
        //Save color
        currColor = $(this).css("color");
        //Add color effect to button
        $('#add-new-event').css({ "background-color": currColor, "border-color": currColor });
    });
    $("#add-new-event").click(function (e) {
        e.preventDefault();
        //Get value and make sure it is not null
        var val = $("#new-event").val();
        if (val.length == 0) {
            return;
        }

        //Create events
        var event = $("<div />");
        event.css({ "background-color": currColor, "border-color": currColor, "color": "#fff" }).addClass("external-event");
        event.html(val);
        $('#external-events').prepend(event);

        //Add draggable funtionality
        ini_events(event);

        //Remove event from text input
        $("#new-event").val("");
    });
});


$(function () {
    $("#example1").dataTable();
    $('#example2').dataTable({
        "bPaginate": true,
        "bLengthChange": false,
        "bFilter": false,
        "bSort": true,
        "bInfo": true,
        "bAutoWidth": false
    });
});

$(function () {

    /*
     * Flot Interactive Chart
     * -----------------------
     */
    // We use an inline data source in the example, usually data would
    // be fetched from a server
    var data = [], totalPoints = 100;
    function getRandomData() {

        if (data.length > 0)
            data = data.slice(1);

        // Do a random walk
        while (data.length < totalPoints) {

            var prev = data.length > 0 ? data[data.length - 1] : 50,
                    y = prev + Math.random() * 10 - 5;

            if (y < 0) {
                y = 0;
            } else if (y > 100) {
                y = 100;
            }

            data.push(y);
        }

        // Zip the generated y values with the x values
        var res = [];
        for (var i = 0; i < data.length; ++i) {
            res.push([i, data[i]]);
        }

        return res;
    }

    var interactive_plot = $.plot("#interactive", [getRandomData()], {
        grid: {
            borderColor: "#f3f3f3",
            borderWidth: 1,
            tickColor: "#f3f3f3"
        },
        series: {
            shadowSize: 0, // Drawing is faster without shadows
            color: "#3c8dbc"
        },
        lines: {
            fill: true, //Converts the line chart to area chart
            color: "#3c8dbc"
        },
        yaxis: {
            min: 0,
            max: 100,
            show: true
        },
        xaxis: {
            show: true
        }
    });

    var updateInterval = 500; //Fetch data ever x milliseconds
    var realtime = "on"; //If == to on then fetch data every x seconds. else stop fetching
    function update() {

        interactive_plot.setData([getRandomData()]);

        // Since the axes don't change, we don't need to call plot.setupGrid()
        interactive_plot.draw();
        if (realtime === "on")
            setTimeout(update, updateInterval);
    }

    //INITIALIZE REALTIME DATA FETCHING
    if (realtime === "on") {
        update();
    }
    //REALTIME TOGGLE
    $("#realtime .btn").click(function () {
        if ($(this).data("toggle") === "on") {
            realtime = "on";
        }
        else {
            realtime = "off";
        }
        update();
    });
    /*
     * END INTERACTIVE CHART
     */


    /*
     * LINE CHART
     * ----------
     */
    //LINE randomly generated data

    var sin = [], cos = [];
    for (var i = 0; i < 14; i += 0.5) {
        sin.push([i, Math.sin(i)]);
        cos.push([i, Math.cos(i)]);
    }
    var line_data1 = {
        data: sin,
        color: "#3c8dbc"
    };
    var line_data2 = {
        data: cos,
        color: "#00c0ef"
    };
    $.plot("#line-chart", [line_data1, line_data2], {
        grid: {
            hoverable: true,
            borderColor: "#f3f3f3",
            borderWidth: 1,
            tickColor: "#f3f3f3"
        },
        series: {
            shadowSize: 0,
            lines: {
                show: true
            },
            points: {
                show: true
            }
        },
        lines: {
            fill: false,
            color: ["#3c8dbc", "#f56954"]
        },
        yaxis: {
            show: true,
        },
        xaxis: {
            show: true
        }
    });
    //Initialize tooltip on hover
    $("<div class='tooltip-inner' id='line-chart-tooltip'></div>").css({
        position: "absolute",
        display: "none",
        opacity: 0.8
    }).appendTo("body");
    $("#line-chart").bind("plothover", function (event, pos, item) {

        if (item) {
            var x = item.datapoint[0].toFixed(2),
                    y = item.datapoint[1].toFixed(2);

            $("#line-chart-tooltip").html(item.series.label + " of " + x + " = " + y)
                    .css({ top: item.pageY + 5, left: item.pageX + 5 })
                    .fadeIn(200);
        } else {
            $("#line-chart-tooltip").hide();
        }

    });
    /* END LINE CHART */

    /*
     * FULL WIDTH STATIC AREA CHART
     * -----------------
     */
    var areaData = [[2, 88.0], [3, 93.3], [4, 102.0], [5, 108.5], [6, 115.7], [7, 115.6],
      [8, 124.6], [9, 130.3], [10, 134.3], [11, 141.4], [12, 146.5], [13, 151.7], [14, 159.9],
      [15, 165.4], [16, 167.8], [17, 168.7], [18, 169.5], [19, 168.0]];
    $.plot("#area-chart", [areaData], {
        grid: {
            borderWidth: 0
        },
        series: {
            shadowSize: 0, // Drawing is faster without shadows
            color: "#00c0ef"
        },
        lines: {
            fill: true //Converts the line chart to area chart
        },
        yaxis: {
            show: false
        },
        xaxis: {
            show: false
        }
    });

    /* END AREA CHART */

    /*
     * BAR CHART
     * ---------
     */

    var bar_data = {
        data: [["January", 10], ["February", 8], ["March", 4], ["April", 13], ["May", 17], ["June", 9]],
        color: "#3c8dbc"
    };
    $.plot("#bar-chart", [bar_data], {
        grid: {
            borderWidth: 1,
            borderColor: "#f3f3f3",
            tickColor: "#f3f3f3"
        },
        series: {
            bars: {
                show: true,
                barWidth: 0.5,
                align: "center"
            }
        },
        xaxis: {
            mode: "categories",
            tickLength: 0
        }
    });
    /* END BAR CHART */

    /*
     * DONUT CHART
     * -----------
     */

    var donutData = [
      { label: "Series2", data: 30, color: "#3c8dbc" },
      { label: "Series3", data: 20, color: "#0073b7" },
      { label: "Series4", data: 50, color: "#00c0ef" }
    ];
    $.plot("#donut-chart", donutData, {
        series: {
            pie: {
                show: true,
                radius: 1,
                innerRadius: 0.5,
                label: {
                    show: true,
                    radius: 2 / 3,
                    formatter: labelFormatter,
                    threshold: 0.1
                }

            }
        },
        legend: {
            show: false
        }
    });
    /*
     * END DONUT CHART
     */

});

/*
 * Custom Label formatter
 * ----------------------
 */
function labelFormatter(label, series) {
    return "<div style='font-size:13px; text-align:center; padding:2px; color: #fff; font-weight: 600;'>"
            + label
            + "<br/>"
            + Math.round(series.percent) + "%</div>";
}


$(function () {
    /* jQueryKnob */

    $(".knob").knob({
        /*change : function (value) {
         //console.log("change : " + value);
         },
         release : function (value) {
         console.log("release : " + value);
         },
         cancel : function () {
         console.log("cancel : " + this.value);
         },*/
        draw: function () {

            // "tron" case
            if (this.$.data('skin') == 'tron') {

                var a = this.angle(this.cv)  // Angle
                    , sa = this.startAngle          // Previous start angle
                    , sat = this.startAngle         // Start angle
                    , ea                            // Previous end angle
                    , eat = sat + a                 // End angle
                    , r = true;

                this.g.lineWidth = this.lineWidth;

                this.o.cursor
                    && (sat = eat - 0.3)
                    && (eat = eat + 0.3);

                if (this.o.displayPrevious) {
                    ea = this.startAngle + this.angle(this.value);
                    this.o.cursor
                        && (sa = ea - 0.3)
                        && (ea = ea + 0.3);
                    this.g.beginPath();
                    this.g.strokeStyle = this.previousColor;
                    this.g.arc(this.xy, this.xy, this.radius - this.lineWidth, sa, ea, false);
                    this.g.stroke();
                }

                this.g.beginPath();
                this.g.strokeStyle = r ? this.o.fgColor : this.fgColor;
                this.g.arc(this.xy, this.xy, this.radius - this.lineWidth, sat, eat, false);
                this.g.stroke();

                this.g.lineWidth = 2;
                this.g.beginPath();
                this.g.strokeStyle = this.o.fgColor;
                this.g.arc(this.xy, this.xy, this.radius - this.lineWidth + 1 + this.lineWidth * 2 / 3, 0, 2 * Math.PI, false);
                this.g.stroke();

                return false;
            }
        }
    });
    /* END JQUERY KNOB */

    //INITIALIZE SPARKLINE CHARTS
    $(".sparkline").each(function () {
        var $this = $(this);
        $this.sparkline('html', $this.data());
    });

    /* SPARKLINE DOCUMENTAION EXAMPLES http://omnipotent.net/jquery.sparkline/#s-about */
    drawDocSparklines();
    drawMouseSpeedDemo();

});
function drawDocSparklines() {

    // Bar + line composite charts
    $('#compositebar').sparkline('html', { type: 'bar', barColor: '#aaf' });
    $('#compositebar').sparkline([4, 1, 5, 7, 9, 9, 8, 7, 6, 6, 4, 7, 8, 4, 3, 2, 2, 5, 6, 7],
        { composite: true, fillColor: false, lineColor: 'red' });


    // Line charts taking their values from the tag
    $('.sparkline-1').sparkline();

    // Larger line charts for the docs
    $('.largeline').sparkline('html',
        { type: 'line', height: '2.5em', width: '4em' });

    // Customized line chart
    $('#linecustom').sparkline('html',
        {
            height: '1.5em', width: '8em', lineColor: '#f00', fillColor: '#ffa',
            minSpotColor: false, maxSpotColor: false, spotColor: '#77f', spotRadius: 3
        });

    // Bar charts using inline values
    $('.sparkbar').sparkline('html', { type: 'bar' });

    $('.barformat').sparkline([1, 3, 5, 3, 8], {
        type: 'bar',
        tooltipFormat: '{{value:levels}} - {{value}}',
        tooltipValueLookups: {
            levels: $.range_map({ ':2': 'Low', '3:6': 'Medium', '7:': 'High' })
        }
    });

    // Tri-state charts using inline values
    $('.sparktristate').sparkline('html', { type: 'tristate' });
    $('.sparktristatecols').sparkline('html',
        { type: 'tristate', colorMap: { '-2': '#fa7', '2': '#44f' } });

    // Composite line charts, the second using values supplied via javascript
    $('#compositeline').sparkline('html', { fillColor: false, changeRangeMin: 0, chartRangeMax: 10 });
    $('#compositeline').sparkline([4, 1, 5, 7, 9, 9, 8, 7, 6, 6, 4, 7, 8, 4, 3, 2, 2, 5, 6, 7],
        { composite: true, fillColor: false, lineColor: 'red', changeRangeMin: 0, chartRangeMax: 10 });

    // Line charts with normal range marker
    $('#normalline').sparkline('html',
        { fillColor: false, normalRangeMin: -1, normalRangeMax: 8 });
    $('#normalExample').sparkline('html',
        { fillColor: false, normalRangeMin: 80, normalRangeMax: 95, normalRangeColor: '#4f4' });

    // Discrete charts
    $('.discrete1').sparkline('html',
        { type: 'discrete', lineColor: 'blue', xwidth: 18 });
    $('#discrete2').sparkline('html',
        { type: 'discrete', lineColor: 'blue', thresholdColor: 'red', thresholdValue: 4 });

    // Bullet charts
    $('.sparkbullet').sparkline('html', { type: 'bullet' });

    // Pie charts
    $('.sparkpie').sparkline('html', { type: 'pie', height: '1.0em' });

    // Box plots
    $('.sparkboxplot').sparkline('html', { type: 'box' });
    $('.sparkboxplotraw').sparkline([1, 3, 5, 8, 10, 15, 18],
        { type: 'box', raw: true, showOutliers: true, target: 6 });

    // Box plot with specific field order
    $('.boxfieldorder').sparkline('html', {
        type: 'box',
        tooltipFormatFieldlist: ['med', 'lq', 'uq'],
        tooltipFormatFieldlistKey: 'field'
    });

    // click event demo sparkline
    $('.clickdemo').sparkline();
    $('.clickdemo').bind('sparklineClick', function (ev) {
        var sparkline = ev.sparklines[0],
            region = sparkline.getCurrentRegionFields();
        value = region.y;
        alert("Clicked on x=" + region.x + " y=" + region.y);
    });

    // mouseover event demo sparkline
    $('.mouseoverdemo').sparkline();
    $('.mouseoverdemo').bind('sparklineRegionChange', function (ev) {
        var sparkline = ev.sparklines[0],
            region = sparkline.getCurrentRegionFields();
        value = region.y;
        $('.mouseoverregion').text("x=" + region.x + " y=" + region.y);
    }).bind('mouseleave', function () {
        $('.mouseoverregion').text('');
    });
}

/**
 ** Draw the little mouse speed animated graph
 ** This just attaches a handler to the mousemove event to see
 ** (roughly) how far the mouse has moved
 ** and then updates the display a couple of times a second via
 ** setTimeout()
 **/
function drawMouseSpeedDemo() {
    var mrefreshinterval = 500; // update display every 500ms
    var lastmousex = -1;
    var lastmousey = -1;
    var lastmousetime;
    var mousetravel = 0;
    var mpoints = [];
    var mpoints_max = 30;
    $('html').mousemove(function (e) {
        var mousex = e.pageX;
        var mousey = e.pageY;
        if (lastmousex > -1) {
            mousetravel += Math.max(Math.abs(mousex - lastmousex), Math.abs(mousey - lastmousey));
        }
        lastmousex = mousex;
        lastmousey = mousey;
    });
    var mdraw = function () {
        var md = new Date();
        var timenow = md.getTime();
        if (lastmousetime && lastmousetime != timenow) {
            var pps = Math.round(mousetravel / (timenow - lastmousetime) * 1000);
            mpoints.push(pps);
            if (mpoints.length > mpoints_max)
                mpoints.splice(0, 1);
            mousetravel = 0;
            $('#mousespeed').sparkline(mpoints, { width: mpoints.length * 2, tooltipSuffix: ' pixels per second' });
        }
        lastmousetime = timenow;
        setTimeout(mdraw, mrefreshinterval);
    };
    // We could use setInterval instead, but I prefer to do it this way
    setTimeout(mdraw, mrefreshinterval);
}



$(function () {

    "use strict";

    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"]').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue'
    });

    //When unchecking the checkbox
    $("#check-all").on('ifUnchecked', function (event) {
        //Uncheck all checkboxes
        $("input[type='checkbox']", ".table-mailbox").iCheck("uncheck");
    });
    //When checking the checkbox
    $("#check-all").on('ifChecked', function (event) {
        //Check all checkboxes
        $("input[type='checkbox']", ".table-mailbox").iCheck("check");
    });
    //Handle starring for glyphicon and font awesome
    $(".fa-star, .fa-star-o, .glyphicon-star, .glyphicon-star-empty").click(function (e) {
        e.preventDefault();
        //detect type
        var glyph = $(this).hasClass("glyphicon");
        var fa = $(this).hasClass("fa");

        //Switch states
        if (glyph) {
            $(this).toggleClass("glyphicon-star");
            $(this).toggleClass("glyphicon-star-empty");
        }

        if (fa) {
            $(this).toggleClass("fa-star");
            $(this).toggleClass("fa-star-o");
        }
    });

    //Initialize WYSIHTML5 - text editor
    $("#email_message").wysihtml5();
});

$(function () {
    //Add text editor
    $("#compose-textarea").wysihtml5();
});

$(function () {
    "use strict";

    // AREA CHART
    var area = new Morris.Area({
        element: 'revenue-chart',
        resize: true,
        data: [
          { y: '2011 Q1', item1: 2666, item2: 2666 },
          { y: '2011 Q2', item1: 2778, item2: 2294 },
          { y: '2011 Q3', item1: 4912, item2: 1969 },
          { y: '2011 Q4', item1: 3767, item2: 3597 },
          { y: '2012 Q1', item1: 6810, item2: 1914 },
          { y: '2012 Q2', item1: 5670, item2: 4293 },
          { y: '2012 Q3', item1: 4820, item2: 3795 },
          { y: '2012 Q4', item1: 15073, item2: 5967 },
          { y: '2013 Q1', item1: 10687, item2: 4460 },
          { y: '2013 Q2', item1: 8432, item2: 5713 }
        ],
        xkey: 'y',
        ykeys: ['item1', 'item2'],
        labels: ['Item 1', 'Item 2'],
        lineColors: ['#a0d0e0', '#3c8dbc'],
        hideHover: 'auto'
    });

    // LINE CHART
    var line = new Morris.Line({
        element: 'line-chart',
        resize: true,
        data: [
          { y: '2011 Q1', item1: 2666 },
          { y: '2011 Q2', item1: 2778 },
          { y: '2011 Q3', item1: 4912 },
          { y: '2011 Q4', item1: 3767 },
          { y: '2012 Q1', item1: 6810 },
          { y: '2012 Q2', item1: 5670 },
          { y: '2012 Q3', item1: 4820 },
          { y: '2012 Q4', item1: 15073 },
          { y: '2013 Q1', item1: 10687 },
          { y: '2013 Q2', item1: 8432 }
        ],
        xkey: 'y',
        ykeys: ['item1'],
        labels: ['Item 1'],
        lineColors: ['#3c8dbc'],
        hideHover: 'auto'
    });

    //DONUT CHART
    var donut = new Morris.Donut({
        element: 'sales-chart',
        resize: true,
        colors: ["#3c8dbc", "#f56954", "#00a65a"],
        data: [
          { label: "Download Sales", value: 12 },
          { label: "In-Store Sales", value: 30 },
          { label: "Mail-Order Sales", value: 20 }
        ],
        hideHover: 'auto'
    });
    //BAR CHART
    var bar = new Morris.Bar({
        element: 'bar-chart',
        resize: true,
        data: [
          { y: '2006', a: 100, b: 90 },
          { y: '2007', a: 75, b: 65 },
          { y: '2008', a: 50, b: 40 },
          { y: '2009', a: 75, b: 65 },
          { y: '2010', a: 50, b: 40 },
          { y: '2011', a: 75, b: 65 },
          { y: '2012', a: 100, b: 90 }
        ],
        barColors: ['#00a65a', '#f56954'],
        xkey: 'y',
        ykeys: ['a', 'b'],
        labels: ['CPU', 'DISK'],
        hideHover: 'auto'
    });
});

$(function () {
    //Datemask dd/mm/yyyy
    $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
    //Datemask2 mm/dd/yyyy
    $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
    //Money Euro
    $("[data-mask]").inputmask();

    //Date range picker
    $('#reservation').daterangepicker();
    //Date range picker with time picker
    $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });
    //Date range as a button
    $('#daterange-btn').daterangepicker(
        {
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
                'Last 7 Days': [moment().subtract('days', 6), moment()],
                'Last 30 Days': [moment().subtract('days', 29), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            },
            startDate: moment().subtract('days', 29),
            endDate: moment()
        },
        function (start, end) {
            $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
        }
    );

    //iCheck for checkbox and radio inputs
    $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
        checkboxClass: 'icheckbox_minimal-blue',
        radioClass: 'iradio_minimal-blue'
    });
    //Red color scheme for iCheck
    $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
        checkboxClass: 'icheckbox_minimal-red',
        radioClass: 'iradio_minimal-red'
    });
    //Flat red color scheme for iCheck
    $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
        checkboxClass: 'icheckbox_flat-green',
        radioClass: 'iradio_flat-green'
    });

    //Colorpicker
    $(".my-colorpicker1").colorpicker();
    //color picker with addon
    $(".my-colorpicker2").colorpicker();

    //Timepicker
    $(".timepicker").timepicker({
        showInputs: false
    });
});