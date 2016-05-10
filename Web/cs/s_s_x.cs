using System;
public class s_s_x
{
    public static string s_sheng(object id)
    {
        return new access().ExecuteScalar("select name from s_sheng where id = " + id);
    }
    public static string s_shi(object id)
    {
        return new access().ExecuteScalar("select name from s_shi where id = " + id);
    }
    public static string s_xian(object id)
    {
        return new access().ExecuteScalar("select name from s_xian where id = " + id);
    }
}
