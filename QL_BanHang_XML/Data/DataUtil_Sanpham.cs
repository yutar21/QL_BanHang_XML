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
                XmlElement course = doc.CreateElement("course");
                doc.AppendChild(course);
                doc.Save(filename);
            }
            doc.Load(filename);
            root = doc.DocumentElement;
        }
        public void Addproduct(sanpham s)
        {
            XmlElement pd = doc.CreateElement("product");
            pd.SetAttribute("",s.id);
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

    }
}
