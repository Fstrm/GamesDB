$(document).ready(() => {
	$("#loginTrigger").click(() => {
		$("#loginForm").slideToggle();
	});

	$("#signUpTrigger").click(() => {
		$("#signUpModal").toggle();
	});

	$("#back").click(function () {
		$("#signUpModal").toggle();
	});

	$("#loginButton").click(function (e) {
		e.preventDefault();

		var data = {
			login: $("#loginUserName").val(),
			password: $("#loginPassword").val(),
		}

		$.ajax({
			url: 'api/Register?login=' + data.login + "&password=" + data.password,
			type: 'GET',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify(data),
			dataType: 'json',
			success: function (data) {
				alert(data);
				$("#loginForm").toggle();
				$("#loginTrigger").text($("#loginUserName").val());
			},
			error: function (x, y, z) {
				alert(x + '\n' + y + '\n' + z);
			}
		});
	});
});