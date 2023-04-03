function darkMode() {
    var userPageCard = document.getElementById("userProfileCard");
    var usernameHead = document.getElementById("UserNameExtract");
    usernameHead.style.color = "white"
    userPageCard.classList.add("bg-dark");
    var signOutButton = document.getElementById("signOutButton");
    signOutButton.classList.add("btn-dark");
    
}

function lightMode() {
    var userPageCard = document.getElementById("userProfileCard");
    var usernameHead = document.getElementById("UserNameExtract");
    usernameHead.style.color = "black";
    userPageCard.classList.remove("bg-dark");
    var signOutButton = document.getElementById("signOutButton");
    signOutButton.classList.remove("btn-dark");
}