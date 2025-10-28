using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ManageSieveKM
{
    public static class Utils
    {
        public static string GetEncryptionKey()
        {
            string cpuInfo = string.Empty, volumeSerial = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            try
            {
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            catch
            {

            }
            string drive = "C";
            ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            try
            {
                dsk.Get();
                volumeSerial = dsk["VolumeSerialNumber"].ToString();
            }
            catch
            {

            }
            return cpuInfo + volumeSerial;
        }

        public static string Encrypt(string clearText, string key)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                byte[] IV = new byte[15];
                Random rand = new Random();
                rand.NextBytes(IV);
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, IV);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(IV) + Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText, string key)
        {
            byte[] IV = Convert.FromBase64String(cipherText.Substring(0, 20));
            cipherText = cipherText.Substring(20).Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, IV);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    try
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        cipherText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                    catch (Exception ex)
                    {
                        Utils.LogToFile(ex.Message);
                        if (ex.InnerException != null)
                        {
                            Utils.LogToFile(ex.InnerException.Message);
                        }
                    }
                }
            }
            return cipherText;
        }

        public static string DateTime2ISO(DateTime dt)
        {
            return dt.Year.ToString() + "-" + dt.Month.ToString().PadLeft(2, '0') + "-" + dt.Day.ToString().PadLeft(2, '0') + " " + dt.Hour.ToString().PadLeft(2, '0') + ":" + dt.Minute.ToString().PadLeft(2, '0');
        }

        public static void LogToFile(string msg)
        {
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "debug.txt", Utils.DateTime2ISO(DateTime.Now) + " " + msg + Environment.NewLine);
        }
    }
}
