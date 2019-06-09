//loai bo nhung the DOM khong can thiet
$(document).ready(function () {
    $("#dataTable_info").remove();
    $("li.active").not(".nav-item").remove();
    $("ul.pagination li a").addClass("page-link ");
    $("ul.pagination").addClass("justify-content-center");
    $("div#dataTable_length").remove();
});
//tim kiem 
$(document).ready(function () {
    $("input.form-control").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#dataTable").filter(function () {
            $(this).toggle($(this).text().toLowerCase().lastIndexOf(value)>-1);
        });
    });
});