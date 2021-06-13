
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

$("#btnregistrar").on("click", function () {

    let email = $("#txtemail").val();
    let username = $("#txtusername").val();
    let contraseña = $("#txtcontraseña").val();
    let contraseña2 = $("#txtconfirmarcontraseña").val();

    if (username == "") {
        $("#msjusername").html("El campo nombre no debe estar vacío").css("color", "RED");
        $("#txtusername").css("border-color", "red");
        $("#txtusername").focus();
    } else if (email == "") {
        $("#msjemail").html("* El campo email es obligatorio").css("color", "RED");
        $("#txtemail").css("border-color", "RED");
        $("#txtemail").focus();
    } else if (!validaEmail(email)) {
        $("#msjemail").html("* La dirección de email no es válida").css("color", "RED");
        $("#txtemail").css("border-color", "RED");
        $("#txtemail").focus();
    } else if (contraseña == "") {
        $("#msjpassword").html("La contraseña no debe estar vacía").css("color", "RED");
        $("#txtcontraseña").css("border-color", "red");
        $("#txtcontraseña").focus();
    } else if (contraseña2 == "") {
        $("#msjpassword2").html("No se ha confirmado la contraseña").css("color", "RED");
        $("#txtconfirmarcontraseña").css("border-color", "red");
        $("#txtconfirmarcontraseña").focus();
    } else {

        /***********
         * INICIA ENVÍO DE DATOS
         ***********/

        let params = new Object();
        params.nombre = username;
        params.email = email;
        params.password = contraseña;

        Post("RegistroUsuario/registrarUsuario", params).done(function (datos) {

            if (datos.dt.response == "ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: 'Usuario registrado correctamente',
                    text: 'Se guardó correctamente en la base de datos',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }).then((result) => {
                    if (result.value) {
                        window.location = fnBaseURLWeb("Home/Index");
                    } else {
                        window.location = fnBaseURLWeb("Home/Index");
                    }
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: 'No se pudo registrar',
                    text: 'Contacte con el administrador del sistema',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }
        })

    }
})

$("#btnatras").on("click", function () {
    window.location = fnBaseURLWeb("Home/Index");
})