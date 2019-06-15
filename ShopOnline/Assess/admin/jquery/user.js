
$(document).ready(function () {
    //loai bo nhung the DOM khong can thiet
    $("#dataTable_info").remove();
    $("li.active").not(".nav-item").remove();
    $("ul.pagination li a").addClass("page-link ");
    $("ul.pagination").addClass("justify-content-center");
    $("div#dataTable_length").remove();
    //position-fixed search textbox
    $("#dataTable_filter").addClass("position-fixed");
    //datepicker
    $("#CreatedDate").datetimepicker({
        pickTime: false
    });
    $("#UpdatedDate").datetimepicker({
        pickTime: false
    });
    $("i.gj-icon").remove();
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
    var date = $("td.CreatedDate").text().substring(0, 10);
    $("td.CreatedDate").text(date);
    var date = $("td.UpdatedDate").text().substring(0, 10);
    $("td.UpdatedDate").text(date);
});
//
$(document).ready(function () {
    $("tr td span").each(function () {
        if ($(this).text() == "False") {
            $(this).addClass("badge badge-pill badge-danger");
        }
    });
});
//active
$(document).ready(function () {
    $("ul.sidebar li a ").on("click", function () {
        var name = $(this).text();
        $(document).ready(function () {
            $("ul.sidebar li a ").each(function () {
                if ($(this).text() == name) {
                    console.log($(this).text() == name);
                    $(this).addClass("active");
                }
            });

        });
        
    });
});

$(document).ready(function () {
    $('#selectImage').on("click", function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $("#Image").val(url);
        };
        finder.popup();
    });
});
