var c = document.getElementById("wishlistProducts");

function calcQuantity() {
    var counter = 0;
    var el = document.getElementById("wishlistItemCount");
    for (let i = 0; i < c.children.length; i++) {
        if (c.children[i].classList.contains("deleted")) {
            continue
        }
        else {
            counter = counter + 1;
        }
    }
    if (counter == 0) {
        el.innerHTML = "YOUR WISHLIST IS EMPTY, SHOP NOW!";

    }
    else {
        if (counter > 1) {
            el.innerHTML = counter + " Items";
        }
        else {
            el.innerHTML = counter + " Item";
        }

    }
}

function deleteItemFromwishlist(cuurentElement, ID) {
    $.ajax({
        type: "POST",
        url: "/Cart/RemoveFromCart",
        data: {
            productID: ID,
            isWished: 1,
        },
        success: function (objectResponse) {
            if (objectResponse.Title == "Success") {
                cuurentElement.parentElement.classList.add("deleted");
                calcQuantity();
            }
            else {
                alert(Object.Message)
            }
        },
        error: function (err) {
            console.log("Item was not removed from wishlist due to some error. Please try again later.");
        }
    });

}

calcQuantity();

function addToCart(buttonElement, ID) {
    $.ajax({
        type: "POST",
        url: "/Cart/AddToCart",
        data: {
            productID: ID,
            isWished: 0
        },
        success: function (objectResponse) {
            alert(objectResponse.Message);

            if (objectResponse.Title == "Success") {
                buttonElement.disabled = true;
                buttonElement.classList.add("add-to-cart-clicked");
                buttonElement.innerHTML = "Added to Cart";
            }
        },
        error: function (err) {
            console.log("Product was not added to wishlist due to some error. Please try again later.");
        }
    });
}
