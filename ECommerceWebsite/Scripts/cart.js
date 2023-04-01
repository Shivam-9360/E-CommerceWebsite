
var c = document.getElementById("cartProducts");

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
    var fiftyPercentDiscounts = ["ams50", "AMS50"]
    var checkcodeInput = document.getElementById("code").value;
    var outputCode = document.getElementById("applyCodeResult");
    var loopLength = Math.max(tenPercentDiscounts.length, twentyPercentDiscounts.length, fiftyPercentDiscounts.length);
    var discount = 0;
    for (let i = 0; i < loopLength; i++) {
        if (checkcodeInput == tenPercentDiscounts[i]) {
            discount = (10 * p) / 100;
            outputCode.innerHTML = '10 % Discount Coupon Applied ( ' + tenPercentDiscounts[i] + ' )';
            setTimeout(function () { outputCode.style.display = "none"; }, 3000);
            break;
        }
        else if (checkcodeInput == twentyPercentDiscounts[i]) {
            discount = (20 * p) / 100;
            outputCode.innerHTML = '20 % Discount Coupon Applied ( ' + twentyPercentDiscounts[i] + ' )';
            setTimeout(function () { outputCode.style.display = "none"; }, 3000);
            break;
        }
        else if (checkcodeInput == fiftyPercentDiscounts[i]) {
            discount = (50 * p) / 100;
            outputCode.innerHTML = '50 % Discount Coupon Applied ( ' + fiftyPercentDiscounts[i] + ' )';
            setTimeout(function () { outputCode.style.display = ""; }, 3000);
            break;
        }

    }


    p = p - discount;
    var shipping = document.getElementById("shippingCharges").value;
    var checkoutP = document.getElementById("checkoutPrice");
    if (shipping == 0) {
        checkoutP.innerHTML = p + 200;

    }
    else if (shipping == 1) {
        checkoutP.innerHTML = p + 400;
    }

}
function deleteItemFromCart(id) {
    id.parentElement.classList.add("deleted");
    calcQuantity();
    calcPriceFinal();
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
