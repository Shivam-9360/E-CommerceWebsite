$('#lightSlider').lightSlider({
    gallery: true,
    item: 1,
    loop: true,
    slideMargin: 0,
    thumbItem: 4
});

$(document).ready(function () {
    $("#hiddenReviewLayoutClick").click(function () {
        $(".outer-div-review").toggle();
    });
});

function submitReview()
{
    var dropDownReview = document.getElementById("dropReview");
    var messageReview = document.getElementById("messageReview");
    var productName = document.getElementById("prodDetsHeader");

    if (messageReview.value.trim() == "")
    {
        alert("Please give us a review!");
        return;
    }

    $.ajax({
        type: "POST",
        url: "/Product/Reviews",
        data: {
            Product_Name: productName.value,
            Description: messageReview.value,
            Liking: dropDownReview.options[dropDownReview.selectedIndex].text
        },
        success: function (objectResponse) {
            dropDownReview.selectedIndex = 0;
            messageReview.value = "";
            alert(objectResponse.Message);
        },
        error: function (err) {
            console.log("Review was not submitted due to some error. Please try again later.");
        }
    });
}