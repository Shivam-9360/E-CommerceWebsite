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

    if (isAlreadyInCart) {
        decorateCartButton();
    }

    if (isAlreadyInWishList) {
        decorateWishListButton();
    }
});

function submitReview(ID)
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
            Product_ID: ID,
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

function decorateCartButton()
{
    var cartAddButton = document.getElementById("cartAddButton");
    cartAddButton.innerHTML = '<i class="fa fa-shopping-bag"></i> Added to cart'
    cartAddButton.disabled = true;
    cartAddButton.style.backgroundColor = "gray";
}

function decorateWishListButton() {
    var wishlistAddButton = document.getElementById("wishlistAddButton");
    wishlistAddButton.innerHTML = '<i class="fa fa-heart"></i> Wishlisted'
    wishlistAddButton.disabled = true;
    wishlistAddButton.style.backgroundColor = "gray"
}

function addToCartClicked(ID)
{
    $.ajax({
        type: "POST",
        url: "/Cart/AddToCart",
        data: {
            productID: ID,
            isWished: 0
        },
        success: function (objectResponse) {
            alert(objectResponse.Message);

            if (objectResponse.Title == "Success")
            {
                decorateCartButton()
            }
        },
        error: function (err) {
            console.log("Product was not added to cart due to some error. Please try again later.");
        }
    });
}

function addToWishlistClicked(ID) {
    $.ajax({
        type: "POST",
        url: "/Cart/AddToCart",
        data: {
            productID: ID,
            isWished: 1
        },
        success: function (objectResponse) {
            alert(objectResponse.Message);

            f(objectResponse.Title == "Success")
            {
                decorateWishListButton()
            }
        },
        error: function (err) {
            console.log("Product was not added to wishlist due to some error. Please try again later.");
        }
    });
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

/* Changing window url according to product-id */
function goToProduct(productID) {
    var searchQuery = `?productID=${productID}`;
    window.location.href = window.location.origin + '/Product/Index' + searchQuery;
}