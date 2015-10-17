using AWEARNESS.Models.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWEARNESS.Models.Repository
{
    public class QRCode
    {
        public QRCode()
        {
            Pin = UniqueKeyGenerator.Instance.GetPinCode(7);
        }
        [Key]
        public string Pin { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public string ProductType { get; set; }
    }

    public class QrCodeMng
    {
        private static QrCodeMng m_Instance;
        private Dictionary<string, QRCode> m_QRCodes = new Dictionary<string, QRCode>();
        private AwearnessDB m_DB = new AwearnessDB();

        private QrCodeMng()
        {

            var QRCodesList = m_DB.QRCodes.ToList();

            foreach (var QRCode in QRCodesList)
            {
                this.m_QRCodes.Add(QRCode.Pin, QRCode);
            }
        }

        public static QrCodeMng Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new QrCodeMng();
                }
                return m_Instance;
            }
        }

        public List<QRCode> AllQRCodes
        {
            get
            {
                return m_QRCodes.Values.ToList();
            }
        }

        public QRCode GetQRCode(string i_PinCode)
        {
            if (m_QRCodes.ContainsKey(i_PinCode))
            {
                return m_QRCodes[i_PinCode];
            }
            return null;
        }

        public void CreateQRCode(QRCode i_QRCode)
        {
            if (!m_QRCodes.ContainsKey(i_QRCode.Pin))
            {
                m_QRCodes.Add(i_QRCode.Pin, i_QRCode);
                m_DB.QRCodes.Add(i_QRCode);
                m_DB.SaveChanges();
            }
        }

        public void UpdateQRCode(QRCode i_QRCode)
        {
            QRCode QRCodeFromDB = QrCodeMng.Instance.GetQRCodeFromDB(i_QRCode.Pin);
            QRCodeFromDB.IsActive = i_QRCode.IsActive;
            QRCodeFromDB.Password = i_QRCode.Password;
            QRCodeFromDB.ProductType = i_QRCode.ProductType;
            QRCodeFromDB.Password = i_QRCode.Password;
            m_DB.Entry(QRCodeFromDB).State = EntityState.Modified;
            m_DB.SaveChanges();
        }

        public void DeleteQRCode(string i_PinCode)
        {
            QRCode QRCode = m_DB.QRCodes.Find(i_PinCode);
            m_QRCodes.Remove(i_PinCode);
            m_DB.QRCodes.Remove(QRCode);
            m_DB.SaveChanges();
        }

        public QRCode GetQRCodeFromDB(string i_PinCode)
        {
            QRCode QRCode = m_DB.QRCodes.Find(i_PinCode);
            return QRCode;
        }

        public bool IsPasswordOk(string i_Id, string i_Password)
        {
            bool result = false;
            QRCode qrCode = m_DB.QRCodes.Find(i_Id);
            if (qrCode != null && qrCode.Password.Equals(i_Password))
            {
                result = true;
            }

            return result;
        }



    }


}