$(document).ready(() => {
	if (localStorage.getItem("user") != null)
		$("#loginTrigger").text(localStorage["user"]);

	$("#loginTrigger").click(() => {
		$("#loginForm").slideToggle();
	});

	$("#signupTrigger").click(() => {
		$("#signupModal").toggle();
	});

	$("#back").click(function () {
		$("#signupModal").toggle();
	});

	$("#signupButton").click(function () {
		var username = $("#signupUserName").val();
		var password = $("#signupPassword").val();
		var confirmPassword = $("#confirmPasswrod").val();

		if (username && password && password == $("#confirmPassword").val()) {
			var user = {
				name: username,
				password: password
			};
				
			$.ajax({
				url: 'api/Register?username=' + user.name + "&password=" + user.password,
				type: 'GET',
				success: function (data) {
					localStorage.setItem("token", data);
					localStorage.setItem("user", username);
					alert(localStorage.get("token"));
					$("#signup").toggle();
				},
				error: function (data) {
					console.log(data);
				}

			})
		}
		else if (password && password != $("confirmPassword").val()) {
			$("#errorBlock").text("passwords don't match");
		}
		else {
			$("#errorBlock").text('Some fields are empty');
		}
	});

	$("#loginButton").click(function () {
		
		var user = {
			login: $("#loginUserName").val(),
			password: $("#loginPassword").val(),
		}

		$.ajax({
			url: 'api/Login?login=' + user.login + "&password=" + user.password,
			type: 'GET',
			success: function (data) {
				localStorage.setItem("token", data);
				localStorage.setItem("user", user.login);
				alert("received token: " + localStorage["token"]);
				$("#loginForm").toggle();
				$("#loginTrigger").text($("#loginUserName").val());
				$("#signup").toggle();
			},
			error: function (error) {
				console.log(error.responseJSON);
			}
		});
	});
});