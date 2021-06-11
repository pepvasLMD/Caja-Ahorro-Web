
function transacciones() {
    Post("Transacciones/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("Transacciones/Transacciones");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso a este módulo',
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
                title: 'No tiene acceso a este módulo',
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
                title: 'No tiene acceso a este módulo',
                text: 'Sólo para el administrador',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}





