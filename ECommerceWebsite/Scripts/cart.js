﻿var c = document.getElementById("cartProducts");
var discountValue = 0;

function calcQuantity() {
    var counter = 0;
    var el = document.getElementById("cartItemCountCart");
    var el2 = document.getElementById("cartItemCountSummary");
    for (let i = 0; i < c.children.length; i++) {
        if (c.children[i].classList.contains("deleted")) {
            continue
        }
        else {
            counter = counter + 1;
        }
    }
    if (counter == 0) {
        el.innerHTML = "YOUR CART IS EMPTY, SHOP NOW!";
        el2.parentElement.parentElement.remove();
    }
    else {
        el.innerHTML = "Items " + counter;
        el2.innerHTML = "ITEMS " + counter;
    }
}

function calcPriceFinal() {
    var p = 0;
    var total_counter = 0;
    for (let i = 0; i < c.children.length; i++) {
        if (c.children[i].classList.contains("deleted")) {
            continue;
        }
        else {
            var baseId = "basePriceProduct_" + (i + 1);
            var baseIDProdValue = document.getElementById(baseId).innerHTML;
            var pId = "productFinal_" + (i + 1);
            var qId = "cartQuantityProduct_" + (i + 1);
            var temp = parseInt(document.getElementById(qId).value);
            var temp1 = document.getElementById(pId);
            temp1.innerHTML = baseIDProdValue * temp;
            total_counter = parseInt(total_counter) + temp;
            p = p + parseInt(temp1.innerHTML);

        }
    }
    var el2 = document.getElementById("cartItemCountSummary");
    el2.innerHTML = " ITEMS " + total_counter.toString();
    var finalSumPrice = document.getElementById("finalSummaryPrice");
    finalSumPrice.innerHTML = p;

    var tenPercentDiscounts = ["discount10", "offer10", "solestore10"];
    var twentyPercentDiscounts = ["ams20", "AMS20", "solestore20"];
    var fiftyPercentDiscounts = ["ams50", "AMS50"];

    var checkcodeInput = document.getElementById("code").value;
    var outputCode = document.getElementById("applyCodeResult");
    var loopLength = Math.max(tenPercentDiscounts.length, twentyPercentDiscounts.length, fiftyPercentDiscounts.length);
    for (let i = 0; i < loopLength; i++) {
        if (checkcodeInput == tenPercentDiscounts[i]) {
            discountValue = (10 * p) / 100;
            outputCode.innerHTML = '10 % Discount Coupon Applied ( ' + tenPercentDiscounts[i] + ' )';
            setTimeout(function () { outputCode.style.display = "none"; }, 3000);
            break;
        }
        else if (checkcodeInput == twentyPercentDiscounts[i]) {
            discountValue = (20 * p) / 100;
            outputCode.innerHTML = '20 % Discount Coupon Applied ( ' + twentyPercentDiscounts[i] + ' )';
            setTimeout(function () { outputCode.style.display = "none"; }, 3000);
            break;
        }
        else if (checkcodeInput == fiftyPercentDiscounts[i]) {
            discountValue = (50 * p) / 100;
            outputCode.innerHTML = '50 % Discount Coupon Applied ( ' + fiftyPercentDiscounts[i] + ' )';
            setTimeout(function () { outputCode.style.display = ""; }, 3000);
            break;
        }
    }

    p = p - discountValue;
    var shipping = document.getElementById("shippingCharges").value;
    var checkoutP = document.getElementById("checkoutPrice");
    if (shipping == 0) {
        checkoutP.innerHTML = p + 200;

    }
    else if (shipping == 1) {
        checkoutP.innerHTML = p + 400;
    }

}

function deleteItemFromCart(element, productID) {
    $.ajax({
        type: "POST",
        url: "/Cart/RemoveFromCart",
        data: {
            productID: productID,
            isWished: 0,
        },
        success: function (objectResponse) {
            if (objectResponse.Title == "Success") {
                element.parentElement.classList.add("deleted");
                calcQuantity();
                calcPriceFinal();
            }
            else {
                alert(Object.Message)
            }
        },
        error: function (err) {
            console.log("Item was not removed from cart due to some error. Please try again later.");
        }
    });
}

function changeQuantity(inputElement, ID)
{
    $.ajax({
        type: "POST",
        url: "/Cart/UpdateQuantity",
        data: {
            productID: ID,
            quantity: inputElement.value,
        },
        success: function (objectResponse) {
            if (objectResponse.Title != "Success") {
                alert(Object.Message)
            }
        },
        error: function (err) {
            console.log("Product quantity was not updated from cart. Please try again later.");
        }
    });
}

calcQuantity();
calcPriceFinal();

function darkMode() {
    var mainCart = document.getElementById("mainCart");
    mainCart.classList.add("bg-dark");
}

function lightMode() {
    var mainCart = document.getElementById("mainCart");
    mainCart.classList.remove("bg-dark");
}

function submitOrder()
{
    $.ajax({
        type: "POST",
        url: "/Cart/SubmitOrder",
        data: {
            customerAddress: document.getElementById("addressField").value, 
            basePrice: parseInt(document.getElementById("finalSummaryPrice").innerHTML),
            shippingPrice: parseInt(document.getElementById("shippingCharges").value),
            discount: discountValue
        },
        success: function (objectResponse) {
            if (objectResponse.Title == "Success")
            {
                var searchQuery = `?orderNO=${objectResponse.Message}`;
                window.location.href = window.location.origin + '/Cart/Order' + searchQuery;
            }
        },
        error: function (err) {
            console.log("Your order was not registered due to some error. Please try again later.");
        }
    });

    return false;
}