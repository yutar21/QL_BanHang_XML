using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using QL_BanHang_XML.model;
using System.Xml.Linq;

namespace QL_BanHang_XML.Data
{
    class DataUtil_HoaDon
    {
        XmlDocument doc;
        XmlElement root;
        string filename;


        public DataUtil_HoaDon()
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
        public void AddHoaDon( hoadon h)
        {
            XmlElement hd = doc.CreateElement("hoadon ");
            hd.SetAttribute("id", h.txtid);
            XmlElement tenhanghoa = doc.CreateElement("ten");
            tenhanghoa.InnerText = h.ten;
            XmlElement dongia = doc.CreateElement("dongia");
            dongia.InnerText = h.dongia;
            XmlElement soluong = doc.CreateElement("soluong");
            soluong.InnerText = h.txtsoluong;
            XmlElement giamgia = doc.CreateElement("giamgia");
            giamgia.InnerText = h.giamgia;
            XmlElement ngayban = doc.CreateElement("ngayban");
            ngayban.InnerText = h.ngayban;
            XmlElement thanhtien = doc.CreateElement("thanhtien");
            thanhtien.InnerText = h.thanhtien;
            hd.AppendChild(tenhanghoa);
            hd.AppendChild(dongia);
            hd.AppendChild(soluong);
            hd.AppendChild(giamgia);
            hd.AppendChild(ngayban);
            hd.AppendChild(thanhtien);
            root.AppendChild(hd);
            doc.Save(filename);

        }
    }
}
       