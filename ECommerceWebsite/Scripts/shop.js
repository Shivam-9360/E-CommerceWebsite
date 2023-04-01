var categoryDropDown = document.getElementById("categoryDropDown");
var priceDropDown = document.getElementById("priceDropDown");

/* Changing window url according to search parameters */
function searchByFilters()
{
    window.location.search = `?categorySort=${categoryDropDown.value}&priceSort=${priceDropDown.value}`;
}

/* Changing window url according to product-id */
function goToProduct(productID) {
    var searchQuery = `?productID=${productID}`;
    window.location.href = window.location.origin + '/Product/Index' + searchQuery;
}

$(document).ready(function () {
    categoryDropDown.selectedIndex = selectedCategoryDropDown;
    priceDropDown.selectedIndex = selectedPriceDropDown;
});

function darkMode() {
    var shopMainBox = document.getElementById("shopMainBox");
    for (let i = 0; i < shopMainBox.children.length; i++) {
        shopMainBox.children[i].classList.remove("prod-box");
        shopMainBox.children[i].classList.add("prod-box-dark");
    }
}
function lightMode() {
    var shopMainBox = document.getElementById("shopMainBox");
    for (let i = 0; i < shopMainBox.children.length; i++) {
        shopMainBox.children[i].classList.add("prod-box");
        shopMainBox.children[i].classList.remove("prod-box-dark");
    }
}