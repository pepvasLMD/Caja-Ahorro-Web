﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaAhorro.ENTITY.Response
{
    public class ResponseEstadoCuenta
    {
        public int idcuenta { get; set; }
        public int idusuario { get; set; }
        public double dinero { get; set; }
        public double disponible { get; set; }
        public double deudaTotal { get; set; }
        public string response { get; set; }
    }
}