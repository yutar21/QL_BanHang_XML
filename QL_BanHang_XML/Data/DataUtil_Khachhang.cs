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
    class DataUtil_Khachhang
    {
        XmlDocument doc;
        XmlElement root;
        string filename;
        public DataUtil_Khachhang()
        {
            filename = "QL_Khachhang.xml";
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
        public void AddMember(khachhang kh)
        {
            XmlElement mb = doc.CreateElement("member");
            mb.SetAttribute("id", kh.txtIdkh);
            XmlElement name = doc.CreateElement("Name");
            name.InnerText = kh.txtNamekh;
            XmlElement gioitinh = doc.CreateElement("Gioitinh");
            gioitinh.InnerText = kh.txtGioitinh;
            XmlElement email = doc.CreateElement("Email");
            email.InnerText = kh.txtEmailkh;
            XmlElement phone = doc.CreateElement("Phone");
            phone.InnerText = kh.txtPhonekh;
            XmlElement diachi = doc.CreateElement("Diachi");
            diachi.InnerText = kh.txtDiachikh;
            mb.AppendChild(name);
            mb.AppendChild(gioitinh);
            mb.AppendChild(email);
            mb.AppendChild(phone);
            mb.AppendChild(diachi);
            root.AppendChild(mb);
            doc.Save(filename);

        }
        public List<khachhang> GetAllMember()
        {
            XmlNodeList nodes = root.SelectNodes("member");
            List<khachhang> likh = new List<khachhang>();
            foreach (XmlNode node in nodes)
            {
                khachhang kh = new khachhang();
                kh.txtIdkh = node.Attributes[0].InnerText;
                kh.txtNamekh = node.SelectSingleNode("Name").InnerText;
                kh.txtGioitinh = node.SelectSingleNode("Gioitinh").InnerText;
                kh.txtEmailkh = node.SelectSingleNode("Email").InnerText;
                kh.txtPhonekh = node.SelectSingleNode("Phone").InnerText;
                kh.txtDiachikh = node.SelectSingleNode("Diachi").InnerText;
                likh.Add(kh);
            }
            return likh;

        }
        public bool UpdateMember(khachhang kh)
        {
            XmlNode stfind = root.SelectSingleNode("member[@id='" + kh.txtIdkh + "']");
            if (stfind != null)
            {
                XmlElement pd = doc.CreateElement("member");
                pd.SetAttribute("id", kh.txtIdkh);
                XmlElement name = doc.CreateElement("Name");
                name.InnerText = kh.txtNamekh;
                XmlElement gioitinh = doc.CreateElement("Gioitinh");
                gioitinh.InnerText = kh.txtGioitinh;
                XmlElement email = doc.CreateElement("Email");
                email.InnerText = kh.txtEmailkh;
                XmlElement phone = doc.CreateElement("Phone");
                phone.InnerText = kh.txtPhonekh;
                XmlElement diachi = doc.CreateElement("Diachi");
                diachi.InnerText = kh.txtDiachikh;
                pd.AppendChild(name);
                pd.AppendChild(gioitinh);
                pd.AppendChild(email);
                pd.AppendChild(phone);
                pd.AppendChild(diachi);
                root.ReplaceChild(pd, stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public bool DeleteMember(string txtIdkh)
        {
            XmlNode stfind = root.SelectSingleNode("member[@id='" + txtIdkh + "']");
            if (stfind != null)
            {
                root.RemoveChild(stfind);
                doc.Save(filename);
                return true;
            }
            return false;
        }
        public khachhang FindID(string txtIdkh)
        {
            XmlNode stfind = root.SelectSingleNode("member[@id='" + txtIdkh + "']");
            khachhang kh = null;
            if (stfind != null)
            {
                kh = new khachhang();
                kh.txtIdkh = stfind.Attributes[0].InnerText;
                kh.txtNamekh = stfind.SelectSingleNode("Name").InnerText;
                kh.txtGioitinh = stfind.SelectSingleNode("Gioitinh").InnerText;
                kh.txtEmailkh = stfind.SelectSingleNode("Email").InnerText;
                kh.txtPhonekh = stfind.SelectSingleNode("Phone").InnerText;
                kh.txtDiachikh = stfind.SelectSingleNode("Diachi").InnerText;

            }
            return kh;
        }
    }
}
