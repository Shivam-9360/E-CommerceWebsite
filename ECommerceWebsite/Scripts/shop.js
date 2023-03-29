var categoryDropDown = document.getElementById("categoryDropDown");
var priceDropDown = document.getElementById("priceDropDown");


/* Changing window url according to search parameters */
function searchByFilters()
{
    var searchQuery = `?categorySort=${categoryDropDown.value}&priceSort=${priceDropDown.value}`;
    window.location.href = window.location.origin + window.location.pathname + searchQuery;
}

$(document).ready(function () {
    $("#filterClick").click(function () {
        $("#sortFilterDrops").slideToggle();
    });
    categoryDropDown.selectedIndex = selectedCategoryDropDown;
    priceDropDown.selectedIndex = selectedPriceDropDown;
});