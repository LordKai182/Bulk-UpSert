using SqlBulkMerge;
using System.Collections.Generic;

namespace System.Data.SqlClient
{
    public static class SqlConnectionExtension
    {
        public static MergeResults Merge<T>(this SqlConnection conn, string targetTable, T item, Action<T, DataRow> itemToRow, string[] keyColumns, IList<T> list, bool deleteData)
        {
            return conn.Merge(targetTable, new List<T> { item }, itemToRow, keyColumns, new string[0], list, deleteData);
        }

        public static MergeResults Merge<T>(this SqlConnection conn, string targetTable, T item, Action<T, DataRow> itemToRow, string[] keyColumns, string[] deleteKeyColumns, IList<T> list, bool deleteData)
        {
            return conn.Merge(targetTable, new List<T> { item }, itemToRow, keyColumns, deleteKeyColumns, list, deleteData);
        }

        public static MergeResults Merge<T>(this SqlConnection conn, string targetTable, IEnumerable<T> items, Action<T, DataRow> itemToRow, string[] keyColumns, IList<T> list,bool deleteData)
        {
            var bulker = new SqlServerBulkUpsert(conn, null, targetTable, keyColumns, new string[0]);
            return bulker.DoWith(items, itemToRow, list, deleteData);
        }

        public static MergeResults Merge<T>(this SqlConnection conn, string targetTable, IEnumerable<T> items, Action<T, DataRow> itemToRow, string[] keyColumns, string[] deleteKeyColumns, IList<T> list, bool deleteData)
        {
            var bulker = new SqlServerBulkUpsert(conn, null, targetTable, keyColumns, deleteKeyColumns);
            return bulker.DoWith(items, itemToRow, list, deleteData);
        }
    }
}
