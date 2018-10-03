$(document).ready(function () {

    $('a').click(function () {
        let self = $(this);
        let id = self.attr('id');
        alert(id);
        $.ajax({
            method: "POST",
            url: "/Home/Delete",
            data: {Id: id},
            success: function () {
                refreshGroceryList();
                //alert("hey");
            }
        })
    });

    var refreshGroceryList = function () {
        $.ajax({
            method: "GET",
            url: "/Home/LoadGroceryList",
            success: function () {
                alert("hey");
            }
            
        })
    }

});