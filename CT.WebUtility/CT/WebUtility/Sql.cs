namespace CT.WebUtility
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public static class Sql
    {
        public static readonly string ConnStr = DecryptConnStr();

        private static string DecryptConnStr()
        {
            return ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public static DataSet ExecuteDataSet(string StoredProcedure, SqlParameter[] Para)
        {
            return ExecuteDataSet(StoredProcedure, Para, "DefaultTable");
        }

        public static DataSet ExecuteDataSet(string StoredProcedure, SqlParameter[] Para, string TableName)
        {
            SqlConnection connection = new SqlConnection(ConnStr);
            SqlCommand selectCommand = connection.CreateCommand();
            selectCommand.CommandType = CommandType.StoredProcedure;
            selectCommand.CommandText = StoredProcedure;
            foreach (SqlParameter parameter in Para)
            {
                selectCommand.Parameters.Add(parameter);
            }
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataSet dataSet = new DataSet();
            connection.Open();
            adapter.Fill(dataSet, TableName);
            adapter.Dispose();
            selectCommand.Dispose();
            connection.Close();
            if (selectCommand.Parameters.Contains("@Result") && (Convert.ToInt32(selectCommand.Parameters["@Result"].Value.ToString()) == 0))
            {
                return null;
            }
            return dataSet;
        }

        public static DateTime ExecuteDateTime(string StoredProcedure, SqlParameter[] Para)
        {
            return Convert.ToDateTime(ExecuteString(StoredProcedure, Para));
        }

        public static int ExecuteInt(string StoredProcedure, SqlParameter[] Para)
        {
            return Convert.ToInt32(ExecuteString(StoredProcedure, Para));
        }

        public static long ExecuteInt64(string StoredProcedure, SqlParameter[] Para)
        {
            return Convert.ToInt64(ExecuteString(StoredProcedure, Para));
        }

        public static void ExecuteNull(string StoredProcedure, SqlParameter[] Para)
        {
            SqlConnection connection = new SqlConnection(ConnStr);
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StoredProcedure;
            foreach (SqlParameter parameter in Para)
            {
                command.Parameters.Add(parameter);
            }
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
        }

        public static string ExecuteString(string StoredProcedure, SqlParameter[] Para)
        {
            SqlConnection connection = new SqlConnection(ConnStr);
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = StoredProcedure;
            foreach (SqlParameter parameter in Para)
            {
                command.Parameters.Add(parameter);
            }
            connection.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return command.Parameters["@Result"].Value.ToString().Trim();
        }

        public static int command(string sql, params SqlParameter[] para)
        {
            SqlConnection connection = new SqlConnection(ConnStr);
                SqlCommand cmd = new SqlCommand(sql, connection);
            try
            {
                
                connection.Open();
                cmd.Parameters.AddRange(para);
                 return  cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }

        public static int ExecuteString(string sqlstr)
        {
            SqlConnection connection = new SqlConnection(ConnStr);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = sqlstr;
            connection.Open();
            try
            {
                command.ExecuteNonQuery();
                return 0;
            }
            catch
            {
                return 1;
            }
            finally
            {
                command.Dispose();
                connection.Close();
            }
        }

        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }


   

        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }


        public static object GetSingle(string SQLString, params SqlParameter[] para)
        {

           

            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        foreach (SqlParameter parameter in para)
                        {
                            cmd.Parameters.Add(parameter);
                        }

                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }

        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnStr))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
     

     

    


    }
}

