using Dapper;
using Servicio_Peluquerias.Entidades.categoria;
using System.Data.SqlClient;

namespace Servicio_Peluquerias.Data
{
    public class Db_Categoria
    {
        private string sqlconexion { get; set; }
        public Db_Categoria(string sqlconexion)
        {
            this.sqlconexion = sqlconexion;
        }

        internal structure_output_categoria getCategories()
        {
            structure_output_categoria estructura = new structure_output_categoria();
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("   select * from [Peluqueria].[dbo].categorias");
                    
                    estructura.data = cn.Query<categoria>(squery, null, null,true, 0, System.Data.CommandType.Text).ToList();

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
                if (cn != null)
                {
                    cn.Dispose();
                }
            }
            return estructura;
        }
    }
}
