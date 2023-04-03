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

function deleteItemFromwishlist(id) {
    id.parentElement.classList.add("deleted");
    calcQuantity();
}

calcQuantity();
