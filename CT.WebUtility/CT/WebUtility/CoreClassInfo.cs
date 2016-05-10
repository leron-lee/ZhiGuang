namespace CT.WebUtility
{
    using System;
    using System.Collections.Specialized;
    using System.Reflection;

    public class CoreClassInfo
    {
        private int _childcount;
        private string _classname;
        private string _classnameen;
        private DateTime _createtime;
        private int _depth;
        private NameValueCollection _extendfield;
        private string _foldername;
        private int _id;
        private bool _ishide;
        private int _limitdepth;
        private int _newid;
        private int _orders;
        private string _othername;
        private int _parentid;
        private string _parentidroute;
        private string _parentnameroute;
        private string _picpath;
        private int _recordcount;
        private int _rootid;
        private string _tablename;
        private int _templateid;

        public CoreClassInfo()
        {
            this._tablename = string.Empty;
            this._newid = 0;
            this._id = 0;
            this._classname = string.Empty;
            this._parentid = 0;
            this._depth = 0;
            this._rootid = 0;
            this._orders = 0;
            this._childcount = 0;
            this._parentidroute = string.Empty;
            this._parentnameroute = string.Empty;
            this._limitdepth = -1;
            this._createtime = DateTime.Now;
            this._recordcount = 0;
            this._templateid = 0;
            this._othername = string.Empty;
            this._classnameen = string.Empty;
            this._foldername = string.Empty;
            this._picpath = string.Empty;
            this._ishide = false;
            this._extendfield = new NameValueCollection();
        }

        public CoreClassInfo(string tableName, int newId, int id, string className, int parentId, int depth, int rootId, int orders, int childCount, string parentIdRoute, string parentNameRoute, DateTime createTime, int recordCount, int templateId, string otherName, string classNameEn, string folderName, string picPath, bool isHide, NameValueCollection extendField)
        {
            this._tablename = string.Empty;
            this._newid = 0;
            this._id = 0;
            this._classname = string.Empty;
            this._parentid = 0;
            this._depth = 0;
            this._rootid = 0;
            this._orders = 0;
            this._childcount = 0;
            this._parentidroute = string.Empty;
            this._parentnameroute = string.Empty;
            this._limitdepth = -1;
            this._createtime = DateTime.Now;
            this._recordcount = 0;
            this._templateid = 0;
            this._othername = string.Empty;
            this._classnameen = string.Empty;
            this._foldername = string.Empty;
            this._picpath = string.Empty;
            this._ishide = false;
            this._tablename = tableName;
            this._newid = newId;
            this._id = id;
            this._classname = className;
            this._parentid = parentId;
            this._depth = depth;
            this._rootid = rootId;
            this._orders = orders;
            this._childcount = childCount;
            this._parentidroute = parentIdRoute;
            this._parentnameroute = parentNameRoute;
            this._createtime = createTime;
            this._recordcount = recordCount;
            this._templateid = templateId;
            this._othername = otherName;
            this._classnameen = classNameEn;
            this._foldername = folderName;
            this._picpath = picPath;
            this._ishide = isHide;
            this._extendfield = extendField;
        }

        public CoreClassInfo Clone()
        {
            return (CoreClassInfo) base.MemberwiseClone();
        }

        public int ChildCount
        {
            get
            {
                return this._childcount;
            }
            set
            {
                this._childcount = value;
            }
        }

        public string ClassName
        {
            get
            {
                return this._classname;
            }
            set
            {
                this._classname = value;
            }
        }

        public string ClassNameEn
        {
            get
            {
                return this._classnameen;
            }
            set
            {
                this._classnameen = value;
            }
        }

        public DateTime CreateTime
        {
            get
            {
                return this._createtime;
            }
            set
            {
                this._createtime = value;
            }
        }

        public int Depth
        {
            get
            {
                return this._depth;
            }
            set
            {
                this._depth = value;
            }
        }

        public NameValueCollection ExtendField
        {
            get
            {
                return this._extendfield;
            }
            set
            {
                this._extendfield = value;
            }
        }

        public string FolderName
        {
            get
            {
                return this._foldername;
            }
            set
            {
                this._foldername = value;
            }
        }

        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        public bool IsHide
        {
            get
            {
                return this._ishide;
            }
            set
            {
                this._ishide = value;
            }
        }

        public object this[string name]
        {
            get
            {
                if (base.GetType().GetProperty(name) == null)
                {
                    return null;
                }
                return base.GetType().GetProperty(name).GetValue(this, null);
            }
            set
            {
                if (base.GetType().GetProperty(name) != null)
                {
                    base.GetType().GetProperty(name).SetValue(this, value, null);
                }
            }
        }

        public int LimitDepth
        {
            get
            {
                return this._limitdepth;
            }
            set
            {
                this._limitdepth = value;
            }
        }

        public int NewId
        {
            get
            {
                return this._newid;
            }
            set
            {
                this._newid = value;
            }
        }

        public int Orders
        {
            get
            {
                return this._orders;
            }
            set
            {
                this._orders = value;
            }
        }

        public string OtherName
        {
            get
            {
                return this._othername;
            }
            set
            {
                this._othername = value;
            }
        }

        public int ParentId
        {
            get
            {
                return this._parentid;
            }
            set
            {
                this._parentid = value;
            }
        }

        public string ParentIdRoute
        {
            get
            {
                return this._parentidroute;
            }
            set
            {
                this._parentidroute = value;
            }
        }

        public string ParentNameRoute
        {
            get
            {
                return this._parentnameroute;
            }
            set
            {
                this._parentnameroute = value;
            }
        }

        public string PicPath
        {
            get
            {
                return this._picpath;
            }
            set
            {
                this._picpath = value;
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

        public int RootId
        {
            get
            {
                return this._rootid;
            }
            set
            {
                this._rootid = value;
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

        public int TemplateId
        {
            get
            {
                return this._templateid;
            }
            set
            {
                this._templateid = value;
            }
        }
    }
}

