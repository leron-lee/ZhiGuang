namespace CT.WebUtility
{
    using System;

    public class Condition
    {
        private string _conditions;
        private string _fieldlist;
        private string _orderby;
        private string _tablename;
        private int _topnum;

        public Condition()
        {
            this._tablename = string.Empty;
            this._topnum = 0;
            this._fieldlist = " * ";
            this._conditions = " Where 1=1 ";
            this._orderby = " Order By Id Desc";
        }

        public Condition(string OrderBy)
        {
            this._tablename = string.Empty;
            this._topnum = 0;
            this._fieldlist = " * ";
            this._conditions = " Where 1=1 ";
            this._orderby = " Order By Id Desc";
            if (OrderBy.Trim().IndexOf("Order By") == 0)
            {
                this._orderby = (OrderBy.Length == 0) ? string.Empty : (" Order By " + OrderBy);
            }
            else
            {
                this._conditions = this._conditions + OrderBy;
            }
        }

        public Condition(int TopNum, string Conditions)
        {
            this._tablename = string.Empty;
            this._topnum = 0;
            this._fieldlist = " * ";
            this._conditions = " Where 1=1 ";
            this._orderby = " Order By Id Desc";
            this._topnum = TopNum;
            this._conditions = this._conditions + Conditions;
        }

        public Condition(string Conditions, string OrderBy)
        {
            this._tablename = string.Empty;
            this._topnum = 0;
            this._fieldlist = " * ";
            this._conditions = " Where 1=1 ";
            this._orderby = " Order By Id Desc";
            this._conditions = this._conditions + Conditions;
            this._orderby = (OrderBy.Length == 0) ? string.Empty : (" Order By " + OrderBy);
        }

        public Condition(int TopNum, string Conditions, string OrderBy)
        {
            this._tablename = string.Empty;
            this._topnum = 0;
            this._fieldlist = " * ";
            this._conditions = " Where 1=1 ";
            this._orderby = " Order By Id Desc";
            this._topnum = TopNum;
            this._conditions = this._conditions + Conditions;
            this._orderby = (OrderBy.Length == 0) ? string.Empty : (" Order By " + OrderBy);
        }

        public string AddCondition(string value)
        {
            this._conditions = this._conditions + value + " ";
            return this._conditions;
        }

        public string Conditions
        {
            get
            {
                return ((this._conditions == " Where 1=1 ") ? string.Empty : this._conditions);
            }
            set
            {
                this._conditions = " Where 1=1 " + value + " ";
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

        public string OrderBy
        {
            get
            {
                return this._orderby;
            }
            set
            {
                this._orderby = " Order By " + value;
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

        public int TopNum
        {
            get
            {
                return this._topnum;
            }
            set
            {
                this._topnum = value;
            }
        }
    }
}

