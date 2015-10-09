﻿$(document).ready(function () {
    var $events = $('p.repeat');
    var $selection = $('div#select');
    var select_span = document.getElementById('select').childNodes[0];
    var $number = $('input#number');
    var name_area = document.getElementById("name");
    var age_area = document.getElementById("age");
    var $picture = $('img#picture');
    var window_width = $(window).width();
    var longest = 0;
    //hide event list
    $events.hide();

    function order_style() {
        //find longest element
        for (var i = 0; i < $events.length; i++) {
            var elem_width = $($events[i]).first().width();
            if (elem_width > longest) longest = elem_width;
        }
        //align by the longest element
        name_area.style.left = (window_width - $(name_area).width()) / 2 + "px";
        name_area.style.top = $('img#main').height() * 0.72 + 75 + "px";

        age_area.style.left = (window_width - $(age_area).width()) / 2 + "px";
        age_area.style.top = $('img#main').height() * 0.88 + 75 + "px";

        select_span.style.paddingLeft = (window_width - longest) / 2 + "px";
        $number.css('padding-left', (window_width - longest) / 2 + "px");

        $picture.height(0.7 * $('img#main').height());
        $picture.css('left', (window_width - $picture.width()) / 2 + "px");
        $picture.css('top', $picture.height() * 0.25 + 75 + "px");

        for (var i = 0; i < $events.length; i++) {
            $events[i].style.paddingLeft = (window_width - longest) / 2 + "px";
        }
    }
    //apply padding style
    order_style();

    //event listeners
    $selection.click(function () {
        $events.show();
    });

    $events.click(function () {
        $(select_span).text($(this).text());
        $events.hide();
    });

    $number.focus(function () {
        $(this).css('background-color', '#1D2026');
    });

    $number.blur(function () {
        $(this).css('background-color', '#252932');
    });

    //alert button click event
    $('img.alert_btn').click(function () {
        if ($(select_span).text().trim() == 'Choose Event') {
            return;
        } else {
            var alert = { number: $number.val(), category: $(select_span).text().trim() };
            console.log(alert);
        }
    });
});
function getAge(dateString) {
    var dateArr = dateString.split("/");
    var today = new Date();
    var birthDate = new Date(dateArr[2], dateArr[1] - 1, dateArr[0]);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}
