using Servicio_Peluquerias.Entidades.subCategoria;
using System.Data.SqlClient;
using Dapper;

namespace Servicio_Peluquerias.Data
{
    public class Db_SubCategoria
    {
        private string sqlconexion;

        public Db_SubCategoria(string sqlconexion)
        {
            this.sqlconexion = sqlconexion;
        }

        internal structure_output_subcategorias getCategories(int fk_categoria)
        {
            structure_output_subcategorias estructura = new structure_output_subcategorias();
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("  select * from [Peluqueria].[dbo].[subCategorias] where Fk_categoria={0} ", fk_categoria);

                    estructura.data = cn.Query<SubCategoria>(squery, null, null, true, 0, System.Data.CommandType.Text).ToList();

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
