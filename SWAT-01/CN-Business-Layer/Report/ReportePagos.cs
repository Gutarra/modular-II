using CAD_Access_to_Data.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CN_Business_Layer.Report
{
	public class ReportePagos
	{
		/** listas **/
		private List<EstudiantePagos> _estudiantePagos = new List<EstudiantePagos>();

		public List<EstudiantePagos> ListaEstudiantePagos
		{
			get { return _estudiantePagos; }
			private set { _estudiantePagos = value; }
		}
		private List<Monto> _listamontos = new List<Monto>();

		public List<Monto> ListaMontos
		{
			get { return _listamontos; }
			set { _listamontos = value; }
		}
		private List<Porcentaje> _listaporcentaje = new List<Porcentaje>();

		public List<Porcentaje> ListaPorcentaje
		{
			get { return _listaporcentaje; }
			set { _listaporcentaje = value; }
		}

		/** propiedades simples **/
		public Decimal TotalRestante { get; private set; }
		public Decimal TotalPagado { get; private set; }
		public float PagosParciales { get; private set; }
		public float PagosTotales { get; private set; }
		public float NoPagados { get; private set; }
		public string Grado { get; private set; }
		public string Seccion { get; private set; }
		public byte CodigoFechainicio { get; private set; }
		public byte CodigoFechafinal { get; private set; }
		public string Periodo { get; private set; }


		public void CrearReporteEspecifico(char grado, char seccion)
		{
			Grado = grado.ToString() + "°";
			Seccion = "'" + seccion.ToString() + "'";
			int contador = 1;
			List<clsFechaPago> listadefechas = clsFechaPago.ListarFechasActuales();
			/** identificar la fecha actual y determinar 
			 * fecha de inicio (un mes antes de la fecha actual) 
			 * y fecha de fin este mes **/
			if (DateTime.Now.Month <= 3)
			{
				CodigoFechainicio = listadefechas[0].Codigo;
				CodigoFechafinal = listadefechas[0].Codigo;
				DateTimeFormatInfo mes = CultureInfo.CurrentCulture.DateTimeFormat;
				Periodo = mes.GetMonthName(listadefechas[0].FechaVencimiento.Month);
			}
			else
			{
				CodigoFechainicio = listadefechas[DateTime.Now.Month - 4].Codigo;
				CodigoFechafinal = listadefechas[DateTime.Now.Month - 3].Codigo;
				DateTimeFormatInfo mes = CultureInfo.CurrentCulture.DateTimeFormat;
				Periodo = mes.GetMonthName(listadefechas[DateTime.Now.Month - 4].FechaVencimiento.Month);
				Periodo += " - ";
				Periodo += mes.GetMonthName(listadefechas[DateTime.Now.Month - 3].FechaVencimiento.Month);
			}

			/* FIN */

			ReporteDataAccess reporte = new ReporteDataAccess();
			DataTable resultado = reporte.GererarReporte_Especifico(grado, seccion);

			string estudiante = "";
			foreach (DataRow filas in resultado.Rows)
			{
				if (Convert.ToByte(filas["fecha_cod"]) == CodigoFechainicio || Convert.ToByte(filas["fecha_cod"]) == CodigoFechafinal)
				{
					if (estudiante == "")
					{
						estudiante = Convert.ToString(filas["NDocumeto"]);
					}
					if (estudiante != Convert.ToString(filas["NDocumeto"]))
					{
						estudiante = Convert.ToString(filas["NDocumeto"]);
						contador += 1;
					}
					float pagado = 0;
					if (filas["pagado"] != DBNull.Value)
						pagado = Convert.ToSingle(filas["pagado"]);
					EstudiantePagos estudiantepago = new EstudiantePagos(
						contador,
						Convert.ToString(filas["NDocumeto"]),
						Convert.ToString(filas["ApellidosNombres"]),
						Convert.ToDateTime(filas["FechaVenc"]).ToShortDateString(),
						Convert.ToSingle(filas["Monto"]) - pagado,
						Convert.ToString(filas["Descripcion"])
					);
					ListaEstudiantePagos.Add(estudiantepago);

					TotalPagado += Convert.ToDecimal(pagado);
					TotalRestante += Convert.ToDecimal(filas["Monto"]);

					/* agregar porcentajes de pagos cancelados, pagos parciales, y no pagados*/
					byte estado = Convert.ToByte(filas["estado_pago"]);
					if (estado == 1)
						NoPagados += 1;
					else if (estado == 2)
						PagosTotales += 1;
					else
						PagosParciales += 1;
				}
			}
			contador -= 1;
			TotalRestante -= TotalPagado;
			NoPagados /= contador;
			PagosTotales /= contador;
			PagosParciales /= contador;

			/** agregar a listas **/
			Monto _pagado = new Monto("Pagado", TotalPagado);
			Monto _restante = new Monto("Restante", TotalRestante);
			ListaMontos.Add(_pagado);
			ListaMontos.Add(_restante);

			Porcentaje _nopagados = new Porcentaje("No Pagados", NoPagados);
			Porcentaje _pagostotales = new Porcentaje("Pagado Total", PagosTotales);
			Porcentaje _parciales = new Porcentaje("Pagado Parcial", PagosParciales);
			ListaPorcentaje.Add(_pagostotales);
			ListaPorcentaje.Add(_parciales);
			ListaPorcentaje.Add(_nopagados);
		}
		public void CrearReporteporGrado(char grado)
		{
			Grado = grado.ToString() + "°";
			Seccion = "Todas las secciones";
			int contador = 1;
			List<clsFechaPago> listadefechas = clsFechaPago.ListarFechasActuales();
			/** identificar la fecha actual y determinar 
			 * fecha de inicio (un mes antes de la fecha actual) 
			 * y fecha de fin este mes **/
			if (DateTime.Now.Month <= 3)
			{
				CodigoFechainicio = listadefechas[0].Codigo;
				CodigoFechafinal = listadefechas[0].Codigo;
				DateTimeFormatInfo mes = CultureInfo.CurrentCulture.DateTimeFormat;
				Periodo = mes.GetMonthName(listadefechas[0].FechaVencimiento.Month);
			}
			else
			{
				CodigoFechainicio = listadefechas[DateTime.Now.Month - 4].Codigo;
				CodigoFechafinal = listadefechas[DateTime.Now.Month - 3].Codigo;
				DateTimeFormatInfo mes = CultureInfo.CurrentCulture.DateTimeFormat;
				Periodo = mes.GetMonthName(listadefechas[DateTime.Now.Month - 4].FechaVencimiento.Month);
				Periodo += " - ";
				Periodo += mes.GetMonthName(listadefechas[DateTime.Now.Month - 3].FechaVencimiento.Month);
			}

			/* FIN */

			ReporteDataAccess reporte = new ReporteDataAccess();
			DataTable resultado = reporte.GenerarReporte_porGrado(grado);
			string estudiante = "";

			foreach (DataRow filas in resultado.Rows)
			{
				if (Convert.ToByte(filas["fecha_cod"]) == CodigoFechainicio || Convert.ToByte(filas["fecha_cod"]) == CodigoFechafinal)
				{
					if (estudiante == "")
					{
						estudiante = Convert.ToString(filas["NDocumeto"]);
					}
					if (estudiante != Convert.ToString(filas["NDocumeto"]))
					{
						estudiante = Convert.ToString(filas["NDocumeto"]);
						contador += 1;
					}
					float pagado = 0;
					if (filas["pagado"] != DBNull.Value)
						pagado = Convert.ToSingle(filas["pagado"]);
					EstudiantePagos estudiantepago = new EstudiantePagos(
						contador,
						Convert.ToString(filas["NDocumeto"]),
						Convert.ToString(filas["ApellidosNombres"]),
						Convert.ToDateTime(filas["FechaVenc"]).ToShortDateString(),
						Convert.ToSingle(filas["Monto"]) - pagado,
						Convert.ToString(filas["Descripcion"]),
						Convert.ToString(filas["Grado"]),
						Convert.ToString(filas["Seccion"])
					);
					ListaEstudiantePagos.Add(estudiantepago);

					TotalPagado += Convert.ToDecimal(pagado);
					TotalRestante += Convert.ToDecimal(filas["Monto"]);

					/* agregar porcentajes de pagos cancelados, pagos parciales, y no pagados*/
					byte estado = Convert.ToByte(filas["estado_pago"]);
					if (estado == 1)
						NoPagados += 1;
					else if (estado == 2)
						PagosTotales += 1;
					else
						PagosParciales += 1;
				}
			}
			contador -= 1;
			TotalRestante -= TotalPagado;
			NoPagados /= contador;
			PagosTotales /= contador;
			PagosParciales /= contador;

			/** agregar a listas **/
			Monto _pagado = new Monto("Pagado", TotalPagado);
			Monto _restante = new Monto("Restante", TotalRestante);
			ListaMontos.Add(_pagado);
			ListaMontos.Add(_restante);

			Porcentaje _nopagados = new Porcentaje("No Pagados", NoPagados);
			Porcentaje _pagostotales = new Porcentaje("Pagado Total", PagosTotales);
			Porcentaje _parciales = new Porcentaje("Pagado Parcial", PagosParciales);
			ListaPorcentaje.Add(_pagostotales);
			ListaPorcentaje.Add(_parciales);
			ListaPorcentaje.Add(_nopagados);
		}

		public void CrearReporteGeneral()
		{
			Grado = "Todos los grados";
			Seccion = "Todas las secciones";
			int contador = 1;
			List<clsFechaPago> listadefechas = clsFechaPago.ListarFechasActuales();
			/** identificar la fecha actual y determinar 
			 * fecha de inicio (un mes antes de la fecha actual) 
			 * y fecha de fin este mes **/
			if (DateTime.Now.Month <= 3)
			{
				CodigoFechainicio = listadefechas[0].Codigo;
				CodigoFechafinal = listadefechas[0].Codigo;
				DateTimeFormatInfo mes = CultureInfo.CurrentCulture.DateTimeFormat;
				Periodo = mes.GetMonthName(listadefechas[0].FechaVencimiento.Month);
			}
			else
			{
				CodigoFechainicio = listadefechas[DateTime.Now.Month - 4].Codigo;
				CodigoFechafinal = listadefechas[DateTime.Now.Month - 3].Codigo;
				DateTimeFormatInfo mes = CultureInfo.CurrentCulture.DateTimeFormat;
				Periodo = mes.GetMonthName(listadefechas[DateTime.Now.Month - 4].FechaVencimiento.Month);
				Periodo += " - ";
				Periodo += mes.GetMonthName(listadefechas[DateTime.Now.Month - 3].FechaVencimiento.Month);
			}

			/* FIN */

			ReporteDataAccess reporte = new ReporteDataAccess();
			DataTable resultado = reporte.GenerarReporteGeneral();
			string estudiante = "";
			foreach (DataRow filas in resultado.Rows)
			{
				if (Convert.ToByte(filas["fecha_cod"]) == CodigoFechainicio || Convert.ToByte(filas["fecha_cod"]) == CodigoFechafinal)
				{
					
					if (estudiante == "")
					{
						estudiante = Convert.ToString(filas["NDocumeto"]);
					}
					if (estudiante != Convert.ToString(filas["NDocumeto"]))
					{
						estudiante = Convert.ToString(filas["NDocumeto"]);
						contador += 1;
					}
					float pagado = 0;
					if (filas["pagado"] != DBNull.Value)
						pagado = Convert.ToSingle(filas["pagado"]);
					EstudiantePagos estudiantepago = new EstudiantePagos(
						contador,
						Convert.ToString(filas["NDocumeto"]),
						Convert.ToString(filas["ApellidosNombres"]),
						Convert.ToDateTime(filas["FechaVenc"]).ToShortDateString(),
						Convert.ToSingle(filas["Monto"]) - pagado,
						Convert.ToString(filas["Descripcion"]),
						Convert.ToString(filas["Grado"]),
						Convert.ToString(filas["Seccion"])
					);
					ListaEstudiantePagos.Add(estudiantepago);

					TotalPagado += Convert.ToDecimal(pagado);
					TotalRestante += Convert.ToDecimal(filas["Monto"]);

					/* agregar porcentajes de pagos cancelados, pagos parciales, y no pagados*/
					byte estado = Convert.ToByte(filas["estado_pago"]);
					if (estado == 1)
						NoPagados += 1;
					else if (estado == 2)
						PagosTotales += 1;
					else
						PagosParciales += 1;
					
				}
			}
			contador -= 1;
			TotalRestante -= TotalPagado;
			NoPagados /= contador;
			PagosTotales /= contador;
			PagosParciales /= contador;

			/** agregar a listas **/
			Monto _pagado = new Monto("Pagado", TotalPagado);
			Monto _restante = new Monto("Restante", TotalRestante);
			ListaMontos.Add(_pagado);
			ListaMontos.Add(_restante);

			Porcentaje _nopagados = new Porcentaje("No Pagados", NoPagados);
			Porcentaje _pagostotales = new Porcentaje("Pagado Total", PagosTotales);
			Porcentaje _parciales = new Porcentaje("Pagado Parcial", PagosParciales);
			ListaPorcentaje.Add(_pagostotales);
			ListaPorcentaje.Add(_parciales);
			ListaPorcentaje.Add(_nopagados);
		}
	}
}
