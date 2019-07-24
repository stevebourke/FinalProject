// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.



//Check that at least one day has been picked

jQuery.validator.addMethod("DaysPicked",
    function (value, element, param) {
        return $(".daychecker:checked").length > 0

    });

jQuery.validator.unobtrusive.adapters.addBool("DaysPicked");
