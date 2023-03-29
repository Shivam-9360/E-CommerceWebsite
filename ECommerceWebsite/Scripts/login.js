var nameError = document.getElementById("nameError");
var numberError = document.getElementById("numberError");
var emailError = document.getElementById("emailError");
var submitError = document.getElementById("submitError");
var confirmPasswordError = document.getElementById("confirmPasswordError");
var nameBox = document.getElementById('fullName');
var numberBox = document.getElementById('phoneNumber');
var emailBox = document.getElementById('email');
var pass = document.getElementById("password");
var confirmPass = document.getElementById("confirmPassword");
var usernameBox = document.getElementById("username");
var loginPass = document.getElementById("logpassword");

$(document).ready(function () {
    $(".signup-link").click(function () {
        $(".login-frame").hide();
        $(".signup-frame").show();
    });

    $(".login-link").click(function () {
        $(".signup-frame").hide();
        $(".login-frame").show();
    });
});

function check_name() {
    if (nameBox.value.length == 0 || !nameBox.value.match(/^[A-Za-z]+ [A-Za-z]+$/)) {
        nameError.innerHTML = "<p>Enter Valid Name</p>";
        nameBox.style.borderColor = "red";
        return false;
    }
    nameError.style.display = "block";
    nameError.innerHTML = "<p>Valid</p>";
    nameBox.style.borderColor = "green";
    nameBox.style.transition = "0.5s";

    setTimeout(function () { nameError.style.display = "none"; }, 3000);
    return true;
}

function check_phone() {
    if (numberBox.value.length != 10 || !numberBox.value.match(/^[0-9]{10}$/)) {
        numberError.innerHTML = "<p>Enter Valid Phone Number</p>";
        numberBox.style.borderColor = "red";
        numberError.innerHTML = "<p>Enter Valid Number</p>";
        return false;
    }
    numberError.style.display = "block";
    numberError.innerHTML = "<p>Valid</p>";
    numberBox.style.borderColor = "green";
    numberBox.style.transition = "0.5s";
    setTimeout(function () { numberError.style.display = "none"; }, 3000);
    return true;
}

function check_mail() {
    if (emailBox.value.length == 0 || !emailBox.value.match(/^[A-Za-z0-9_.-]+@[A-Za-z0-9]+.[a-zA-Z]{2,6}$/)) {
        emailError.innerHTML = "<p>Enter Valid Email Id</p>";
        emailBox.style.borderColor = "red";
        return false;
    }
    emailError.style.display = "block";
    emailError.innerHTML = "<p>Valid</p>";
    emailBox.style.borderColor = "green";
    emailBox.style.transition = "0.5s";
    setTimeout(function () { emailError.style.display = "none"; }, 3000);
    return true;
}

function check_username() {
    if (usernameBox.value.length == 0 || !usernameBox.value.match(/^[A-Za-z0-9_.-]+@[A-Za-z0-9]+.[a-zA-Z]{2,6}$/)) {
        return false;
    }
    return true;
}

function pass_confirm() {
    if (pass.value != confirmPass.value) {
        confirmPasswordError.innerHTML = "<p>Password don't match</p>";
        confirmPass.style.borderColor = "red";
        return false;
    }

    confirmPasswordError.style.display = "block";
    confirmPasswordError.innerHTML = "<p>Valid</p>";
    confirmPassword.style.borderColor = "green";
    confirmPassword.style.transition = "0.5s";
    pass.style.borderColor = "green";
    pass.style.transition = "0.5s";
    setTimeout(function () { confirmPasswordError.style.display = "none"; }, 3000);
    return true;
}

function check_signup_form() {
    if (!check_name() || !check_mail() || !check_phone() || !pass_confirm()) {
        alert("Please fill all the details correctly!");
        return false;
    }
    else
        return true;

}

function check_login_form() {
    if (!check_username()) {
        alert("Please fill all the details correctly!");
        return false;
    }
    else
        return true;

}

function termsconditions() {
    toggleswitch = document.getElementById("submit-btn");
    if (document.getElementById("termsAndConditions").checked) {
        toggleswitch.disabled = false;
        toggleswitch.style.backgroundColor = "#899194";
    }
    else {
        toggleswitch.disabled = true;

    }
}

