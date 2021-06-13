
function transacciones() {
    Post("Transacciones/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("Transacciones/Transacciones");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso al módulo "Transacciones"',
                text: 'Sólo para clientes',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}

function prestamos() {
    Post("Prestamo/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("Prestamo/Prestamo");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso al módulo "Préstamos"',
                text: 'Sólo para clientes',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}

function procesos() {
    Post("Procesos/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("Procesos/Procesos");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso al módulo "Procesos"',
                text: 'Sólo para el administrador',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}

function estadocaja() {
    Post("EstadoCaja/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("EstadoCaja/EstadoCaja");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso al módulo "Estado de Caja"',
                text: 'Sólo para el administrador',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}

function historialu() {
    Post("HistorialU/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("HistorialU/HistorialU");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso al módulo "Historial"',
                text: 'Sólo para clientes',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}

function micuenta() {
    Post("MiCuenta/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("MiCuenta/MiCuenta");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso al módulo "Estado de Cuenta"',
                text: 'Sólo para clientes',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}





