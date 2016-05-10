using System;
namespace model
{
    public class type_oneModel
    {
        private int id;
        private string type_one_name;
        private int xid;
        private int px;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Type_one_name
        {
            get
            {
                return this.type_one_name;
            }
            set
            {
                this.type_one_name = value;
            }
        }
        public int Xid
        {
            get
            {
                return this.xid;
            }
            set
            {
                this.xid = value;
            }
        }
        public int Px
        {
            get
            {
                return this.px;
            }
            set
            {
                this.px = value;
            }
        }
    }
}
