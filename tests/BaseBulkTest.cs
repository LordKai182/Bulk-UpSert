using System;
using System.Configuration;
using System.Data.SqlClient;

namespace SqlBulkMerge.Test
{
    public abstract class BaseBulkTest : IDisposable
    {
        protected SqlConnection connection;
        public BaseBulkTest()
        {
            string connectionString = @"Server=.\SQLEXPRESS;initial catalog=db_loja;persist security info=True;user id=sa;password=VQXsSf7Z1NKV.qXGZsX7Z1Be.;";
            this.connection = new SqlConnection(connectionString);
            this.connection.Open();
        }

        public void Dispose()
        {
            this.connection.Dispose();
        }

        public int TableCount(string table)
        {
            using (SqlCommand cmd = new SqlCommand(string.Format("select count(*) from {0}", table), this.connection))
            {
                return (int)cmd.ExecuteScalar();
            }
        }

        public int QueryCount(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                return (int)cmd.ExecuteScalar();
            }
        }

        public object GetSingleValue(string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, this.connection))
            {
                return cmd.ExecuteScalar();
            }
        }
    }
}
