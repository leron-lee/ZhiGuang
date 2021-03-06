﻿using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace Web.ajax
{
    public partial class cai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string fig = "0";
                if (base.Request.QueryString["id"] != null)
                {
                    int id = System.Convert.ToInt32(base.Request.QueryString["id"]);
                    if (base.Request.Cookies["cai_" + id] == null)
                    {
                        HttpCookie cook = new HttpCookie("cai_" + id);
                        cook.Expires = System.DateTime.Now.AddYears(1);
                        cook.Value = "";
                        base.Response.Cookies.Add(cook);
                        new SqlHelper().ExecuteNonQuery("update merchandise set s7 = s7+1 where id = " + id);
                        fig = "1";
                    }
                    else
                    {
                        fig = "2";
                    }
                }
                base.Response.Write(fig);
                base.Response.End();
            }
        }
    }
}