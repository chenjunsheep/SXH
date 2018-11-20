using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Sxh.Shared.Settings
{
    public class VersionUpdater
    {
        public ServerSettings ServerConfig { get; set; }

        public class ServerSettings
        {
            #region Property
            public string TargetServer { get; set; }

            private List<ServerSettingItem> _items;
            public List<ServerSettingItem> Items
            {
                get { return _items ?? (_items = new List<ServerSettingItem>()); }
                set { _items = value; }
            }

            #endregion

            #region Public Method

            public void LoadXml(string xmlString)
            {
                Items.Clear();

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);

                var nodeWrapper = xmlDoc.SelectSingleNode(Namespaces.XmlNode.MainWrapper);
                if (nodeWrapper != null)
                {
                    TargetServer = nodeWrapper.SelectSingleNode(Namespaces.XmlNode.TargetServer).InnerText;

                    foreach (XmlElement childNode in nodeWrapper.SelectNodes(Namespaces.XmlNode.ItemWrapper))
                    {
                        var item = new ServerSettingItem();
                        item.LoadXml(childNode);
                        Items.Add(item);
                    }
                }
            }

            public void SaveToXml(string pathRoot)
            {
                try
                {
                    var pathFolder = Path.Combine(pathRoot, Namespaces.Config.PhysicalFolder);
                    if (!Directory.Exists(pathFolder))
                        Directory.CreateDirectory(pathFolder);

                    var doc = new XmlDocument();
                    var nodeDoc = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    doc.AppendChild(nodeDoc);

                    var nodeParent = doc.CreateElement(Namespaces.XmlNode.MainWrapper);
                    doc.AppendChild(nodeParent);

                    var nodeServer = doc.CreateElement(Namespaces.XmlNode.TargetServer);
                    nodeServer.InnerText = TargetServer;
                    nodeParent.AppendChild(nodeServer);

                    foreach (var item in Items)
                    {
                        var nodeItem = doc.CreateElement(Namespaces.XmlNode.ItemWrapper);
                        nodeParent.AppendChild(nodeItem);

                        var props = item.GetType().GetProperties();
                        foreach (var prop in props)
                        {
                            var nodeChild = doc.CreateElement(prop.Name);
                            nodeItem.AppendChild(nodeChild);
                            nodeChild.InnerText = prop.GetValue(item, null).ToString();
                        }
                    }

                    var pathFull = Path.Combine(pathFolder, Namespaces.Config.PhysicalFile);
                    if (File.Exists(pathFull))
                        File.Delete(pathFull);
                    doc.Save(pathFull);
                }
                catch { }
            }

            //public static string GetServerPath()
            //{
            //    return Path.Combine(Namespaces.Config.PhysicalFolder, Namespaces.Config.PhysicalFile);
            //}

            #endregion

            #region Private Method

            #endregion

            #region Class

            public class Namespaces
            {
                public class Config
                {
                    public const string PhysicalFolder = "StaticFiles";
                    public const string VirtrualFolder = "files";
                    public const string PhysicalFile = "Server.xml";
                }

                public class XmlNode
                {
                    public const string MainWrapper = "ServerConfig";
                    public const string ItemWrapper = "Item";
                    public const string TargetServer = "TargetServer";
                }
            }

            #endregion
        }

        public class ServerSettingItem
        {
            #region Property

            public string ApplicationStart { get; set; }
            public string ReleaseVersion { get; set; }
            public string ReleaseFileServer
            {
                get { return $"{ReleaseVersion}.txt"; }
            }
            public string ReleaseFileClient
            {
                get { return $"{ReleaseVersion}.zip"; }
            }

            #endregion

            #region Public Method

            public void LoadXml(XmlElement element)
            {
                if (element != null)
                {
                    foreach (XmlElement childNode in element.ChildNodes)
                    {
                        var prop = GetType().GetProperty(childNode.Name);
                        if (prop.CanWrite)
                            prop.SetValue(this, childNode.InnerText, null);
                    }
                }
            }

            #endregion
        }

        public class ClientSettings
        {
            #region Property

            public string LocalVersion { get; set; }

            #endregion

            #region Public Method

            public void LoadXml(string pathRoot)
            {
                var fullPath = Path.Combine(pathRoot, Namespaces.Config.PhysicalFile);
                if (File.Exists(fullPath))
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(fullPath);

                    var selectSingleNode = xmlDoc.SelectSingleNode(Namespaces.XmlNode.MainWrapper);
                    if (selectSingleNode != null)
                    {
                        foreach (XmlElement childNode in selectSingleNode.ChildNodes)
                        {
                            GetType().GetProperty(childNode.Name).SetValue(this, childNode.InnerText, null);
                        }
                    }
                }
            }

            public void SaveToXml(string pathRoot)
            {
                RemoveFile(pathRoot);

                var doc = new XmlDocument();
                var nodeDoc = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(nodeDoc);

                var nodeParent = doc.CreateElement(Namespaces.XmlNode.MainWrapper);
                doc.AppendChild(nodeParent);

                foreach (var prop in this.GetType().GetProperties())
                {
                    var nodeItem = doc.CreateElement(prop.Name);
                    nodeParent.AppendChild(nodeItem);
                    nodeItem.InnerText = prop.GetValue(this, null).ToString();
                }
                
                var pathFull = Path.Combine(pathRoot, Namespaces.Config.PhysicalFile);
                doc.Save(pathFull);
            }

            #endregion

            #region Private Method

            public void RemoveFile(string pathRoot)
            {
                try
                {
                    var fullPath = Path.Combine(pathRoot, Namespaces.Config.PhysicalFile);
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }

            #endregion

            #region Class

            public class Namespaces
            {
                public class Config
                {
                    public const string PhysicalFile = "Local.xml";
                }

                public class XmlNode
                {
                    public const string MainWrapper = "LocalConfig";
                    //public const string LocalVersion = "LocalVersion";
                    //public const string LastUpdate = "LastUpdate";
                    //public const string ServerUpdateUrl = "ServerUpdateUrl";
                }
            }

            #endregion
        }
    }
}
