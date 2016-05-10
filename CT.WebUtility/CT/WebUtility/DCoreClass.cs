namespace CT.WebUtility
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.Data.SqlClient;

    internal class DCoreClass
    {
        public int Del(CoreClassInfo info)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TableName", info.TableName), new SqlParameter("@id", info.id), new SqlParameter("@Result", SqlDbType.Int) };
            para[para.Length - 1].Direction = ParameterDirection.Output;
            return Sql.ExecuteInt("Z___CoreClass_Del", para);
        }

        public CoreClassInfo GetInfo(CoreClassInfo info)
        {
            string str = string.Empty;
            for (int i = 0; i < info.ExtendField.Count; i++)
            {
                str = str + ", [" + info.ExtendField.GetKey(i) + "]";
            }
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TableName", info.TableName), new SqlParameter("@id", info.id), new SqlParameter("@ExtendField", str), new SqlParameter("@Result", SqlDbType.Int) };
            para[para.Length - 1].Direction = ParameterDirection.Output;
            DataSet set = Sql.ExecuteDataSet("Z___CoreClass_GetInfoById", para);
            CoreClassInfo info2 = null;
            if (set.Tables[0].Rows.Count <= 0)
            {
                return info2;
            }
            DataRow row = set.Tables[0].Rows[0];
            NameValueCollection extendField = new NameValueCollection();
            for (int j = 0; j < info.ExtendField.Count; j++)
            {
                extendField.Set(info.ExtendField.GetKey(j), row[info.ExtendField.GetKey(j)].ToString());
            }
            return new CoreClassInfo(info.TableName, 0, CT.WebUtility.Check.Int(row["id"]), CT.WebUtility.Check.StrDoNothing(row["ClassName"]), CT.WebUtility.Check.Int(row["ParentId"]), CT.WebUtility.Check.Int(row["Depth"]), CT.WebUtility.Check.Int(row["RootId"]), CT.WebUtility.Check.Int(row["Orders"]), CT.WebUtility.Check.Int(row["ChildCount"]), CT.WebUtility.Check.StrDoNothing(row["ParentIdRoute"]), CT.WebUtility.Check.StrDoNothing(row["ParentNameRoute"]), CT.WebUtility.Check.DateTime(row["CreateTime"]), CT.WebUtility.Check.Int(row["RecordCount"]), CT.WebUtility.Check.Int(row["TemplateId"]), CT.WebUtility.Check.StrDoNothing(row["OtherName"]), CT.WebUtility.Check.StrDoNothing(row["ClassNameEn"]), CT.WebUtility.Check.StrDoNothing(row["FolderName"]), CT.WebUtility.Check.StrDoNothing(row["PicPath"]), CT.WebUtility.Check.Boolean(row["IsHide"]), extendField);
        }

        public IList<CoreClassInfo> GetList(CoreClassInfo info, int TopNum, string sWhere, string sOrderBy)
        {
            int num;
            IList<CoreClassInfo> list = new List<CoreClassInfo>();
            string str = string.Empty;
            for (num = 0; num < info.ExtendField.Count; num++)
            {
                str = str + ", [" + info.ExtendField.GetKey(num) + "]";
            }
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TableName", info.TableName), new SqlParameter("@ExtendField", str), new SqlParameter("@TopNum", TopNum), new SqlParameter("@Where", sWhere), new SqlParameter("@OrderBy", sOrderBy), new SqlParameter("@Result", SqlDbType.Int) };
            para[para.Length - 1].Direction = ParameterDirection.Output;
            DataSet set = Sql.ExecuteDataSet("Z___CoreClass_GetInfoByCondition", para);
            for (num = 0; num < set.Tables[0].Rows.Count; num++)
            {
                DataRow row = set.Tables[0].Rows[num];
                NameValueCollection extendField = new NameValueCollection();
                for (int i = 0; i < info.ExtendField.Count; i++)
                {
                    extendField.Set(info.ExtendField.GetKey(i), row[info.ExtendField.GetKey(i)].ToString());
                }
                CoreClassInfo item = new CoreClassInfo(info.TableName, 0, CT.WebUtility.Check.Int(row["id"]), CT.WebUtility.Check.StrDoNothing(row["ClassName"]), CT.WebUtility.Check.Int(row["ParentId"]), CT.WebUtility.Check.Int(row["Depth"]), CT.WebUtility.Check.Int(row["RootId"]), CT.WebUtility.Check.Int(row["Orders"]), CT.WebUtility.Check.Int(row["ChildCount"]), CT.WebUtility.Check.StrDoNothing(row["ParentIdRoute"]), CT.WebUtility.Check.StrDoNothing(row["ParentNameRoute"]), CT.WebUtility.Check.DateTime(row["CreateTime"]), CT.WebUtility.Check.Int(row["RecordCount"]), CT.WebUtility.Check.Int(row["TemplateId"]), CT.WebUtility.Check.StrDoNothing(row["OtherName"]), CT.WebUtility.Check.StrDoNothing(row["ClassNameEn"]), CT.WebUtility.Check.StrDoNothing(row["FolderName"]), CT.WebUtility.Check.StrDoNothing(row["PicPath"]), CT.WebUtility.Check.Boolean(row["IsHide"]), extendField);
                list.Add(item);
            }
            return list;
        }

        public int Insert(CoreClassInfo info)
        {
            string str = string.Empty;
            string str2 = string.Empty;
            for (int i = 0; i < info.ExtendField.Count; i++)
            {
                str = str + ", [" + info.ExtendField.GetKey(i) + "]";
                str2 = str2 + ", '" + info.ExtendField[info.ExtendField.GetKey(i)] + "'";
            }
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TableName", info.TableName), new SqlParameter("@NewId", info.NewId), new SqlParameter("@ClassName", info.ClassName), new SqlParameter("@ParentId", info.ParentId), new SqlParameter("@CreateTime", info.CreateTime), new SqlParameter("@RecordCount", info.RecordCount), new SqlParameter("@TemplateId", info.TemplateId), new SqlParameter("@OtherName", info.OtherName), new SqlParameter("@ClassNameEn", info.ClassNameEn), new SqlParameter("@FolderName", info.FolderName), new SqlParameter("@PicPath", info.PicPath), new SqlParameter("@IsHide", info.IsHide), new SqlParameter("@ExtendField", str), new SqlParameter("@ExtendFieldValue", str2), new SqlParameter("@LimitDepth", info.LimitDepth), new SqlParameter("@Result", SqlDbType.Int) };
            para[para.Length - 1].Direction = ParameterDirection.Output;
            return Sql.ExecuteInt("Z___CoreClass_Create", para);
        }

        public int Orders(CoreClassInfo info, bool Action)
        {
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TableName", info.TableName), new SqlParameter("@id", info.id), new SqlParameter("@Action", Action), new SqlParameter("@Result", SqlDbType.Int) };
            para[para.Length - 1].Direction = ParameterDirection.Output;
            return Sql.ExecuteInt("Z___CoreClass_Orders", para);
        }

        public int Update(CoreClassInfo info)
        {
            string str = string.Empty;
            for (int i = 0; i < info.ExtendField.Count; i++)
            {
                string str2 = str;
                str = str2 + ", [" + info.ExtendField.GetKey(i) + "]='" + info.ExtendField[info.ExtendField.GetKey(i)] + "'";
            }
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@TableName", info.TableName), new SqlParameter("@id", info.id), new SqlParameter("@NewId", info.NewId), new SqlParameter("@ClassName", info.ClassName), new SqlParameter("@ParentId", info.ParentId), new SqlParameter("@CreateTime", info.CreateTime), new SqlParameter("@RecordCount", info.RecordCount), new SqlParameter("@TemplateId", info.TemplateId), new SqlParameter("@OtherName", info.OtherName), new SqlParameter("@ClassNameEn", info.ClassNameEn), new SqlParameter("@FolderName", info.FolderName), new SqlParameter("@PicPath", info.PicPath), new SqlParameter("@IsHide", info.IsHide), new SqlParameter("@ExtendField", str), new SqlParameter("@LimitDepth", info.LimitDepth), new SqlParameter("@Result", SqlDbType.Int) };
            para[para.Length - 1].Direction = ParameterDirection.Output;
            return Sql.ExecuteInt("Z___CoreClass_Update", para);
        }
    }
}

