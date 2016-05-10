using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Caching;
public class access
{
    private HttpContext context = HttpContext.Current;
    public int ExecuteNonQuery(string sql)
    {
        return new SqlHelper().ExecuteNonQuery(sql);
    }
    public int ExecuteNonQuery(string sql, SqlParameter[] parameters)
    {
        return new SqlHelper().ExecuteNonQuery(sql, parameters);
    }
    public string ExecuteScalar(string sql)
    {
        object fig;
        if (this.iftj() == 1)
        {
            if (this.context.Cache[sql] == null)
            {
                string a = new SqlHelper().ExecuteScalar(sql);
                if (a != "")
                {
                    this.context.Cache.Insert(sql, a, null, this.times(), Cache.NoSlidingExpiration);
                }
                fig = a;
            }
            else
            {
                fig = this.context.Cache[sql];
            }
        }
        else
        {
            fig = new SqlHelper().ExecuteScalar(sql);
        }
        return System.Convert.ToString(fig);
    }
    public string ExecuteScalar(string sql, SqlParameter[] parameters)
    {
        object fig;
        if (this.iftj() == 1)
        {
            if (this.context.Cache[sql] == null)
            {
                string a = new SqlHelper().ExecuteScalar(sql, parameters);
                if (a != "")
                {
                    this.context.Cache.Insert(sql, a, null, this.times(), Cache.NoSlidingExpiration);
                }
                fig = a;
            }
            else
            {
                fig = this.context.Cache[sql];
            }
        }
        else
        {
            fig = new SqlHelper().ExecuteScalar(sql, parameters);
        }
        return System.Convert.ToString(fig);
    }
    public DataTable ExecuteDataTable(string sql)
    {
        DataTable fig = null;
        if (this.iftj() == 1)
        {
            if (this.context.Cache[sql] == null)
            {
                DataTable a = new SqlHelper().ExecuteDataTable(sql);
                if (a != null)
                {
                    this.context.Cache.Insert(sql, a, null, this.times(), Cache.NoSlidingExpiration);
                    fig = a;
                }
            }
            else
            {
                fig = (DataTable)this.context.Cache[sql];
            }
        }
        else
        {
            fig = new SqlHelper().ExecuteDataTable(sql);
        }
        return fig;
    }
    public DataTable ExecuteDataTable(string sql, SqlParameter[] parameters)
    {
        DataTable fig = null;
        if (this.iftj() == 1)
        {
            if (this.context.Cache[sql] == null)
            {
                DataTable a = new SqlHelper().ExecuteDataTable(sql, parameters);
                if (a != null)
                {
                    this.context.Cache.Insert(sql, a, null, this.times(), Cache.NoSlidingExpiration);
                    fig = a;
                }
            }
            else
            {
                fig = (DataTable)this.context.Cache[sql];
            }
        }
        else
        {
            fig = new SqlHelper().ExecuteDataTable(sql, parameters);
        }
        return fig;
    }
    public int iftj()
    {
        return 1;
    }
    public System.DateTime times()
    {
        return System.DateTime.Now.AddDays(1.0);
    }
}
