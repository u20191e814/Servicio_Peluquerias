using Servicio_Peluquerias.Entidades.mostrarEspecialistas;
using System.Data.SqlClient;
using Dapper;

namespace Servicio_Peluquerias.Data
{
    public class Db_mostrarEspecialistas
    {
        private string sqlconexion { get; set; }
        public Db_mostrarEspecialistas(string sqlconexion)
        {
            this.sqlconexion = sqlconexion;
        }

        internal structure_output_mostrarEspecialistas getRegion()
        {
            structure_output_mostrarEspecialistas estructura = new structure_output_mostrarEspecialistas();
            
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("  select Pk_region as id, Nombre as nombre from [Peluqueria].[dbo].[Region] ");

                    estructura.data = cn.Query<ubicacion>(squery, null, null, true, 0, System.Data.CommandType.Text).ToList();

                }

                estructura.status = "OK";
                estructura.statusMessage = "OK";
            }
            catch (Exception ex)
            {
                estructura.status = "400";
                estructura.statusMessage = ex.Message;
            }
            finally
            {
               
                if (estructura.data ==null )
                {
                    estructura.data = new List<ubicacion>();                    
                }
                
                if (cn != null)
                {
                    cn.Dispose();
                }
            }
            return estructura;
        }

        internal structure_output_especialistas getEspecialistas(int id_categoria, int id_provincia, int id_distrito)
        {
            structure_output_especialistas estructura = new structure_output_especialistas();

            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("      select *, e.Nombre as 'Nombre' from [Peluqueria].[dbo].[Especialistas] e  inner join [Peluqueria].[dbo].[Distrito] d on (e.Fk_distrito=Pk_Distrito)   where Fk_categoria ={0} ", id_categoria);
                    if (id_distrito == -1)
                    {
                        squery = squery + string.Format( "  and d.Fk_Provincia ={0}", id_provincia);
                    }
                    else
                    {
                        squery = squery + string.Format("  and d.Pk_Distrito  ={0}", id_distrito);
                    }
                   

                    estructura.data = cn.Query<Especialistas>(squery, null, null, true, 0, System.Data.CommandType.Text).ToList();

                }

                estructura.status = "OK";
                estructura.statusMessage = "OK";
            }
            catch (Exception ex)
            {
                estructura.status = "400";
                estructura.statusMessage = ex.Message;
            }
            finally
            {

                if (estructura.data == null)
                {
                    estructura.data = new List<Especialistas>();
                }
                 
                if (cn != null)
                {
                    cn.Dispose();
                }
            }
            return estructura;
        }

        internal structure_output_mostrarEspecialistas getDistrict(int id_province)
        {
            structure_output_mostrarEspecialistas estructura = new structure_output_mostrarEspecialistas();

            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("     select Pk_Distrito as id , Nombre as nombre from [Peluqueria].[dbo].[Distrito] where Fk_Provincia={0} ", id_province);

                    estructura.data = cn.Query<ubicacion>(squery, null, null, true, 0, System.Data.CommandType.Text).ToList();

                }

                estructura.status = "OK";
                estructura.statusMessage = "OK";
            }
            catch (Exception ex)
            {
                estructura.status = "400";
                estructura.statusMessage = ex.Message;
            }
            finally
            {

                if (estructura.data == null)
                {
                    estructura.data = new List<ubicacion>();
                }
                estructura.data.Insert(0, new ubicacion() { id = -1, nombre = "Todos" });
                if (cn != null)
                {
                    cn.Dispose();
                }
            }
            return estructura;
        }

        internal structure_output_mostrarEspecialistas getProvince(int id_region)
        {
            structure_output_mostrarEspecialistas estructura = new structure_output_mostrarEspecialistas();

            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("    select Pk_provincia as id, Nombre as nombre from [Peluqueria].[dbo].[Provincia] where Fk_region ={0} ", id_region);

                    estructura.data = cn.Query<ubicacion>(squery, null, null, true, 0, System.Data.CommandType.Text).ToList();

                }

                estructura.status = "OK";
                estructura.statusMessage = "OK";
            }
            catch (Exception ex)
            {
                estructura.status = "400";
                estructura.statusMessage = ex.Message;
            }
            finally
            {

                if (estructura.data == null)
                {
                    estructura.data = new List<ubicacion>();
                }
               
                if (cn != null)
                {
                    cn.Dispose();
                }
            }
            return estructura;
        }
    }
}
