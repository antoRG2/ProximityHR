$(document).ready(function () {
    // create DateTimePicker from input HTML element
    $(".datetimepicker").kendoDatePicker();
    $('#average').addClass('notShow');
    $('#demo').addClass('notShow');
    $('#features').addClass('notShow');
    $('#license').addClass('notShow');
    $('#age').addClass('notShow');
    $('#ms').addClass('notShow');
   
});

$('.js--toggle-left-panel').click(function () {
    $('.left-panel').toggleClass('open-left-panel');
    $(this).toggleClass('opened-link');
});


$('.left-link').on('click', function () {
    $('.left-link').parent().removeClass('left-item--active');
    $(this).parent().toggleClass('left-item--active');
    var theID = $(this).attr('href').replace('#', "");
    console.log(theID + " the id");

    $('#intro').removeClass('notShow');
    $('#average').addClass('notShow');
    $('#demo').addClass('notShow');
    $('#features').addClass('notShow');
    $('#license').addClass('notShow');
    $('#age').addClass('notShow');
    $('#ms').addClass('notShow');
    $('#' + theID).removeClass('notShow');

    if (theID === 'intro') { $('#intro').addClass('animated slideInLeft'); }
    if (theID === 'average') { $('#average').addClass('animated slideInDown'); }
    if (theID === 'demo') { $('#demo').addClass('animated slideInRight'); }
    if (theID === 'features') { $('#features').addClass('animated slideInDown');}
    if (theID === 'license') { $('#license').addClass('animated slideInRight');}
    if (theID === 'age') { $('#age').addClass('animated slideInDown'); }
    if (theID === 'ms') { $('#ms').addClass('animated slideInRight'); }

    if (theID == 'ms' || theID == 'average' || theID === 'demo' || theID === 'features' || theID === 'license' || theID === 'age') {
        $('#intro').addClass('notShow');
    } else {
        $('#intro').removeClass('notShow');
    }
    //$('#' + theID).addClass('animated slideInDown');
});


