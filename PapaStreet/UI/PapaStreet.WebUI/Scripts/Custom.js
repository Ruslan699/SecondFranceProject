//Filter

var _page = 1;
$(function () {
    $("#sorting .sorting").click(function () {
        var sorting = $(this).attr("id");
        $.ajax({
            type: 'POST',
            dataType: "html",
            url: '@Url.Action("Search", "Home")',
            data: { sortBy: sorting, page: _page },
            success: function (response) {
                $("#announcementsDiv").html(response)
            },
            error: function () {
                alert('Error!');
            }
        });
    });
});

$(function () {
    $("#pagination .pagination button").click(function () {
        var btn = $(this);
        var page = btn.attr("id");
        _page = page;
        if (!$(this).hasClass("active")) {
            $("#pagination .pagination li").removeClass("active");
            btn.parent().addClass("active");
        }
        $.ajax({
            type: 'POST',
            dataType: "html",
            url: '@Url.Action("Search", "Home")',
            data: { page: page },
            success: function (response) {
                $("#pageSearch").val(_page);
                $("#announcementsDiv").html(response)
            },
            error: function () {
                alert('Error!');
            }
        });
    });
});

$(document).ready(function () {
    $('input[type="checkbox"]').click(function () {
        if ($(this).is(":checked")) {
            var id = $(this).attr("id");
            $.ajax({
                type: 'POST',
                dataType: "html",
                url: '@Url.Action("Search", "Home")',
                data: { id: id, page: _page },
                success: function (response) {
                    $("#announcementsDiv").html(response)
                },
                error: function () {
                    alert('Error!');
                }
            });
        }
        else if ($(this).is(":not(:checked)")) {
            var id = null;
            $.ajax({
                type: 'POST',
                dataType: "html",
                url: '@Url.Action("Search", "Home")',
                data: { id: id, page: _page },
                success: function (response) {
                    $("#announcementsDiv").html(response)
                },
                error: function () {
                    alert('Error!');
                }
            });
        }
    });
});

//Slider
$('.owl-carousel').owlCarousel({
    loop: true,
    margin: 10,
    nav: true,
    autoplay: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 3
        },
        1000: {
            items: 4
        }
    }
});