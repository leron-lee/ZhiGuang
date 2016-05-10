namespace CT.WebUtility
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;

    public class PageList
    {
        private string _condition = " WHERE 1=1 ";
        private string _cssclass = "page";
        private string _cssstyle = string.Empty;
        private int _currpage = 1;
        private string _fieldlist = "*";
        private string _href = string.Empty;
        private bool _ismustshowfirstpage = false;
        private bool _ismustshowlastpage = false;
        private bool _ismustshownextpage = false;
        private bool _ismustshowprevpage = false;
        private string _navstyle = string.Empty;
        private string _orderby = null;
        private int _pagecount = 0;
        private int _pagesize = 10;
        private string _pkey = "id";
        private int _recordcount = 0;
        private string _sql = string.Empty;
        private string _sqlgetrc = string.Empty;
        private string _tablename = string.Empty;
        private string[] _taghtml = new string[] { "<input type=\"checkbox\" id=\"checkall\" value=\"0\" onclick=\"var obj=document.getElementsByName('groupid');for(var i=0,j=obj.length;i<j;i++)obj[i].checked=this.checked;\"><label for=checkall>全选</label>&nbsp;<input type=\"submit\" name=\"submit\" value=\"删除\" onclick=\"var obj=document.getElementsByName('groupid');for(var i=0,j=obj.length;i<j;i++){if(obj[i].checked)if(confirm('确实要删除该记录吗？\\n删除后，无法恢复。')){return true;}else{return false;}}alert('没有选中记录！');return false;\" style=\"font-size: 12px;border-width: 0px;padding-top: 3px;border-style: solid;\">", "<span class=\"p_total\" title=\"总记录数\">{$RecordCount}</span>", "<span class=\"p_pages\" title=\"当前页/总页数\">{$CurrPage}/{$PageCount}</span>", "<a href=\"{$Href}\" class=\"p_redirect\">1..</a>", "<a href=\"{$Href}\" class=\"p_redirect\">上一页</a>", "<a href=\"{$Href}\" class=\"p_num\">{$pageno}</a>", "<a class=\"p_current\">{$pageno}</a>", "<a href=\"{$Href}\" class=\"p_redirect\">下一页</a>", "<a href=\"{$Href}\" class=\"p_redirect\">..{$PageCount}</a>", "<a class=\"goto\" title=\"input the page\"><input type=\"text\" onkeydown=\"if(event.keyCode==13) {window.location='{$Href}'.replace('{$pageno}',this.value); return false;}\"></a>", "转到<select onchange=\"window.location='{$Href}'.replace('{$pageno}',this.value);\">{$optionlist}</select>页", "", "", "", "" };
        private string _template = string.Empty;
        private string _thisscriptname = string.Empty;
        private int _turnnum = 10;
        private int endPage = 0;
        private int startPage = 0;

        public string AddCondition(string value)
        {
            this._condition = this._condition + value;
            return this._condition;
        }

        public void AddParam(string name, int value)
        {
            this.AddParam(name, value.ToString(), true);
        }

        public void AddParam(string name, string value)
        {
            this.AddParam(name, value, true);
        }

        public void AddParam(string name, string value, bool IsNeedUrlEncode)
        {
            if (IsNeedUrlEncode)
            {
                value = HttpUtility.UrlEncode(value);
            }
            if (this._href == string.Empty)
            {
                this._href = this._thisscriptname + "?" + name + "=" + value;
            }
            else
            {
                string str = this._href;
                this._href = str + "&" + name + "=" + value;
            }
        }

        public void DelParam(string name)
        {
            if (!(this._href == string.Empty))
            {
                this._href = Regex.Replace(this._href, @"(\?|&)(" + name + "=(.*?))(&|$)", "$1$4", RegexOptions.IgnoreCase);
            }
        }

        public string GetPageNav()
        {
            int num;
            string href = this.Href;
            string template = this.Template;
            if (this.CurrPage > this.PageCount)
            {
                this.CurrPage = this.PageCount;
            }
            if (template.IndexOf("{$TagDelRecord}") > -1)
            {
                template = template.Replace("{$TagDelRecord}", this._taghtml[0]);
            }
            if (template.IndexOf("{$TagRecordCount}") > -1)
            {
                template = template.Replace("{$TagRecordCount}", this._taghtml[1].Replace("{$RecordCount}", this.RecordCount.ToString()));
            }
            if (template.IndexOf("{$TagPageInfo}") > -1)
            {
                template = template.Replace("{$TagPageInfo}", this._taghtml[2].Replace("{$CurrPage}", this.CurrPage.ToString())).Replace("{$PageCount}", this.PageCount.ToString());
            }
            if (template.IndexOf("{$TagPagePrev}") > -1)
            {
                if (((this.CurrPage > 1) && (this._pagecount > 1)) || this._ismustshowprevpage)
                {
                    template = template.Replace("{$TagPagePrev}", this._taghtml[4].Replace("{$Href}", href.Replace("{$pageno}", ((this.CurrPage - 1) == 0) ? "1" : (num = this.CurrPage - 1).ToString())));
                }
                else
                {
                    template = template.Replace("{$TagPagePrev}", this._taghtml[12]);
                }
            }
            if (template.IndexOf("{$TagPageTurn}") > -1)
            {
                template = template.Replace("{$TagPageTurn}", this.GetPageTurn());
            }
            if (template.IndexOf("{$TagPageNext}") > -1)
            {
                if ((this.CurrPage < this._pagecount) || this._ismustshownextpage)
                {
                    template = template.Replace("{$TagPageNext}", this._taghtml[7].Replace("{$Href}", href.Replace("{$pageno}", (this.CurrPage < this.PageCount) ? (num = this.CurrPage + 1).ToString() : ((this.PageCount < 1) ? "1" : this.PageCount.ToString()))));
                }
                else
                {
                    template = template.Replace("{$TagPageNext}", this._taghtml[13]);
                }
            }
            if (template.IndexOf("{$TagPageFrist}") > -1)
            {
                if (((this.CurrPage > 1) && ((this.startPage > 1) || (this._navstyle == "4"))) || this._ismustshowfirstpage)
                {
                    template = template.Replace("{$TagPageFrist}", this._taghtml[3].Replace("{$Href}", href.Replace("{$pageno}", "1")));
                }
                else
                {
                    template = template.Replace("{$TagPageFrist}", this._taghtml[11]);
                }
            }
            if (template.IndexOf("{$TagPageLast}") > -1)
            {
                if (((this.CurrPage < this._pagecount) && (this.endPage < this._pagecount)) || this._ismustshowlastpage)
                {
                    template = template.Replace("{$TagPageLast}", this._taghtml[8].Replace("{$Href}", href.Replace("{$pageno}", (this.PageCount < 1) ? "1" : this.PageCount.ToString())).Replace("{$PageCount}", (this.PageCount < 1) ? "1" : this.PageCount.ToString()));
                }
                else
                {
                    template = template.Replace("{$TagPageLast}", this._taghtml[14]);
                }
            }
            if (template.IndexOf("{$TagGoTo}") > -1)
            {
                template = template.Replace("{$TagGoTo}", this._taghtml[9].Replace("{$Href}", href));
            }
            if (template.IndexOf("{$TagSelectGoTo}") > -1)
            {
                template = template.Replace("{$TagSelectGoTo}", this._taghtml[10].Replace("{$Href}", href.Replace("'", @"\'"))).Replace("{$optionlist}", this.GetSelectOption());
            }
            return template.Replace("{$CssClass}", this.CssClass).Replace("{$CssStyle}", this.CssStyle);
        }

        private string GetPageTurn()
        {
            if (this.CurrPage > 0x61)
            {
                this._turnnum -= 2;
            }
            if (this.CurrPage > 0x3e5)
            {
                this._turnnum -= 2;
            }
            StringBuilder builder = new StringBuilder("");
            string str = this._taghtml[5].Replace("{$Href}", this.Href);
            if ((this.PageCount <= this._turnnum) || (this.CurrPage < 4))
            {
                this.startPage = 1;
                this.endPage = this._turnnum;
                if (this.endPage > this.PageCount)
                {
                    this.endPage = this.PageCount;
                }
            }
            else if ((this.PageCount - this.CurrPage) < (this._turnnum - 2))
            {
                this.startPage = (this.PageCount - this._turnnum) + 1;
                this.endPage = this.PageCount;
            }
            else
            {
                this.startPage = this.CurrPage - 2;
                this.endPage = this.CurrPage + (this._turnnum - 3);
            }
            for (int i = this.startPage; i <= this.endPage; i++)
            {
                if (i == this.CurrPage)
                {
                    builder.Append(this._taghtml[6].Replace("{$pageno}", i.ToString()));
                }
                else
                {
                    builder.Append(str.Replace("{$pageno}", i.ToString()));
                }
            }
            return builder.ToString();
        }

        private string GetSelectOption()
        {
            StringBuilder builder = new StringBuilder("");
            for (int i = 1; i <= this.PageCount; i++)
            {
                if (i == this.CurrPage)
                {
                    builder.Append(string.Concat(new object[] { "<option value=\"", i, "\" selected>", i, "</option>" }));
                }
                else
                {
                    builder.Append(string.Concat(new object[] { "<option value=\"", i, "\">", i, "</option>" }));
                }
            }
            return builder.ToString();
        }

        public string Condition
        {
            get
            {
                if (this._condition == " WHERE 1=1 ")
                {
                    return string.Empty;
                }
                return this._condition;
            }
            set
            {
                this._condition = " WHERE 1=1 " + value;
            }
        }

        public string CssClass
        {
            get
            {
                return this._cssclass;
            }
            set
            {
                this._cssclass = value;
            }
        }

        public string CssStyle
        {
            get
            {
                return this._cssstyle;
            }
            set
            {
                this._cssstyle = value;
            }
        }

        public int CurrPage
        {
            get
            {
                return this._currpage;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                this._currpage = value;
            }
        }

        public string FieldList
        {
            get
            {
                return this._fieldlist;
            }
            set
            {
                this._fieldlist = value;
            }
        }

        public string Href
        {
            get
            {
                if (this._href.IndexOf("{$pageno}") == -1)
                {
                    this.AddParam("page", "{$pageno}", false);
                }
                return this._href;
            }
        }

        public bool IsMustShowFirstPage
        {
            get
            {
                return this._ismustshowfirstpage;
            }
            set
            {
                this._ismustshowfirstpage = value;
            }
        }

        public bool IsMustShowLastPage
        {
            get
            {
                return this._ismustshowlastpage;
            }
            set
            {
                this._ismustshowlastpage = value;
            }
        }

        public bool IsMustShowNextPage
        {
            get
            {
                return this._ismustshownextpage;
            }
            set
            {
                this._ismustshownextpage = value;
            }
        }

        public bool IsMustShowPrevPage
        {
            get
            {
                return this._ismustshowprevpage;
            }
            set
            {
                this._ismustshowprevpage = value;
            }
        }

        public string NavStyle
        {
            get
            {
                return this._navstyle;
            }
            set
            {
                this._navstyle = value;
            }
        }

        public string OrderBy
        {
            get
            {
                if (this._orderby == null)
                {
                    return (" Order By " + this._pkey + " Desc");
                }
                return this._orderby;
            }
            set
            {
                this._orderby = " Order By " + value;
            }
        }

        public int PageCount
        {
            get
            {
                return this._pagecount;
            }
            set
            {
                this._pagecount = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this._pagesize;
            }
            set
            {
                this._pagesize = value;
            }
        }

        public string PKey
        {
            get
            {
                return this._pkey;
            }
            set
            {
                this._pkey = value;
            }
        }

        public int RecordCount
        {
            get
            {
                return this._recordcount;
            }
            set
            {
                this._recordcount = value;
            }
        }

        public string Sql
        {
            get
            {
                if (this._sql == string.Empty)
                {
                    if (this.CurrPage == 1)
                    {
                        this._sql = string.Concat(new object[] { "SELECT TOP ", this.PageSize, " ", this.FieldList, " FROM ", this.TableName, this.Condition, this.OrderBy });
                    }
                    else
                    {
                        object[] objArray = new object[] { 
                            "SELECT TOP ", this.PageSize, " ", this.FieldList, " FROM ", this.TableName, " WHERE ", this.PKey, " NOT IN (SELECT TOP ", ((this.CurrPage - 1) * this.PageSize).ToString(), " ", this.PKey, " FROM ", this.TableName, this.Condition, this.OrderBy, 
                            ")", this.Condition.Replace(" WHERE 1=1", string.Empty), this.OrderBy
                         };
                        this._sql = string.Concat(objArray);
                    }
                }
                return this._sql;
            }
            set
            {
                this._sql = value;
            }
        }

        public string SqlGetRC
        {
            get
            {
                if (this._sqlgetrc == string.Empty)
                {
                    this._sqlgetrc = "SELECT @RecordCount=COUNT(0) FROM " + this._tablename + this._condition;
                }
                return this._sqlgetrc;
            }
            set
            {
                this._sqlgetrc = value;
            }
        }

        public string TableName
        {
            get
            {
                return this._tablename;
            }
            set
            {
                this._tablename = value;
            }
        }

        public string Template
        {
            get
            {
                if (!(this._template == string.Empty))
                {
                    return this._template;
                }
                switch (this._navstyle)
                {
                    case "1":
                        return "<span class=\"{$CssClass}\" style=\"{$CssStyle}\">{$TagRecordCount}{$TagPageInfo}{$TagPagePrev}{$TagPageFrist}{$TagPageTurn}{$TagPageLast}{$TagPageNext}{$TagGoTo}</span>";

                    case "2":
                        this._taghtml[3] = "<a href=\"{$Href}\">首页</a>";
                        this._taghtml[4] = "<a href=\"{$Href}\">上一页</a>";
                        this._taghtml[5] = "<a href=\"{$Href}\">{$pageno}</a> ";
                        this._taghtml[6] = "{$pageno} ";
                        this._taghtml[7] = "<a href=\"{$Href}\">下一页</a>";
                        this._taghtml[8] = "<a href=\"{$Href}\">尾页</a>";
                        return "{$TagPageFrist} {$TagPagePrev} {$TagPageTurn}{$TagPageNext} {$TagPageLast} {$TagSelectGoTo}";

                    case "3":
                        this._taghtml[0] = "<input type=\"checkbox\" id=\"checkall\" value=\"0\" onclick=\"var obj=document.getElementsByName('groupid');for(var i=0,j=obj.length;i<j;i++)obj[i].checked=this.checked;\"><label for=checkall>全选</label>&nbsp;<input type=\"submit\" name=\"submit\" value=\"删除\" onclick=\"var obj=document.getElementsByName('groupid');for(var i=0,j=obj.length;i<j;i++){if(obj[i].checked)if(confirm('确实要删除该记录吗？\\n删除后，无法恢复。')){return true;}else{return false;}}alert('没有选中记录！');return false;\" style=\"font-size: 12px;border-width: 0px;padding-top: 3px;border-style: solid;\">&nbsp;&nbsp;<input type=\"submit\" name=\"submit\" value=\"审核通过\" onclick=\"this.form.action='review.aspx?action=pass';\"  style=\"font-size: 12px;border-width: 0px;padding-top: 3px;border-style: solid;\">";
                        return "<span class=\"{$CssClass}\" style=\"{$CssStyle}\">{$TagDelRecord} {$TagRecordCount}{$TagPageInfo}{$TagPagePrev}{$TagPageFrist}{$TagPageTurn}{$TagPageLast}{$TagPageNext}{$TagGoTo}</span>";

                    case "4":
                        this._taghtml[3] = "<a href=\"{$Href}\">首页</a>";
                        this._taghtml[4] = "<a href=\"{$Href}\">上一页</a>";
                        this._taghtml[7] = "<a href=\"{$Href}\">下一页</a>";
                        this._taghtml[8] = "<a href=\"{$Href}\">尾页</a>";
                        this._taghtml[11] = "首页";
                        this._taghtml[12] = "上一页";
                        this._taghtml[13] = "下一页";
                        this._taghtml[14] = "尾页";
                        return "共{$TagRecordCount}条记录 {$TagPageFrist} | {$TagPagePrev} | {$TagPageNext} | {$TagPageLast} {$TagSelectGoTo}";
                }
                return "<span class=\"{$CssClass}\" style=\"{$CssStyle}\">{$TagDelRecord} {$TagRecordCount}{$TagPageInfo}{$TagPagePrev}{$TagPageFrist}{$TagPageTurn}{$TagPageLast}{$TagPageNext}{$TagGoTo}</span>";
            }
            set
            {
                this._template = value;
            }
        }

        public int TurnNum
        {
            get
            {
                return this._turnnum;
            }
            set
            {
                this._turnnum = value;
            }
        }
    }
}

