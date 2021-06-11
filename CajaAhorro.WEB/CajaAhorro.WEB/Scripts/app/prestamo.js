

$("#btnprestamo").on("click", function () {
    let cantidad = $("#txtcantidad").val();
    let plazo = $("#slplazo").val();

    if (cantidad.trim() == "") {
        alertify.error("Ingrese la cantidad a solicitar");
        $("#txtcantidad").focus();
        $("#txtcantidad").css("border-color", "red");
    } else if (cantidad.trim() < 0) {
        alertify.error("La cantidad debe ser mayor a 0");
        $("#txtcantidad").focus();
        $("#txtcantidad").css("border-color", "red");
    }

})

$("#txtcantidad").keyup(function () {
    $("#txtcantidad").css("border-color", "blue");
})

$("#cerrarModulo").on("click", function () {
    window.location = fnBaseURLWeb("Panel/Panel");
})