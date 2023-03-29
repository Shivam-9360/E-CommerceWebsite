$(document).ready(function () {
    $("#navBarLinksList li").each(function () {
        if ($(this).text().trim() == currentPage) {
            $(this).addClass("active");
        }
        else {
            $(this).removeClass("active");
        }
    })
});