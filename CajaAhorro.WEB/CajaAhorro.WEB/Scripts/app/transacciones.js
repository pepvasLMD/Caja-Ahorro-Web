$(document).ready(function () {
    $("#lblprin").html("DEPÓSITO A CUENTA");
    document.getElementById("btnsecciondeposito").disabled = true;

    //$(".ocultar").hide();
})

$("#cerrarModulo").on("click", function () {
    window.location = fnBaseURLWeb("Panel/Panel");
})

$("#btnsecciondeposito").on("click", function () {
    $("#lblprin").html("DEPÓSITO A CUENTA");
    document.getElementById("btnsecciondeposito").disabled = true;
    document.getElementById("btnseccionretiro").disabled = false;
    document.getElementById("btnsecciondepositodeuda").disabled = false;
    document.getElementById("btnseccionaporte").disabled = false;

    document.getElementById("divdeposito").style.display = "block";
    document.getElementById("divretiro").style.display = "none";
    document.getElementById("divdepositodeuda").style.display = "none";  
    document.getElementById("divaporte").style.display = "none";
})

$("#btnseccionretiro").on("click", function () {
    $("#lblprin").html("RETIRO A CUENTA");
    document.getElementById("btnseccionretiro").disabled = true;
    document.getElementById("btnsecciondeposito").disabled = false;
    document.getElementById("btnsecciondepositodeuda").disabled = false;
    document.getElementById("btnseccionaporte").disabled = false;

    document.getElementById("divretiro").style.display = "block";
    document.getElementById("divdeposito").style.display = "none";    
    document.getElementById("divdepositodeuda").style.display = "none";
    document.getElementById("divaporte").style.display = "none";
})

$("#btnsecciondepositodeuda").on("click", function () {
    $("#lblprin").html("DEPÓSITO A DEUDA");
    document.getElementById("btnsecciondepositodeuda").disabled = true;
    document.getElementById("btnseccionretiro").disabled = false;
    document.getElementById("btnsecciondeposito").disabled = false;
    document.getElementById("btnseccionaporte").disabled = false;

    document.getElementById("divdepositodeuda").style.display = "block";
    document.getElementById("divretiro").style.display = "none";
    document.getElementById("divdeposito").style.display = "none";
    document.getElementById("divaporte").style.display = "none";
})

$("#btnseccionaporte").on("click", function () {
    $("#lblprin").html("APORTACIÓN");
    document.getElementById("btnseccionaporte").disabled = true;
    document.getElementById("btnseccionretiro").disabled = false;
    document.getElementById("btnsecciondeposito").disabled = false;
    document.getElementById("btnsecciondepositodeuda").disabled = false;

    document.getElementById("divaporte").style.display = "block";
    document.getElementById("divretiro").style.display = "none";
    document.getElementById("divdeposito").style.display = "none";
    document.getElementById("divdepositodeuda").style.display = "none";
})

/***
 * VALIDACIONES DEPOSITO
 ***/

$("#btndeposito").on("click", function () {

    let cantidaddeposito = $("#txtdeposito").val();

    if (cantidaddeposito == "") {
        $("#msjdeposito").html("Este campo no debe estar vacío").css("color", "RED");
        $("#txtdeposito").css("border-color", "red");
        $("#txtdeposito").focus();
    } else if (parseFloat(cantidaddeposito) <= 0) {
        $("#msjdeposito").html("La cantidad debe ser mayor a $0").css("color", "RED");
        $("#txtdeposito").css("border-color", "red");
        $("#txtdeposito").focus();
    } else {

        let params = new Object();
        params.dinero = cantidaddeposito;

        Post("Transacciones/deposito", params).done(function (datos) {

            if (datos.dt.response == "ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: "Depósito realizado correctamente",
                    text: 'Se añadió la cantidad a su cuenta',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }, function () {
                    window.location = fnBaseURLWeb("Transacciones/Transacciones");
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: datos.dt.response,
                    text: 'por favor valide lo solicitado',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }

        })


    }
})

$("#txtdeposito").keyup(function () {
    $("#msjdeposito").html("").css("color", "");
    $("#txtdeposito").css("border-color", "");
    $("#txtdeposito").focus();
})

/***
 * VALIDACIONES RETIRO
 ***/

$("#btnretiro").on("click", function () {
    let cantidaddeposito = $("#txtretiro").val();

    if (cantidaddeposito == "") {
        $("#msjretiro").html("Este campo no debe estar vacío").css("color", "RED");
        $("#txtretiro").css("border-color", "red");
        $("#txtretiro").focus();
    } else if (parseFloat(cantidaddeposito) <= 0) {
        $("#msjretiro").html("La cantidad debe ser mayor a $0").css("color", "RED");
        $("#txtretiro").css("border-color", "red");
        $("#txtretiro").focus();
    } else {



    }
})

$("#txtretiro").keyup(function () {
    $("#msjretiro").html("").css("color", "");
    $("#txtretiro").css("border-color", "");
    $("#txtretiro").focus();
})

/***
 * VALIDACIONES APORTE
 ***/

$("#btnaporte").on("click", function () {
    let cantidaddeposito = $("#txtaporte").val();

    if (cantidaddeposito == "") {
        $("#msjaporte").html("Este campo no debe estar vacío").css("color", "RED");
        $("#txtaporte").css("border-color", "red");
        $("#txtaporte").focus();
    } else if (parseFloat(cantidaddeposito) <= 0) {
        $("#msjaporte").html("La cantidad debe ser mayor a $0").css("color", "RED");
        $("#txtaporte").css("border-color", "red");
        $("#txtaporte").focus();
    } else {



    }
})

$("#txtaporte").keyup(function () {
    $("#msjaporte").html("").css("color", "");
    $("#txtaporte").css("border-color", "");
    $("#txtaporte").focus();
})