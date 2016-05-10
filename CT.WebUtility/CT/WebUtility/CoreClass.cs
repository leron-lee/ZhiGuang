namespace CT.WebUtility
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CoreClass
    {
        private DCoreClass _coreclass = new DCoreClass();
        private static readonly Regex ReTableNameToPath = new Regex("^D_", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex ReTemplateFieldName = new Regex(@"^\$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex ReTemplateTag = new Regex(@"\{\$(?<FieldName>.+?)\}", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public void CreateXML(CoreClassInfo info)
        {
            this.CreateXML(info, "/_js/xml/" + ReTableNameToPath.Replace(info.TableName, "").ToLower() + ".xml");
        }

        public void CreateXML(CoreClassInfo info, string path)
        {
            this.CreateXML(info, path, string.Empty, string.Empty, Encoding.UTF8);
        }

        public void CreateXML(CoreClassInfo info, string path, string sCondition)
        {
            this.CreateXML(info, path, sCondition, string.Empty, Encoding.UTF8);
        }

        public void CreateXML(CoreClassInfo info, string path, Encoding Encoding)
        {
            this.CreateXML(info, path, string.Empty, string.Empty, Encoding.UTF8);
        }

        public void CreateXML(CoreClassInfo info, string path, string sCondition, string Template)
        {
            this.CreateXML(info, path, sCondition, Template, Encoding.UTF8);
        }

        public void CreateXML(CoreClassInfo info, string path, string sCondition, string Template, Encoding Encoding)
        {
            int num2;
            if (string.IsNullOrEmpty(Template))
            {
                Template = "v=\"{$id}\" n=\"{$ClassName}\"";
            }
            if (string.IsNullOrEmpty(path))
            {
                path = "/_js/xml/" + ReTableNameToPath.Replace(info.TableName, "").ToLower() + ".xml";
            }
            path = Fun.GetRouteWithServerMapPath(path);
            IList<CoreClassInfo> list = this.GetList(info, sCondition, string.Empty);
            int depth = 0;
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?><root>");
            foreach (CoreClassInfo info2 in list)
            {
                if (info2.Depth < depth)
                {
                    num2 = 0;
                    while (num2 < (depth - info2.Depth))
                    {
                        builder.Append("</i>");
                        num2++;
                    }
                }
                builder.Append("<i ");
                builder.Append(this.Format(Template, info2));
                if (info2.ChildCount == 0)
                {
                    builder.Append(" />");
                }
                else
                {
                    builder.Append(" >");
                }
                depth = info2.Depth;
            }
            for (num2 = 0; num2 < depth; num2++)
            {
                builder.Append("</i>");
            }
            builder.Append("</root>");
            File.Write(path, builder.ToString(), Encoding);
        }

        public int Del(CoreClassInfo info)
        {
            return this._coreclass.Del(info);
        }

        private string Format(string TemplateTag, CoreClassInfo info)
        {
            MatchCollection matchs = ReTemplateTag.Matches(TemplateTag);
            string input = string.Empty;
            if (matchs.Count != 0)
            {
                foreach (Match match in matchs)
                {
                    input = match.Groups["FieldName"].ToString();
                    if (ReTemplateFieldName.IsMatch(input))
                    {
                        TemplateTag = TemplateTag.Replace("{$" + input + "}", CT.WebUtility.Check.StrDoNothing(info.ExtendField[ReTemplateFieldName.Replace(input, "")]));
                    }
                    else
                    {
                        TemplateTag = TemplateTag.Replace("{$" + input + "}", CT.WebUtility.Check.StrDoNothing(info[input]));
                    }
                }
            }
            return TemplateTag;
        }

        public CoreClassInfo GetInfo(CoreClassInfo info)
        {
            return this._coreclass.GetInfo(info);
        }

        public IList<CoreClassInfo> GetList(CoreClassInfo info)
        {
            return this.GetList(info, string.Empty, string.Empty);
        }

        public IList<CoreClassInfo> GetList(CoreClassInfo info, string sWhere, string sOrderBy)
        {
            return this._coreclass.GetList(info, 0, sWhere, sOrderBy);
        }

        public IList<CoreClassInfo> GetList(CoreClassInfo info, int TopNum, string sWhere, string sOrderBy)
        {
            return this._coreclass.GetList(info, TopNum, sWhere, sOrderBy);
        }

        public int Insert(CoreClassInfo info)
        {
            return this._coreclass.Insert(info);
        }

        public int Orders(CoreClassInfo info, bool Action)
        {
            return this._coreclass.Orders(info, Action);
        }

        public int Update(CoreClassInfo info)
        {
            return this._coreclass.Update(info);
        }
    }
}

