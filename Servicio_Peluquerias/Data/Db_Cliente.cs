using Dapper;
using Servicio_Peluquerias.Entidades;
using Servicio_Peluquerias.Entidades.cliente;
using System.Data.SqlClient;

namespace Servicio_Peluquerias.Data
{
    public class Db_Cliente
    {
        private string sqlconexion { get; set; }    
        public Db_Cliente(string sqlconexion)
        {
            this.sqlconexion = sqlconexion;
        }

        internal structure_post_int RegistrarCliente(Entidades.Cliente cliente)
        {
            structure_post_int estructura = new structure_post_int();
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("   insert into [Peluqueria].[dbo].[Cliente] (Nombre,Apellido,Correo,telefono,Clave) output inserted.Pk_client values (@Nombre,@Apellido,@Correo,@telefono,@Clave)");
                    var param = new DynamicParameters();
                    param.Add("@Nombre", cliente.Nombre);
                    param.Add("@Apellido", cliente.Apellido);
                    param.Add("@Correo", cliente.Correo);
                    param.Add("@telefono", cliente.telefono);
                    param.Add("@Clave", cliente.Clave);

                   estructura.data= cn.QueryFirstOrDefault<int> (squery, param, null, 0, System.Data.CommandType.Text);

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

        internal structure_post_bool removeClient(int id_cliente)
        {
            structure_post_bool estructura = new structure_post_bool();
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("  delete from[Peluqueria].[dbo].[Cliente] where Pk_client ={0}  ", id_cliente);
                    
                    cn.Execute(squery, null, null, 0, System.Data.CommandType.Text);

                }
                estructura.data = true;
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

        internal int ValidarCorreo(string correo)
        {
            SqlConnection cn = null;
            int contador = 0;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("  select count(*) from [Peluqueria].[dbo].[Cliente] where Correo like @correo");
                    var param = new DynamicParameters();
                    param.Add("@correo", correo);
                    contador = cn.QueryFirstOrDefault<int>(squery, param, null, 0, System.Data.CommandType.Text );
                }
                return contador;
            }
            catch (Exception ex)
            {

                return -1;
            }
            finally
            {
                if (cn!=null)
                {
                    cn.Dispose();
                }
            }
        }

        internal structure_post_bool updateClient(Cliente_output cliente)
        {
            structure_post_bool estructura = new structure_post_bool();
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("    update [Peluqueria].[dbo].[Cliente] set Nombre=@Nombre,Apellido=@Apellido, Correo =@Correo, telefono =@telefono, Clave=@Clave where Pk_client={0}", cliente.id_cliente);
                    var param = new DynamicParameters();
                    param.Add("@Nombre", cliente.Nombre);
                    param.Add("@Apellido", cliente.Apellido);
                    param.Add("@Correo", cliente.Correo);
                    param.Add("@telefono", cliente.telefono);
                    param.Add("@Clave", cliente.Clave);
                    cn.Execute(squery, param, null,0, System.Data.CommandType.Text);

                }
                estructura.data = true;
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

        public  structure_output_client login(User user)
        {
            structure_output_client estructura = new structure_output_client();
            SqlConnection cn = null;
            try
            {
                using (cn = new SqlConnection(sqlconexion))
                {
                    string squery = string.Format("   select top 1 Pk_client as id_cliente,   * from [Peluqueria].[dbo].[Cliente] where Correo like @correo and Clave like @clave");
                    var param = new DynamicParameters();
                    param.Add("@correo", user.correo);
                    param.Add("@clave", user.clave); 
                    estructura.data = cn.QueryFirstOrDefault<Cliente_output>(squery, param, null, 0, System.Data.CommandType.Text);

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
