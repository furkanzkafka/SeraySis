
// Dashboard-2.js
// ====================================================================
// This file should not be included in your project.
// This is just a sample how to initialize plugins or components.
//
// - ThemeOn.net -


$(window).on('load', function() {


    // FLOT CHART
    // =================================================================
    // Require Flot Charts
    // -----------------------------------------------------------------
    // http://www.flotcharts.org/
    // =================================================================

    var d1 = [[0, 85], [1, 45], [2, 58], [3, 35], [4, 95], [5, 25], [6, 65], [7, 12], [8, 52], [9, 25], [10, 98], [11, 85], [12, 96]],
        d2 = [[0, 520], [1, 370], [2, 820], [3, 209], [4, 495], [5, 170], [6, 185], [7, 273], [8, 304], [9, 877], [10, 489], [11, 420], [12, 710]],
        d3 = [[0, 50], [1, 30], [2, 80], [3, 29], [4, 95], [5, 70], [6, 15], [7, 73], [8, 34], [9, 87], [10, 49], [11, 20], [12, 70]];


    $.plot("#demo-flot-chart", [ d1, d2, d3 ], {
        series: {
            stack: 1,
            lines: {
                show: false,
                fill: true,
                steps: false
            },
            bars: {
                show: true,
                lineWidth: 0,
                barWidth: .7,
                fillColor: { colors: [ { opacity: .9 }, { opacity: .9 } ] }
            }
        },
        colors: ['#177bbb', '#03a9f4', '#e3e8ee'],
        grid: {
            borderWidth: 0,
            hoverable: true,
            clickable: true
        },
        yaxis: {
            ticks: 4, tickColor: '#f0f7fa'
        },
        xaxis: {
            ticks: 12,
            tickColor: '#ffffff'
        }
    });

});
