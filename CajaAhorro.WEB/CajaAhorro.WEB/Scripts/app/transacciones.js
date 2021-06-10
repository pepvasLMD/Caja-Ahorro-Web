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