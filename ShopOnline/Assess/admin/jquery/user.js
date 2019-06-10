//loai bo nhung the DOM khong can thiet
$(document).ready(function () {
    $("#dataTable_info").remove();
    $("li.active").not(".nav-item").remove();
    $("ul.pagination li a").addClass("page-link ");
    $("ul.pagination").addClass("justify-content-center");
    $("div#dataTable_length").remove();
    //position-fixed search textbox
    $("#dataTable_filter").addClass("position-fixed");
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
//datetime to date
$(document).ready(function () {
    var date = $("td#CreatedDate").text().substring(0, 10);
    $("td#CreatedDate").text(date);
    var date = $("td#UpdatedDate").text().substring(0, 10);
    $("td#UpdatedDate").text(date);
});
//
$(document).ready(function () {
    $("tr td span").each(function () {
        if ($(this).text() == "False") {
            $(this).addClass("badge badge-pill badge-danger");
        }
    });
});