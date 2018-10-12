$(document).ready(function () {
    $.ajax({
        url: "/Home/GetTotal",
        type: "GET",
        success: function (result) {
            $("#totalCount").html('<b>' + result + '</b>');
        }
    });
});