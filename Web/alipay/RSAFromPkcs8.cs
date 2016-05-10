using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Com.Alipay
{
    public sealed class RSAFromPkcs8
    {
        public static string sign(string content, string privateKey, string input_charset)
        {
            System.Text.Encoding code = System.Text.Encoding.GetEncoding(input_charset);
            byte[] Data = code.GetBytes(content);
            System.Security.Cryptography.RSACryptoServiceProvider rsa = RSAFromPkcs8.DecodePemPrivateKey(privateKey);
            System.Security.Cryptography.SHA1 sh = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] signData = rsa.SignData(Data, sh);
            return System.Convert.ToBase64String(signData);
        }
        public static bool verify(string content, string signedString, string publicKey, string input_charset)
        {
            System.Text.Encoding code = System.Text.Encoding.GetEncoding(input_charset);
            byte[] Data = code.GetBytes(content);
            byte[] data = System.Convert.FromBase64String(signedString);
            System.Security.Cryptography.RSAParameters paraPub = RSAFromPkcs8.ConvertFromPublicKey(publicKey);
            System.Security.Cryptography.RSACryptoServiceProvider rsaPub = new System.Security.Cryptography.RSACryptoServiceProvider();
            rsaPub.ImportParameters(paraPub);
            System.Security.Cryptography.SHA1 sh = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            return rsaPub.VerifyData(Data, sh, data);
        }
        public static string decryptData(string resData, string privateKey, string input_charset)
        {
            byte[] DataToDecrypt = System.Convert.FromBase64String(resData);
            System.Collections.Generic.List<byte> result = new System.Collections.Generic.List<byte>();
            for (int i = 0; i < DataToDecrypt.Length / 128; i++)
            {
                byte[] buf = new byte[128];
                for (int j = 0; j < 128; j++)
                {
                    buf[j] = DataToDecrypt[j + 128 * i];
                }
                result.AddRange(RSAFromPkcs8.decrypt(buf, privateKey, input_charset));
            }
            byte[] source = result.ToArray();
            char[] asciiChars = new char[System.Text.Encoding.GetEncoding(input_charset).GetCharCount(source, 0, source.Length)];
            System.Text.Encoding.GetEncoding(input_charset).GetChars(source, 0, source.Length, asciiChars, 0);
            return new string(asciiChars);
        }
        private static byte[] decrypt(byte[] data, string privateKey, string input_charset)
        {
            System.Security.Cryptography.RSACryptoServiceProvider rsa = RSAFromPkcs8.DecodePemPrivateKey(privateKey);
            System.Security.Cryptography.SHA1 sh = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            return rsa.Decrypt(data, false);
        }
        private static System.Security.Cryptography.RSACryptoServiceProvider DecodePemPrivateKey(string pemstr)
        {
            byte[] pkcs8privatekey = System.Convert.FromBase64String(pemstr);
            System.Security.Cryptography.RSACryptoServiceProvider result;
            if (pkcs8privatekey != null)
            {
                System.Security.Cryptography.RSACryptoServiceProvider rsa = RSAFromPkcs8.DecodePrivateKeyInfo(pkcs8privatekey);
                result = rsa;
            }
            else
            {
                result = null;
            }
            return result;
        }
        private static System.Security.Cryptography.RSACryptoServiceProvider DecodePrivateKeyInfo(byte[] pkcs8)
        {
            byte[] SeqOID = new byte[]
			{
				48,
				13,
				6,
				9,
				42,
				134,
				72,
				134,
				247,
				13,
				1,
				1,
				1,
				5,
				0
			};
            byte[] seq = new byte[15];
            System.IO.MemoryStream mem = new System.IO.MemoryStream(pkcs8);
            int lenstream = (int)mem.Length;
            System.IO.BinaryReader binr = new System.IO.BinaryReader(mem);
            System.Security.Cryptography.RSACryptoServiceProvider result;
            try
            {
                ushort twobytes = binr.ReadUInt16();
                if (twobytes == 33072)
                {
                    binr.ReadByte();
                }
                else
                {
                    if (twobytes != 33328)
                    {
                        result = null;
                        return result;
                    }
                    binr.ReadInt16();
                }
                byte bt = binr.ReadByte();
                if (bt != 2)
                {
                    result = null;
                }
                else
                {
                    twobytes = binr.ReadUInt16();
                    if (twobytes != 1)
                    {
                        result = null;
                    }
                    else
                    {
                        seq = binr.ReadBytes(15);
                        if (!RSAFromPkcs8.CompareBytearrays(seq, SeqOID))
                        {
                            result = null;
                        }
                        else
                        {
                            bt = binr.ReadByte();
                            if (bt != 4)
                            {
                                result = null;
                            }
                            else
                            {
                                bt = binr.ReadByte();
                                if (bt == 129)
                                {
                                    binr.ReadByte();
                                }
                                else
                                {
                                    if (bt == 130)
                                    {
                                        binr.ReadUInt16();
                                    }
                                }
                                byte[] rsaprivkey = binr.ReadBytes((int)((long)lenstream - mem.Position));
                                System.Security.Cryptography.RSACryptoServiceProvider rsacsp = RSAFromPkcs8.DecodeRSAPrivateKey(rsaprivkey);
                                result = rsacsp;
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                result = null;
            }
            finally
            {
                binr.Close();
            }
            return result;
        }
        private static bool CompareBytearrays(byte[] a, byte[] b)
        {
            bool result;
            if (a.Length != b.Length)
            {
                result = false;
            }
            else
            {
                int i = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    byte c = a[j];
                    if (c != b[i])
                    {
                        result = false;
                        return result;
                    }
                    i++;
                }
                result = true;
            }
            return result;
        }
        private static System.Security.Cryptography.RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            System.IO.MemoryStream mem = new System.IO.MemoryStream(privkey);
            System.IO.BinaryReader binr = new System.IO.BinaryReader(mem);
            System.Security.Cryptography.RSACryptoServiceProvider result;
            try
            {
                ushort twobytes = binr.ReadUInt16();
                if (twobytes == 33072)
                {
                    binr.ReadByte();
                }
                else
                {
                    if (twobytes != 33328)
                    {
                        result = null;
                        return result;
                    }
                    binr.ReadInt16();
                }
                twobytes = binr.ReadUInt16();
                if (twobytes != 258)
                {
                    result = null;
                }
                else
                {
                    byte bt = binr.ReadByte();
                    if (bt != 0)
                    {
                        result = null;
                    }
                    else
                    {
                        int elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] MODULUS = binr.ReadBytes(elems);
                        elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] E = binr.ReadBytes(elems);
                        elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] D = binr.ReadBytes(elems);
                        elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] P = binr.ReadBytes(elems);
                        elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] Q = binr.ReadBytes(elems);
                        elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] DP = binr.ReadBytes(elems);
                        elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] DQ = binr.ReadBytes(elems);
                        elems = RSAFromPkcs8.GetIntegerSize(binr);
                        byte[] IQ = binr.ReadBytes(elems);
                        System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider();
                        RSA.ImportParameters(new System.Security.Cryptography.RSAParameters
                        {
                            Modulus = MODULUS,
                            Exponent = E,
                            D = D,
                            P = P,
                            Q = Q,
                            DP = DP,
                            DQ = DQ,
                            InverseQ = IQ
                        });
                        result = RSA;
                    }
                }
            }
            catch (System.Exception)
            {
                result = null;
            }
            finally
            {
                binr.Close();
            }
            return result;
        }
        private static int GetIntegerSize(System.IO.BinaryReader binr)
        {
            byte bt = binr.ReadByte();
            int result;
            if (bt != 2)
            {
                result = 0;
            }
            else
            {
                bt = binr.ReadByte();
                int count;
                if (bt == 129)
                {
                    count = (int)binr.ReadByte();
                }
                else
                {
                    if (bt == 130)
                    {
                        byte highbyte = binr.ReadByte();
                        byte lowbyte = binr.ReadByte();
                        byte[] array = new byte[4];
                        array[0] = lowbyte;
                        array[1] = highbyte;
                        byte[] modint = array;
                        count = System.BitConverter.ToInt32(modint, 0);
                    }
                    else
                    {
                        count = (int)bt;
                    }
                }
                while (binr.ReadByte() == 0)
                {
                    count--;
                }
                binr.BaseStream.Seek(-1L, System.IO.SeekOrigin.Current);
                result = count;
            }
            return result;
        }
        private static System.Security.Cryptography.RSAParameters ConvertFromPublicKey(string pemFileConent)
        {
            byte[] keyData = System.Convert.FromBase64String(pemFileConent);
            if (keyData.Length < 162)
            {
                throw new System.ArgumentException("pem file content is incorrect.");
            }
            byte[] pemModulus = new byte[128];
            byte[] pemPublicExponent = new byte[3];
            System.Array.Copy(keyData, 29, pemModulus, 0, 128);
            System.Array.Copy(keyData, 159, pemPublicExponent, 0, 3);
            return new System.Security.Cryptography.RSAParameters
            {
                Modulus = pemModulus,
                Exponent = pemPublicExponent
            };
        }
        private static System.Security.Cryptography.RSAParameters ConvertFromPrivateKey(string pemFileConent)
        {
            byte[] keyData = System.Convert.FromBase64String(pemFileConent);
            if (keyData.Length < 609)
            {
                throw new System.ArgumentException("pem file content is incorrect.");
            }
            int index = 11;
            byte[] pemModulus = new byte[128];
            System.Array.Copy(keyData, index, pemModulus, 0, 128);
            index += 128;
            index += 2;
            byte[] pemPublicExponent = new byte[3];
            System.Array.Copy(keyData, index, pemPublicExponent, 0, 3);
            index += 3;
            index += 4;
            byte[] pemPrivateExponent = new byte[128];
            System.Array.Copy(keyData, index, pemPrivateExponent, 0, 128);
            index += 128;
            index += ((keyData[index + 1] == 64) ? 2 : 3);
            byte[] pemPrime = new byte[64];
            System.Array.Copy(keyData, index, pemPrime, 0, 64);
            index += 64;
            index += ((keyData[index + 1] == 64) ? 2 : 3);
            byte[] pemPrime2 = new byte[64];
            System.Array.Copy(keyData, index, pemPrime2, 0, 64);
            index += 64;
            index += ((keyData[index + 1] == 64) ? 2 : 3);
            byte[] pemExponent = new byte[64];
            System.Array.Copy(keyData, index, pemExponent, 0, 64);
            index += 64;
            index += ((keyData[index + 1] == 64) ? 2 : 3);
            byte[] pemExponent2 = new byte[64];
            System.Array.Copy(keyData, index, pemExponent2, 0, 64);
            index += 64;
            index += ((keyData[index + 1] == 64) ? 2 : 3);
            byte[] pemCoefficient = new byte[64];
            System.Array.Copy(keyData, index, pemCoefficient, 0, 64);
            return new System.Security.Cryptography.RSAParameters
            {
                Modulus = pemModulus,
                Exponent = pemPublicExponent,
                D = pemPrivateExponent,
                P = pemPrime,
                Q = pemPrime2,
                DP = pemExponent,
                DQ = pemExponent2,
                InverseQ = pemCoefficient
            };
        }
    }
}
