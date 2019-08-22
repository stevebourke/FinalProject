$("#selectProfile").on('change', function () {
    locationId = $(this).children('option:selected').val();
    $.ajax({
        url: 'https://magicseaweed.com/api/3520cfbae15bc809791873a0089e10bd/forecast/?spot_id=' + locationId,
            error: function (jqXHR, textStatus, errorThrown) {
                alert("Something went wrong!");
            },
        success: function (data) {

            $('#wind').html(data[0].Wind.Speed);
            $('#period').html(data.TimeStamp);
            $('#swell').html(data.FadedRating);
        }
    });
})