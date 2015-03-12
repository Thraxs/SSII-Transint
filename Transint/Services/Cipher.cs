using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transint
{
    public enum HMACAlgorithm { MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 };

    static class Cipher
    {
        //Compute the HMAC of the given message
        public static byte[] computeHMAC(byte[] key, string message, HMACAlgorithm algorithm)
        {
            byte[] messageData = Encoding.UTF8.GetBytes(message);

            //Create cipher depending on chosen algorithm
            HMAC cipher;
            switch (algorithm)
            {
                case HMACAlgorithm.MD5:
                    cipher = new HMACMD5(key);
                    break;
                case HMACAlgorithm.RIPEMD160:
                    cipher = new HMACRIPEMD160(key);
                    break;
                case HMACAlgorithm.SHA1:
                    cipher = new HMACSHA1(key);
                    break;
                case HMACAlgorithm.SHA256:
                    cipher = new HMACSHA256(key);
                    break;
                case HMACAlgorithm.SHA384:
                    cipher = new HMACSHA384(key);
                    break;
                case HMACAlgorithm.SHA512:
                    cipher = new HMACSHA512(key);
                    break;                
                default:
                    cipher = new HMACMD5(key);
                    break;
            }

            //Compute the hash using the cipher and the message bytes
            byte[] messageHash = cipher.ComputeHash(messageData);

            return messageHash;
        }

        //Verify the HMAC of the given message
        public static bool verifyHMAC(byte[] key, string message, byte[] HMAC, HMACAlgorithm algorithm)
        {
            bool result = false;

            byte[] messageHash = computeHMAC(key, message, algorithm);

            //Compare the received hash with the computed hash
            result = HMAC.SequenceEqual(messageHash);

            return result;
        }

        //Generate a random 64-bit key of the given algorithm type
        public static byte[] generateKey(HMACAlgorithm algorithm)
        {
            byte[] key;
            HMAC cipher;

            switch (algorithm)
            {
                case HMACAlgorithm.MD5:
                    cipher = new HMACMD5();
                    break;
                case HMACAlgorithm.RIPEMD160:
                    cipher = new HMACRIPEMD160();
                    break;
                case HMACAlgorithm.SHA1:
                    cipher = new HMACSHA1();
                    break;
                case HMACAlgorithm.SHA256:
                    cipher = new HMACSHA256();
                    break;
                case HMACAlgorithm.SHA384:
                    cipher = new HMACSHA384();
                    break;
                case HMACAlgorithm.SHA512:
                    cipher = new HMACSHA512();
                    break;
                default:
                    cipher = new HMACMD5();
                    break;
            }

            key = cipher.Key;

            return key;
        }

        //Erase the values of the given array
        public static void eraseKey(byte[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }

        //Convert byte array to hex string
        public static string byteToString(byte[] input)
        {
            StringBuilder stringbuilder = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                stringbuilder.Append(input[i].ToString("x2"));
            }
            return stringbuilder.ToString();
        }

        //Convert hex string to byte
        public static byte[] stringToByte(string input)
        {
            byte[] result = new byte[input.Length / 2];

            for (int i = 0; i < input.Length; i += 2)
            {
                result[i / 2] = Convert.ToByte(input.Substring(i, 2), 16);
            }

            return result;
        }
    }
}
