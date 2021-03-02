using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CN_Business_Layer.Clases;

namespace CN_Business_Layer.Clases_D
{
    public class clsMatriculaPago
    {
        public clsMatricula Matricula_Estudiante_NumDocuemnto { get; set; }
        public clsMonto Monto_codigo { get; set; }
        public clsFechaPago Fechapago_Codigo { get; set; }
        public clsMatricula Matricula_PeriodoAcademico_year { get; set; }
        public DateTime FechaProrroga { get; set; }
        public DateTime FechaPago { get; set; }
        public float MontoPago { get; set; }
        public clsEstadoPago EstadoPago_Codigo { get; set; }

        public clsMatriculaPago(clsMatricula argM_E_Ndoc,
            clsMonto argMonto_Codigo,
            clsFechaPago argFP_Codigo,
            clsMatricula argM_PA_year,
            DateTime argFechaProrroga,
            DateTime argFechaPago,
            float argMontoPago,
            clsEstadoPago argEP_Codigo)
        {
            Matricula_Estudiante_NumDocuemnto = argM_E_Ndoc;
            Monto_codigo = argMonto_Codigo;
            Fechapago_Codigo = argFP_Codigo;
            Matricula_PeriodoAcademico_year = argM_PA_year;
            FechaProrroga = argFechaProrroga;
            FechaPago = argFechaPago;
            MontoPago = argMontoPago;
            EstadoPago_Codigo = argEP_Codigo;
        }
    }
}
