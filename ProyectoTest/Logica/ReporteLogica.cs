using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoTest.Logica
{
    public class ReporteLogica
    {
        private static ReporteLogica _instancia = null;

        public ReporteLogica()
        {

        }

        public static ReporteLogica Instancia 
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ReporteLogica();
                }

                return _instancia;
            }
        }

        public List<ReporteVenta> GraficoVentas() 
        {
            List<ReporteVenta> listaVentas = new List<ReporteVenta>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.CN)) 
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oConexion)) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader()) 
                        {
                            while (sdr.Read()) 
                            {
                                listaVentas.Add(new ReporteVenta()
                                {
                                    Fecha = sdr["fecha"].ToString(),
                                    Monto = Convert.ToDecimal(sdr["monto"].ToString())
                                });
                            }
                        }
                    }
                }

                return listaVentas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ReporteProducto> GraficoProductos()
        {
            List<ReporteProducto> listaProductos = new List<ReporteProducto>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_MasVendido", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                listaProductos.Add(new ReporteProducto()
                                {
                                    Nombre = sdr["nombre"].ToString(),
                                    Cantidad = Convert.ToInt32(sdr["cantidad"].ToString())
                                });
                            }
                        }
                    }
                }

                return listaProductos;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ReporteCliente> GraficoClientes()
        {
            List<ReporteCliente> listaClientes = new List<ReporteCliente>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ClientesVentas", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        oConexion.Open();

                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                listaClientes.Add(new ReporteCliente()
                                {
                                    Nombre = sdr["Nombres"].ToString(),
                                    Monto = Convert.ToDecimal(sdr["Monto"].ToString())
                                });
                            }
                        }
                    }
                }

                return listaClientes;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}