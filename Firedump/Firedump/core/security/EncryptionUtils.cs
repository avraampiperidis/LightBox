using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.core.security
{
    class EncryptionUtils
    {
        private readonly static string sKey = "Intd37JXLILmhNidYzG+YiX68ZDdacji5amwFHA9xHM=";
        private readonly static string sIV = "75UjJnbyruCQSl5SJVix/w==";
        private readonly static int sKeysize = 256;
        private readonly static int sBlockSize = 128;


        public static void generateKeys(int size)
        {
            AesCryptoServiceProvider dataencrypt = new AesCryptoServiceProvider();
            dataencrypt.KeySize = size;
            dataencrypt.GenerateKey();
            dataencrypt.GenerateIV();
            Console.WriteLine(Convert.ToBase64String(dataencrypt.Key));
            Console.WriteLine(Convert.ToBase64String(dataencrypt.IV));
        }

        /// <summary>
        /// Encrypt using the hardcoded static key in the class
        /// </summary>
        /// <param name="data">data to encrypt in plaintext</param>
        /// <returns></returns>
        public static string sEncrypt(string data)
        {
            return encrypt(data, sKey, sIV);
        }

        /// <summary>
        /// Encrypt using new keys
        /// </summary>
        /// <param name="data">data to encrypt in plaintext</param>
        /// <param name="key">base64 encoded key</param>
        /// <param name="iv">base64 encoded iv</param>
        /// <returns>the ciphertext in base64 string encoding</returns>
        public static string encrypt(string data, string key, string iv)
        {
            string res = "";
            try
            {
                res = Convert.ToBase64String(encryptdata(Encoding.UTF8.GetBytes(data), key, iv));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        /// <summary>
        /// Decrypt using the hardcoded static key in the class
        /// </summary>
        /// <param name="ciphertext">The encrypted text as a base64 encoded string</param>
        /// <returns>the original plaintext</returns>
        public static string sDecrypt(string ciphertext)
        {
            return decrypt(ciphertext, sKey, sIV);
        }

        /// <summary>
        /// Decrypt using new keys
        /// </summary>
        /// <param name="ciphertext">The encrypted text as a base64 encoded string</param>
        /// <param name="key">base64 encoded key</param>
        /// <param name="iv">base64 encoded iv</param>
        /// <returns></returns>
        public static string decrypt(string ciphertext, string key, string iv)
        {
            string res = "";
            try
            {
                res = Encoding.UTF8.GetString(decryptdata(Convert.FromBase64String(ciphertext), key, iv));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytearraytoencrypt"></param>
        /// <param name="key">base64 encoded string</param>
        /// <param name="iv">base64 encoded string</param>
        /// <returns></returns>
        private static byte[] encryptdata(byte[] bytearraytoencrypt, string key, string iv)
        {
            AesCryptoServiceProvider dataencrypt = new AesCryptoServiceProvider();
            //Block size : Gets or sets the block size, in bits, of the cryptographic operation.  
            dataencrypt.BlockSize = sBlockSize;
            //KeySize: Gets or sets the size, in bits, of the secret key  
            dataencrypt.KeySize = sKeysize;
            //Key: Gets or sets the symmetric key that is used for encryption and decryption.  
            dataencrypt.Key = Convert.FromBase64String(key);
            //IV : Gets or sets the initialization vector (IV) for the symmetric algorithm  
            dataencrypt.IV = Convert.FromBase64String(iv);
            //Padding: Gets or sets the padding mode used in the symmetric algorithm  
            dataencrypt.Padding = PaddingMode.PKCS7;
            //Mode: Gets or sets the mode for operation of the symmetric algorithm  
            dataencrypt.Mode = CipherMode.CBC;
            //Creates a symmetric AES encryptor object using the current key and initialization vector (IV).  
            ICryptoTransform crypto1 = dataencrypt.CreateEncryptor(dataencrypt.Key, dataencrypt.IV);
            //TransformFinalBlock is a special function for transforming the last block or a partial block in the stream.   
            //It returns a new array that contains the remaining transformed bytes. A new array is returned, because the amount of   
            //information returned at the end might be larger than a single block when padding is added.  
            byte[] encrypteddata = crypto1.TransformFinalBlock(bytearraytoencrypt, 0, bytearraytoencrypt.Length);
            crypto1.Dispose();
            //return the encrypted data  
            return encrypteddata;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytearraytodecrypt"></param>
        /// <param name="key">base64 encoded string</param>
        /// <param name="iv">base64 encoded string</param>
        /// <returns></returns>
        private static byte[] decryptdata(byte[] bytearraytodecrypt, string key, string iv)
        {

            AesCryptoServiceProvider keydecrypt = new AesCryptoServiceProvider();
            keydecrypt.BlockSize = sBlockSize;
            keydecrypt.KeySize = sKeysize;
            keydecrypt.Key = Convert.FromBase64String(key);
            keydecrypt.IV = Convert.FromBase64String(iv);
            keydecrypt.Padding = PaddingMode.PKCS7;
            keydecrypt.Mode = CipherMode.CBC;
            ICryptoTransform crypto1 = keydecrypt.CreateDecryptor(keydecrypt.Key, keydecrypt.IV);

            byte[] returnbytearray = crypto1.TransformFinalBlock(bytearraytodecrypt, 0, bytearraytodecrypt.Length);
            crypto1.Dispose();
            return returnbytearray;
        }

        public static string hashSHA256(string data)
        {
            string res = "";
            SHA256CryptoServiceProvider hasher = new SHA256CryptoServiceProvider();
            byte[] hashedBytes = hasher.ComputeHash(Encoding.UTF8.GetBytes(data));
            res = Convert.ToBase64String(hashedBytes);
            return res;
        }

        public static void testAES()
        {
            string data = "vaggelis 1223 dasdiasdgasd cyka blyat oeo";
            /*
            String ciphertext = sEncrypt(data);
            Console.WriteLine(ciphertext);
            Console.WriteLine(sDecrypt(ciphertext));
            //an to apotelesma tou decrypt einai idio me to data pernaei to test*/
            Console.WriteLine(hashSHA256(data));
        }
    }
}
