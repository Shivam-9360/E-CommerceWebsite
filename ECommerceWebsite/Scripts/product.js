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

function addToCartClicked() {

    var cartAddButton = document.getElementById("cartAddButton");
    cartAddButton.innerHTML = '<i class="fa fa-shopping-bag"></i> Added to cart'
    cartAddButton.disabled = true;
    cartAddButton.style.backgroundColor = "gray"
}

function addToWishlistClicked() {
    var wishlistAddButton = document.getElementById("wishlistAddButton");
    wishlistAddButton.innerHTML = '<i class="fa fa-heart"></i> Wishlisted'
    wishlistAddButton.disabled = true;
    wishlistAddButton.style.backgroundColor = "gray"
}

function darkMode() {
    var similarProductsMainBox = document.getElementById("similarProductsMainBox");
    for (let i = 0; i < similarProductsMainBox.children.length; i++) {
        similarProductsMainBox.children[i].classList.remove("prod-box");
        similarProductsMainBox.children[i].classList.add("prod-box-dark");
    }
    var otherReviews = document.getElementById("otherReviews");
    for (let i = 0; i < otherReviews.children.length; i++) {
        otherReviews.children[i].classList.add("review-card-dark");
    }
    var hiddenReviews = document.getElementById("hiddenReviews");
    for (let i = 0; i < hiddenReviews.children.length; i++) {
        hiddenReviews.children[i].classList.add("review-card-dark");
    }
}

function lightMode() {
    var similarProductsMainBox = document.getElementById("similarProductsMainBox");
    for (let i = 0; i < similarProductsMainBox.children.length; i++) {
        similarProductsMainBox.children[i].classList.add("prod-box");
        similarProductsMainBox.children[i].classList.remove("prod-box-dark");
    }
    var otherReviews = document.getElementById("otherReviews");
    for (let i = 0; i < otherReviews.children.length; i++) {
        otherReviews.children[i].classList.remove("review-card-dark");
    }
    var hiddenReviews = document.getElementById("hiddenReviews");
    for (let i = 0; i < hiddenReviews.children.length; i++) {
        hiddenReviews.children[i].classList.remove("review-card-dark");
    }
}

/* Changing window url according to product-id */
function goToShop() {
    window.location.href = window.location.origin + '/Home/Shop';
}