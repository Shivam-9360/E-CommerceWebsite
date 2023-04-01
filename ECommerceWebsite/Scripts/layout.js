$(document).ready(function () {
    $("#navBarLinksList li").each(function () {
        if ($(this).text().trim() == currentPage) {
            $(this).addClass("active");
        }
        else {
            $(this).removeClass("active");
        }
    })
});

//Layout Dark Mode Function
var darkTheme = false;
function layoutDark() {
    var footerLogo = document.getElementById("footerLogoImage");
    var footerBranding = document.getElementById("footerHeaderDarkMode");
    var footer = document.getElementById("footerClass");
    var contentHolder = document.getElementById("contentHolder");
    var navBar = document.getElementById("navBar");
    var navLinkItems = document.querySelectorAll(".nav-link");
    var navBrand = document.querySelectorAll(".brand");
    if (!darkTheme) {
        for (let i = 0; i < navLinkItems.length; i++) {
            navLinkItems[i].style.color = "white";
        }
        for (let i = 0; i < navBrand.length; i++) {
            navBrand[i].style.color = "white";
        }
        navBar.classList.add("navbar-dark");
        navBar.classList.add("bg-dark");
        navBar.classList.add("text-white");
        document.body.classList.add("bg-dark");
        footerBranding.classList.add("text-white");
        footerLogo.src = "../images/darkmode_logo.png";
        footerLogo.width = "100%";
        footer.classList.remove("bg-light");
        footer.classList.remove("text-muted");
        footer.classList.add("bg-dark");
        footer.classList.add("text-white");
        contentHolder.classList.add("bg-dark");
        contentHolder.classList.add("text-white");

        $(document).ready(function () {
            darkMode();
        });

        
        
        darkTheme = true;
    }
    else if (darkTheme) {
        for (let i = 0; i < navLinkItems.length; i++) {
            navLinkItems[i].style.color = "black";
        }
        for (let i = 0; i < navBrand.length; i++) {
            navBrand[i].style.color = "black";
        }
        navBar.classList.remove("navbar-dark");
        navBar.classList.remove("bg-dark");
        navBar.classList.remove("text-white");
        document.body.classList.remove("bg-dark");
        footerBranding.classList.remove("text-white");
        footerLogo.src = "../images/darkmode_logo.png";
        footerLogo.width = "100%";
        footer.classList.add("bg-light");
        footer.classList.add("text-muted");
        footer.classList.remove("bg-dark");
        footer.classList.remove("text-white");
        contentHolder.classList.remove("bg-dark");
        contentHolder.classList.remove("text-white");

        $(document).ready(function () {
            lightMode();
        });
        darkTheme = false;
    }
}