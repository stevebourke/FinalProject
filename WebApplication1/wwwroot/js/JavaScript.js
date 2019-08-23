$("#selectProfile").on('change', function () {
    locationId = $(this).children('option:selected').val();
    $.ajax({
        url: 'https://jsonplaceholder.typicode.com/Posts/' + locationId,
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