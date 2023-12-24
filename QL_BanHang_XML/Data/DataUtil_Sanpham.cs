using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using QL_BanHang_XML.model;

namespace QL_BanHang_XML.Data
{
    class DataUtil_Sanpham
    {
        XmlDocument doc;
        XmlElement root;
        string filename;


        public DataUtil_Sanpham()
        {
            filename = "QL_Sanpham.xml";
            doc = new XmlDocument();
            if (!File.Exists(filename))
            {
                XmlElement course = doc.CreateElement("data");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public void Addproduct(sanpham s)
        {
            XmlElement pd = doc.CreateElement("product");
            pd.SetAttribute("id",s.id);
            XmlElement name = doc.CreateElement("name");
            name.InnerText = s.name;
            XmlElement gia = doc.CreateElement("gia");
            gia.InnerText = s.gia;
            XmlElement soluong = doc.CreateElement("soluong");
            soluong.InnerText = s.soluong;
            XmlElement mota = doc.CreateElement("mota");
            mota.InnerText = s.mota;
            XmlElement ngaysanxuat = doc.CreateElement("ngaysanxuat");
            ngaysanxuat.InnerText = s.ngaysanxuat;
            XmlElement hansudung = doc.CreateElement("hansudung");
            hansudung.InnerText = s.hansudung;
            pd.AppendChild(name);
            pd.AppendChild(gia);
            pd.AppendChild(soluong);
            pd.AppendChild(mota);
            pd.AppendChild(ngaysanxuat);
            pd.AppendChild(hansudung);
            root.AppendChild(pd);
            doc.Save(filename);

        }
        public List<sanpham> GetAllProducts()
        {
            XmlNodeList nodes = root.SelectNodes("product");
            List<sanpham> li = new List<sanpham>();
            foreach (XmlNode node in nodes)
            {
                sanpham sp = new sanpham();
                sp.id = node.Attributes[0].InnerText;
                sp.name = node.SelectSingleNode("name").InnerText;
                sp.gia = node.SelectSingleNode("gia").InnerText;
                sp.soluong = node.SelectSingleNode("soluong").InnerText;
                sp.mota = node.SelectSingleNode("mota").InnerText;
                sp.ngaysanxuat = node.SelectSingleNode("ngaysanxuat").InnerText;
                sp.hansudung = node.SelectSingleNode("hansudung").InnerText;
                li.Add(sp);
            }
            return li;

        }
        public bool UpdateProduct(sanpham s)
        {
            XmlNode stfind = root.SelectSingleNode("product[@id='" + s.id + "']");
            if (stfind != null) 
            {
                XmlElement pd = doc.CreateElement("product");
                pd.SetAttribute("id", s.id);
                XmlElement name = doc.CreateElement("name");
                name.InnerText = s.name;
                XmlElement gia = doc.CreateElement("gia");
                gia.InnerText = s.gia;
                XmlElement soluong = doc.CreateElement("soluong");
                soluong.InnerText = s.soluong;
                XmlElement mota = doc.CreateElement("mota");
                mota.InnerText = s.mota;
                XmlElement ngaysanxuat = doc.CreateElement("ngaysanxuat");
                ngaysanxuat.InnerText = s.ngaysanxuat;
                XmlElement hansudung = doc.CreateElement("hansudung");
                hansudung.InnerText = s.hansudung;
                pd.AppendChild(name);
                pd.AppendChild(gia);
                pd.AppendChild(soluong);
                pd.AppendChild(mota);
                pd.AppendChild(ngaysanxuat);
                pd.AppendChild(hansudung);
                root.ReplaceChild(pd,stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }

    }
}
