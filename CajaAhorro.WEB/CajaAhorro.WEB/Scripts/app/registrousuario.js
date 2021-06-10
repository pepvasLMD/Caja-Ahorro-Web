
$("#txtusername").keyup(function () {
    let username = $("#txtusername").val();
    if (username == "") {
        $("#msjusername").html("* El campo Nombre de usuario es obligatorio").css("color", "RED");
        $("#txtusername").css("border-color", "RED");
    } else {
        $("#msjusername").html("").css("color", "RED");
        $("#txtusername").css("border-color", "");
    }
})

$("#txtemail").keyup(function () {
    let email = $("#txtemail").val();
    if (email == "") {
        $("#msjemail").html("* El campo email es obligatorio").css("color", "RED");
        $("#txtemail").css("border-color", "RED");
    } else {
        if (!validaEmail(email)) {
            $("#msjemail").html("* La dirección de email no es válida").css("color", "RED");
            $("#txtemail").css("border-color", "RED");
        } else {
            $("#msjemail").html("").css("color", "RED");
            $("#txtemail").css("border-color", "");
        }
    }
})

$("#btnatras").on("click", function () {
    window.location = fnBaseURLWeb("Home/Index");
})