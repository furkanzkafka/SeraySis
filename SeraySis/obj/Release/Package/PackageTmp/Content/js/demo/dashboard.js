
// Dashboard.js
// ====================================================================
// This file should not be included in your project.
// This is just a sample how to initialize plugins or components.
//
// - ThemeOn.net -


$(window).on('load', function() {


    // Network chart ( Morris Line Chart )
    // =================================================================
    // Require MorrisJS Chart
    // -----------------------------------------------------------------
    // http://morrisjs.github.io/morris.js/
    // =================================================================

    var day_data = [
        {"elapsed": "Oct-12", "value": 24, b:2},
        {"elapsed": "Oct-13", "value": 34, b:22},
        {"elapsed": "Oct-14", "value": 33, b:7},
        {"elapsed": "Oct-15", "value": 22, b:6},
        {"elapsed": "Oct-16", "value": 28, b:17},
        {"elapsed": "Oct-17", "value": 60, b:15},
        {"elapsed": "Oct-18", "value": 60, b:17},
        {"elapsed": "Oct-19", "value": 70, b:7},
        {"elapsed": "Oct-20", "value": 67, b:18},
        {"elapsed": "Oct-21", "value": 86, b: 18},
        {"elapsed": "Oct-22", "value": 86, b: 18},
        {"elapsed": "Oct-23", "value": 113, b: 29},
        {"elapsed": "Oct-24", "value": 130, b: 23},
        {"elapsed": "Oct-25", "value": 114, b:10},
        {"elapsed": "Oct-26", "value": 80, b:22},
        {"elapsed": "Oct-27", "value": 109, b:7},
        {"elapsed": "Oct-28", "value": 100, b:6},
        {"elapsed": "Oct-29", "value": 105, b:17},
        {"elapsed": "Oct-30", "value": 110, b:15},
        {"elapsed": "Oct-31", "value": 102, b:17},
        {"elapsed": "Nov-01", "value": 107, b:7},
        {"elapsed": "Nov-02", "value": 60, b:18},
        {"elapsed": "Nov-03", "value": 67, b: 18},
        {"elapsed": "Nov-04", "value": 76, b: 18},
        {"elapsed": "Nov-05", "value": 73, b: 29},
        {"elapsed": "Nov-06", "value": 94, b: 13},
        {"elapsed": "Nov-07", "value": 135, b:2},
        {"elapsed": "Nov-08", "value": 154, b:22},
        {"elapsed": "Nov-09", "value": 120, b:7},
        {"elapsed": "Nov-10", "value": 100, b:6},
        {"elapsed": "Nov-11", "value": 130, b:17},
        {"elapsed": "Nov-12", "value": 100, b:15},
        {"elapsed": "Nov-13", "value": 60, b:17},
        {"elapsed": "Nov-14", "value": 70, b:7},
        {"elapsed": "Nov-15", "value": 67, b:18},
        {"elapsed": "Nov-16", "value": 86, b: 18},
        {"elapsed": "Nov-17", "value": 86, b: 18},
        {"elapsed": "Nov-18", "value": 113, b: 29},
        {"elapsed": "Nov-19", "value": 130, b: 23},
        {"elapsed": "Nov-20", "value": 114, b:10},
        {"elapsed": "Nov-21", "value": 80, b:22},
        {"elapsed": "Nov-22", "value": 109, b:7},
        {"elapsed": "Nov-23", "value": 100, b:6},
        {"elapsed": "Nov-24", "value": 105, b:17},
        {"elapsed": "Nov-25", "value": 110, b:15},
        {"elapsed": "Nov-26", "value": 102, b:17},
        {"elapsed": "Nov-27", "value": 107, b:7},
        {"elapsed": "Nov-28", "value": 60, b:18},
        {"elapsed": "Nov-29", "value": 67, b: 18},
        {"elapsed": "Nov-30", "value": 76, b: 18},
        {"elapsed": "Des-01", "value": 73, b: 29},
        {"elapsed": "Des-02", "value": 94, b: 13},
        {"elapsed": "Des-03", "value": 79, b: 24}
    ];

    var chart = Morris.Area({
        element : 'morris-chart-network',
        data: day_data,
        axes: false,
        xkey: 'elapsed',
        ykeys: ['value', 'b'],
        labels: ['Download Speed', 'Upload Speed'],
        yLabelFormat :function (y) { return y.toString() + ' Mb/s'; },
        gridEnabled: false,
        gridLineColor: 'transparent',
        gridTextColor: '#8f9ea6',
        gridTextSize: '10px',
        lineColors: ['#a5cae2','#294d73'],
        lineWidth:[0,0],
        pointSize:[0,0],
        fillOpacity: 1,
        gridTextColor:'#999',
        parseTime: false,
        resize:true,
        behaveLikeLine : true,
        hideHover: 'auto'
    });




    // HDD USAGE - SPARKLINE LINE AREA CHART
    // =================================================================
    // Require sparkline
    // -----------------------------------------------------------------
    // http://omnipotent.net/jquery.sparkline/#s-about
    // =================================================================
    var hddSparkline = function() {
        $("#demo-sparkline-area").sparkline([57,69,70,62,73,79,76,77,73,52,57,50,60,55,70,68,57,62,53,69,59,67,69,58,50,47,65], {
            type: 'line',
            width: '100%',
            height: '60',
            spotRadius: 4,
            lineWidth: 2,
            lineColor:'rgba(255,255,255,.85)',
            fillColor: 'rgba(0,0,0,0.1)',
            spotColor: 'rgba(255,255,255,.5)',
            minSpotColor: 'rgba(255,255,255,.5)',
            maxSpotColor: 'rgba(255,255,255,.5)',
            highlightLineColor : '#ffffff',
            highlightSpotColor: '#ffffff',
            tooltipChartTitle: 'Usage',
            tooltipSuffix:' %'

        });
    }





    // SALES - SPARKLINE BAR CHART
    // =================================================================
    // Require sparkline
    // -----------------------------------------------------------------
    // http://omnipotent.net/jquery.sparkline/#s-about
    // =================================================================

    var barEl = $("#demo-sparkline-bar");
    var barValues = [40,32,65,53,62,55,24,67,45,70,45,56,34,67,76,32,65,53,62,55,24,67,45,70,45,56,70,45,56,34,67,76,32,65,53];
    var barValueCount = barValues.length;
    var barSpacing = 1;
    var salesSparkline = function(){
         barEl.sparkline(barValues, {
            type: 'bar',
            height: 75,
            barWidth: Math.round((barEl.parent().width() - ( barValueCount - 1 ) * barSpacing ) / barValueCount),
            barSpacing: barSpacing,
            zeroAxis: false,
            tooltipChartTitle: 'Daily Sales',
            tooltipSuffix: ' Sales',
            barColor: 'rgba(0,0,0,.15)'
        });
    }


    $(window).on('resizeEnd', function(){
        hddSparkline();
        salesSparkline();
    })
    hddSparkline();
    salesSparkline();





    // PANEL OVERLAY
    // =================================================================
    // Require Nifty js
    // -----------------------------------------------------------------
    // http://www.themeon.net
    // =================================================================
    $('#demo-panel-network-refresh').niftyOverlay({
        iconClass : 'demo-psi-repeat-2 spin-anim icon-2x'
    }).on('click', function(){
        var $el = $(this), relTime;

        $el.niftyOverlay('show');


        relTime = setInterval(function(){
            $el.niftyOverlay('hide');
            clearInterval(relTime);
        },2000);
    });








    // WELCOME NOTIFICATIONS
    // =================================================================
    // Require Admin Core Javascript
    // =================================================================
    $.niftyNoty({
        type: 'dark',
        title: 'Welcome Administrator.',
        message: 'You will notice that you now have an admin menu<br> that appears on the right hand side.',
        container: 'floating',
        timer: 3000
    });

});
