function darkMode() {
    var bestSeller = document.getElementById("bestSeller");
    for (let i = 0; i < bestSeller.children.length; i++) {
        bestSeller.children[i].classList.remove("prod-box");
        bestSeller.children[i].classList.add("prod-box-dark");
    }

    var categoryButton = document.querySelectorAll(".images");

    for (let i = 0; i < categoryButton.length; i++) {
        categoryButton[i].classList.remove("category-shop-button");
        categoryButton[i].classList.add("category-shop-button-dark");
    }
}

function lightMode() {
    var bestSeller = document.getElementById("bestSeller");
    for (let i = 0; i < bestSeller.children.length; i++) {
        bestSeller.children[i].classList.add("prod-box");
        bestSeller.children[i].classList.remove("prod-box-dark");
    }
    var categoryButton = document.querySelectorAll(".images");

    for (let i = 0; i < categoryButton.length; i++) {
        categoryButton[i].classList.add("category-shop-button");
        categoryButton[i].classList.remove("category-shop-button-dark");
    }
}