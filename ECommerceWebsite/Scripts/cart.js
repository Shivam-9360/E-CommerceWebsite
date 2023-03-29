
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
    // el2.innerHTML = " ITEMS " + counter;
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


    var tenDollorDiscounts = ["discount10", "offer10", "solestore10"];
    var twentyDollorDiscounts = ["discount20", "offer20", "solestore20"];
    var checkcodeInput = document.getElementById("code").value;
    var outputCode = document.getElementById("applyCodeResult");

    var discount = 0;
    for (let i = 0; i < 3; i++) {
        if (checkcodeInput == tenDollorDiscounts[i]) {
            console.log("control here");
            discount = 10;
            outputCode.innerHTML = '10 $ Discount Coupon Applied';
            setTimeout(function () { outputCode.innerHTML = ""; }, 3000);
            break;
        }
        else if (checkcodeInput == twentyDollorDiscounts[i]) {
            discount = 20;
            outputCode.innerHTML = '20 $ Discount Coupon Applied';
            setTimeout(function () { outputCode.innerHTML = ""; }, 3000);
            break;
        }

    }


    p = p - discount;
    var shipping = document.getElementById("shippingCharges").value;
    var checkoutP = document.getElementById("checkoutPrice");
    if (shipping == 0) {
        checkoutP.innerHTML = p + 5;

    }
    else if (shipping == 1) {
        checkoutP.innerHTML = p + 10;
    }



}
function deleteItemFromCart(id) {
    id.parentElement.classList.add("deleted");
    calcQuantity();
    calcPriceFinal();
}

calcQuantity();
calcPriceFinal();
