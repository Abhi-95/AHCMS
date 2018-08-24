using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AHCMS.Models
{
    public class ViewModal
    {        
        
        
    }

    public enum SignInStatus // Summary: Possible results from a sign in attempt
    {
        Success = 0, // Summary: Sign in was successful           
        SessionOut = 1,  // Summary: User is locked out           
        RequiresVerification = 2,  // Summary: Sign in requires addition verification (i.e. email)            
        Failure = 3 // Summary: Sign in failed
    }

    public enum UserRole 
    {
        Patient = 0,         
        Employee = 1  
    }
    public class Security
    {
        public string Encrypt(string InputText)
        {
            string KeyString = "MAKV2SPBNI92215";
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 256;
                    byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
                    PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(KeyString, Encoding.ASCII.GetBytes(KeyString.Length.ToString()));
                    using (ICryptoTransform Encryptor = AES.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(32)))
                    {
                        using (memoryStream = new MemoryStream())
                        {
                            using (cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(PlainText, 0, PlainText.Length);
                                cryptoStream.FlushFinalBlock();
                                return Convert.ToBase64String(memoryStream.ToArray());
                            }
                        }
                    }
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Close();
                if (cryptoStream != null)
                    cryptoStream.Close();
            }
        }

        public string Decrypt(string InputText)
        {
            string KeyString = "MAKV2SPBNI92215";
            MemoryStream memoryStream = null;
            CryptoStream cryptoStream = null;
            try
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 256;
                    byte[] EncryptedData = Convert.FromBase64String(InputText);
                    PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(KeyString, Encoding.ASCII.GetBytes(KeyString.Length.ToString()));
                    using (ICryptoTransform Decryptor = AES.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(32)))
                    {
                        using (memoryStream = new MemoryStream(EncryptedData))
                        {
                            using (cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read))
                            {
                                byte[] PlainText = new byte[EncryptedData.Length];
                                return Encoding.Unicode.GetString(PlainText, 0, cryptoStream.Read(PlainText, 0, PlainText.Length));
                            }
                        }
                    }
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                if (memoryStream != null)
                    memoryStream.Close();
                if (cryptoStream != null)
                    cryptoStream.Close();
            }
        }

    }
}

 