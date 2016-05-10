using System;
public class json
{
    public static string JsonTooo(string s1, string s2)
    {
        string fig = "";
        int cd = s1.Length;
        s1 = s1.Substring(1, cd - 2).Replace("http:", "http");
        string[] sk = s1.Split(new char[]
		{
			','
		});
        string[] array = sk;
        for (int i = 0; i < array.Length; i++)
        {
            string sa = array[i];
            string[] st = sa.Split(new char[]
			{
				':'
			});
            if (st[0].Replace("\"", "") == s2)
            {
                fig = st[1].Replace("\"", "");
            }
        }
        if (fig.Contains("http"))
        {
            fig = fig.Replace("http", "http:").Replace("\\", "");
        }
        return fig;
    }
}
