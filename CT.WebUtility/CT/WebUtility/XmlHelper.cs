namespace CT.WebUtility
{
    using System;
    using System.IO;
    using System.Xml;

    public class XmlHelper
    {
        public XmlDocument _doc;
        private XmlNode _node;
        private string _xmppath;

        public XmlHelper(Stream stream)
        {
            this._xmppath = string.Empty;
            this._doc = new XmlDocument();
            this._node = null;
            try
            {
                this._doc.Load(stream);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public XmlHelper(string xmlpath)
        {
            this._xmppath = string.Empty;
            this._doc = new XmlDocument();
            this._node = null;
            try
            {
                xmlpath = xmlpath.Trim();
                if (Statics.RegexPatterns.Re30.IsMatch(xmlpath))
                {
                    this._xmppath = xmlpath;
                    this._doc.Load(this._xmppath);
                }
                else
                {
                    this._doc.LoadXml(xmlpath);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(string nodepath)
        {
            this._node = this._doc.DocumentElement.SelectSingleNode(nodepath);
            if (this._node != null)
            {
                this._node.ParentNode.RemoveChild(this._node);
            }
        }

        public string GetAttr(string nodepath, string AttrName)
        {
            try
            {
                this._node = this._doc.DocumentElement.SelectSingleNode(nodepath);
                if ((this._node != null) && (this._node.Attributes[AttrName] != null))
                {
                    return this._node.Attributes[AttrName].InnerText;
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }

        public XmlNode GetNode(string nodepath)
        {
            try
            {
                return this._doc.DocumentElement.SelectSingleNode(nodepath);
            }
            catch
            {
                return null;
            }
        }

        public string GetValue(string nodepath)
        {
            try
            {
                this._node = this._doc.DocumentElement.SelectSingleNode(nodepath);
                if (this._node != null)
                {
                    return this._node.InnerText;
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }

        public string InnerXml()
        {
            return this._doc.InnerXml;
        }

        public void Insert(string nodepath, XmlElement node)
        {
            this._node = this._doc.DocumentElement.SelectSingleNode(nodepath);
            if ((this._node != null) && (node != null))
            {
                this._node.AppendChild(node);
            }
        }

        public void Insert(string nodepath, string nodename, string value)
        {
            this._node = this._doc.DocumentElement.SelectSingleNode(nodepath);
            XmlElement newChild = this._doc.CreateElement(nodename);
            newChild.InnerText = value;
            this._node.AppendChild(newChild);
        }

        public void Save()
        {
            try
            {
                if (this._xmppath.Length > 0)
                {
                    this._doc.Save(this._xmppath);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string SetAttr(string nodepath, string AttrName, string value)
        {
            try
            {
                this._node = this._doc.DocumentElement.SelectSingleNode(nodepath);
                if (this._node != null)
                {
                    ((XmlElement) this._node).SetAttribute(AttrName, value);
                    return value;
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }

        public string SetValue(string nodepath, string value)
        {
            try
            {
                this._node = this._doc.DocumentElement.SelectSingleNode(nodepath);
                if (this._node != null)
                {
                    this._node.InnerText = value;
                    return value;
                }
                return string.Empty;
            }
            catch (Exception exception)
            {
                return exception.ToString();
            }
        }
    }
}

