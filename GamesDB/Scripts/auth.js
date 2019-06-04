$(document).ready(() => {
	if (localStorage.getItem("user") != null && localStorage.getItem("token") != null) {
		SetName();
		$("#signupModal").remove();
	}
	else {
		if (localStorage.getItem("user") != null)
			localStorage.removeItem("user");
		if (localStorage.getItem("token") != null)
			localStorage.removeItem("token");
	}
});

$("#login-trigger").click(function () {
	$("#login-form").slideToggle();
});

$("#logout-trigger").click(function () {
	localStorage.removeItem("user");
	localStorage.removeItem("token");
	location.reload();
})

$("#signup-trigger").click(function () {
	$("#signup-modal").toggle();
});

$("#back").click(function () {
	$("#signup-modal").hide();
});

$("#signup-button").click(function () {
	var username = $("#signup-username").val();
	var password = $("#signup-password").val();

	if (username && password && password == $("#confirm-password").val()) {
		var user = {
			name: username,
			password: password
		};

		$.ajax({
			url: "api/Register?username=" + user.name + "&password=" + user.password,
			type: "GET",
			success: function (data) {
				localStorage.setItem("token", data);
				localStorage.setItem("user", username);
				console.log(localStorage["user"]);
				console.log(localStorage["token"]);
				$("#signup").hide();
				$("#signup-modal").remove();
				SetName();
			},
			error: function (data) {
				console.log(data);
			}
		})
	}
	else if (password && password != $("confirm-password").val()) {
		$("#error-block").text("passwords don't match");
	}
	else {
		$("#error-block").text("Some fields are empty");
	}
});

$("#login-button").click(function () {

	var user = {
		login: $("#login-username").val(),
		password: $("#login-password").val(),
	}

	$.ajax({
		url: "api/Login?login=" + user.login + "&password=" + user.password,
		type: "GET",
		success: function (data) {
			localStorage.setItem("token", data);
			localStorage.setItem("user", user.login);
			$("#login-form").toggle();
			$("#signup").hide();
			$("signup-modal").remove();
			SetName();
		},
		error: function (error) {
			console.log(error.responseJSON);
		}
	});
});

var SetName = function () {
	$("#login-trigger").text(localStorage.getItem("user"));
	$("#signup").hide();
	$("#login-inputs").hide();
	$("#logout-trigger").show();
}