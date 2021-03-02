using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer
{
    public class clsMatriculaPago
    {
        public clsMatricula Matricula_Estudiante_NumDocuemnto { get; set; }
        public clsMonto Monto_codigo { get; set; }
        public clsFechaPago Fechapago_Codigo { get; set; }
        public clsMatricula Matricula_PeriodoAcademico_year { get; set; }
        public DateTime FechaProrroga { get; set; }
        public clsEstadoPago EstadoPago_Codigo { get; set; }

        public clsMatriculaPago(clsMatricula matricula_Estudiante_NumDocuemnto, clsMonto monto_codigo, clsFechaPago fechapago_Codigo, clsMatricula matricula_PeriodoAcademico_year, DateTime fechaProrroga, clsEstadoPago estadoPago_Codigo)
        {
            Matricula_Estudiante_NumDocuemnto = matricula_Estudiante_NumDocuemnto;
            Monto_codigo = monto_codigo;
            Fechapago_Codigo = fechapago_Codigo;
            Matricula_PeriodoAcademico_year = matricula_PeriodoAcademico_year;
            FechaProrroga = fechaProrroga;
            EstadoPago_Codigo = estadoPago_Codigo;
        }
        public clsMatriculaPago(clsMatricula matricula_Estudiante_NumDocuemnto, clsMonto monto_codigo, clsFechaPago fechapago_Codigo, clsMatricula matricula_PeriodoAcademico_year, clsEstadoPago estadoPago_Codigo)
        {
            Matricula_Estudiante_NumDocuemnto = matricula_Estudiante_NumDocuemnto;
            Monto_codigo = monto_codigo;
            Fechapago_Codigo = fechapago_Codigo;
            Matricula_PeriodoAcademico_year = matricula_PeriodoAcademico_year;
            EstadoPago_Codigo = estadoPago_Codigo;
        }

    }
}
