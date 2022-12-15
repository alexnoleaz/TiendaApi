using System.Data.SqlClient;
using System.Data;
using TiendaApi.Connection;
using TiendaApi.Models;

namespace TiendaApi.Data
{
    public class DProducts
    {
        private ConnectionDB connection = new ConnectionDB();
        public async Task<List<MProducts>> ShowProducts()
        {
            var list = new List<MProducts>();
            using (var sql = new SqlConnection(connection.ConnectionString())) {
                using (var cmd = new SqlCommand("ReadProducts", sql)) {

                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = await cmd.ExecuteReaderAsync()) {

                        while (await reader.ReadAsync()) {
                            var Mproduct = new MProducts();
                            Mproduct.Id = (int)reader["id"];
                            Mproduct.Description = (string)reader["description"];
                            Mproduct.Price = (decimal)reader["price"];
                            list.Add(Mproduct);
                        }
                    }
                }
            }
            return list;
        }
        public async Task AddProducts(MProducts values)
        {
            using(var sql = new SqlConnection(connection.ConnectionString())){
                using(var cmd = new SqlCommand("CreateProducts",sql)){
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@description",values.Description);
                    cmd.Parameters.AddWithValue("@price",values.Price);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }    
        }
        public async Task UpdateProducts(MProducts values)
        {
            using(var sql = new SqlConnection(connection.ConnectionString())){
                using(var cmd = new SqlCommand("UpdateProducts",sql)){
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",values.Id);
                    cmd.Parameters.AddWithValue("@price",values.Price);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task DeleteProducts(MProducts values)
        {
            using(var sql = new SqlConnection(connection.ConnectionString())){
                using(var cmd = new SqlCommand("DeleteProducts", sql)){
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",values.Id);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}