$(document).ready(function () {
    $("input").keyup(function (event) {
        var ucase = new RegExp("[A-Z]+");
        var lcase = new RegExp("[a-z]+");
        var num = new RegExp("[0-9]+");

        if ($("#password3").val().length >= 8) {
            $("#p1").addClass("has-success");
            $("#p1").addClass("has-feedback");
        } else {
            $("#p1").removeClass("has-success");
            $("#p1").removeClass("has-feedback");
        }

        if (ucase.test($("#password3").val())) {
            $("#p1").addClass("has-success");
            $("#p1").addClass("has-feedback");
        } else {
            $("#p1").removeClass("has-success");
            $("#p1").removeClass("has-feedback");
        }

        if (lcase.test($("#password3").val())) {
            $("#p1").addClass("has-success");
            $("#p1").addClass("has-feedback");
        } else {
            $("#p1").removeClass("has-success");
            $("#p1").removeClass("has-feedback");
        }

        if (num.test($("#password3").val())) {
            $("#p1").addClass("has-success");
            $("#p1").addClass("has-feedback");
        } else {
            $("#p1").removeClass("has-success");
            $("#p1").removeClass("has-feedback");
        }

        if (($("#password3").val() == $("#password4").val()) && $("#password3").val() != "") {
            $("#p2").addClass("has-success");
            $("#p2").addClass("has-feedback");
            $("#Button1").removeAttr("disabled")
        } else {
            $("#p2").removeClass("has-success");
            $("#p2").removeClass("has-feedback");
            $("#Button1").attr("disabled", true)
        }
        

    });
});


