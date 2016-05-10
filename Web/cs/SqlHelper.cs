using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
public class SqlHelper
{
    private string strConnectionString = "";
    public SqlConnection cnn;
    public void Open()
    {
        if (this.cnn == null)
        {
            this.cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString);
        }
        if (this.cnn.State == ConnectionState.Closed)
        {
            try
            {
                this.cnn.Open();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
    public void close()
    {
        if (this.cnn != null)
        {
            if (this.cnn.State == ConnectionState.Open)
            {
                this.cnn.Close();
                this.cnn.Dispose();
            }
        }
    }
    public void Dispose()
    {
        if (this.cnn != null)
        {
            this.cnn.Dispose();
            this.cnn = null;
        }
    }
    public SqlHelper()
    {
        this.strConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
    }
    public int ExecuteNonQuery(string query)
    {
        int result;
        using (this.cnn = new SqlConnection(this.strConnectionString))
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            if (query.StartsWith("SELECT") | query.StartsWith("select") | query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete"))
            {
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            int retval;
            try
            {
                this.cnn.Open();
                retval = cmd.ExecuteNonQuery();
            }
            catch (System.Exception exp)
            {
                throw exp;
            }
            cmd.Dispose();
            this.cnn.Dispose();
            this.cnn.Close();
            result = retval;
        }
        return result;
    }
    public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
    {
        int result;
        using (this.cnn = new SqlConnection(this.strConnectionString))
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            if (query.StartsWith("SELECT") | query.StartsWith("select") | query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete"))
            {
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            for (int i = 0; i <= parameters.Length - 1; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            this.cnn.Open();
            int retval = cmd.ExecuteNonQuery();
            cmd.Dispose();
            this.cnn.Dispose();
            this.cnn.Close();
            result = retval;
        }
        return result;
    }
    public string ExecuteScalar(string query)
    {
        string result;
        using (this.cnn = new SqlConnection(this.strConnectionString))
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            if (query.StartsWith("SELECT") | query.StartsWith("select"))
            {
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            this.cnn.Open();
            object retval = cmd.ExecuteScalar();
            cmd.Dispose();
            this.cnn.Dispose();
            this.cnn.Close();
            result = System.Convert.ToString(retval);
        }
        return result;
    }
    public string ExecuteScalar(string query, params SqlParameter[] parameters)
    {
        string result;
        using (this.cnn = new SqlConnection(this.strConnectionString))
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            if (query.StartsWith("SELECT") | query.StartsWith("select") | query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete"))
            {
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            for (int i = 0; i <= parameters.Length - 1; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            this.cnn.Open();
            object retval = cmd.ExecuteScalar();
            cmd.Dispose();
            this.cnn.Dispose();
            this.cnn.Close();
            result = System.Convert.ToString(retval);
        }
        return result;
    }
    public DataTable ExecuteDataTable(string query)
    {
        DataTable result;
        using (this.cnn = new SqlConnection(this.strConnectionString))
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            if (query.StartsWith("SELECT") | query.StartsWith("select") | query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete"))
            {
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Dispose();
            da.Dispose();
            this.cnn.Dispose();
            this.cnn.Close();
            result = ds.Tables[0];
        }
        return result;
    }
    public DataTable ExecuteDataTable(string query, string uc)
    {
        DataTable result;
        using (this.cnn = new SqlConnection(this.strConnectionString))
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            if (query.StartsWith("SELECT") | query.StartsWith("select") | query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete"))
            {
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, uc);
            cmd.Dispose();
            da.Dispose();
            this.cnn.Dispose();
            this.cnn.Close();
            result = ds.Tables[0];
        }
        return result;
    }
    public DataTable ExecuteDataTable(string query, params SqlParameter[] parameters)
    {
        DataTable result;
        using (this.cnn = new SqlConnection(this.strConnectionString))
        {
            SqlCommand cmd = new SqlCommand(query, this.cnn);
            if (query.StartsWith("SELECT") | query.StartsWith("select") | query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete"))
            {
                cmd.CommandType = CommandType.Text;
            }
            else
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            for (int i = 0; i <= parameters.Length - 1; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.Dispose();
            da.Dispose();
            this.cnn.Dispose();
            this.cnn.Close();
            result = ds.Tables[0];
        }
        return result;
    }
    public System.Collections.Generic.List<T> ExecuteList<T>(string commandText, params SqlParameter[] param)
    {
        System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();
        this.cnn = new SqlConnection(this.strConnectionString);
        using (this.cnn)
        {
            using (SqlCommand cmd = new SqlCommand(commandText, this.cnn))
            {
                try
                {
                    if (commandText.StartsWith("SELECT") | commandText.StartsWith("select") | commandText.StartsWith("INSERT") | commandText.StartsWith("insert") | commandText.StartsWith("UPDATE") | commandText.StartsWith("update") | commandText.StartsWith("DELETE") | commandText.StartsWith("delete"))
                    {
                        cmd.CommandType = CommandType.Text;
                    }
                    else
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    cmd.Parameters.AddRange(param);
                    this.cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        T obj = SqlHelper.ExecuteDataReader<T>(reader);
                        list.Add(obj);
                    }
                    cmd.Dispose();
                    reader.Dispose();
                    reader.Close();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.cnn.Close();
                }
            }
        }
        return list;
    }
    public System.Collections.Generic.List<T> ExecuteList<T>(string commandText)
    {
        System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();
        this.cnn = new SqlConnection(this.strConnectionString);
        using (this.cnn)
        {
            using (SqlCommand cmd = new SqlCommand(commandText, this.cnn))
            {
                try
                {
                    if (commandText.StartsWith("SELECT") | commandText.StartsWith("select") | commandText.StartsWith("INSERT") | commandText.StartsWith("insert") | commandText.StartsWith("UPDATE") | commandText.StartsWith("update") | commandText.StartsWith("DELETE") | commandText.StartsWith("delete"))
                    {
                        cmd.CommandType = CommandType.Text;
                    }
                    else
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }
                    this.cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        T obj = SqlHelper.ExecuteDataReader<T>(reader);
                        list.Add(obj);
                    }
                    cmd.Dispose();
                    reader.Dispose();
                    reader.Close();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    this.cnn.Close();
                }
            }
        }
        return list;
    }
    private static T ExecuteDataReader<T>(IDataReader reader)
    {
        T obj = default(T);
        try
        {
            System.Type type = typeof(T);
            obj = (T)((object)System.Activator.CreateInstance(type));
            System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
            System.Reflection.PropertyInfo[] array = propertyInfos;
            for (int j = 0; j < array.Length; j++)
            {
                System.Reflection.PropertyInfo propertyInfo = array[j];
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string fieldName = reader.GetName(i);
                    if (fieldName.ToLower() == propertyInfo.Name.ToLower())
                    {
                        object val = reader[propertyInfo.Name];
                        if (val != null && val != System.DBNull.Value)
                        {
                            propertyInfo.SetValue(obj, val, null);
                        }
                        break;
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
        return obj;
    }
}
