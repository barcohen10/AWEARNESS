$(document).ready(function () {
    var $events = $('p.repeat');
    var $selection = $('div#select');
    var select_span = document.getElementById('select').childNodes[0];
    var $number = $('input#number');
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
        select_span.style.paddingLeft = (window_width - longest) / 4 + "px";
        $number.css('padding-left', (window_width - longest) / 4 + "px");

        for (var i = 0; i < $events.length; i++) {
            $events[i].style.paddingLeft = (window_width - longest) / 4 + "px";
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

    $("#medicalTab").click(function () {
        switchTabs("medicalTab", "medicalInfo");
    });
    $("#chatTab").click(function () {
        switchTabs("chatTab", "chat");
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

function setOtherDetails(generalInfo, allergies, diseases, medicines)
{
    $('#generalInfoText').text(generalInfo);
    allergiesArray = allergies.split("~!"); //backspace
    diseasesArray = diseases.split("~!"); //backspace
    medicinesArray = medicines.split("~!"); //backspace
    var allergiesHtml = '';
    var diseasesHtml = '';
    var medicinesHtml = '';
    $.each(allergiesArray, function (index, value) {
        allergiesHtml += value + "</br>";
    });
    $.each(diseasesArray, function (index, value) {
        diseasesHtml += value + "</br>";
    });
    $.each(medicinesArray, function (index, value) {
        medicinesHtml += value + "</br>";
    });
    $('#allergiesList').html(allergiesHtml);
    $('#diseasesList').html(diseasesHtml);
    $('#medicinesList').html(medicinesHtml);




}