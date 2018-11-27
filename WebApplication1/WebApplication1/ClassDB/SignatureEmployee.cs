using DidiSoft.Pgp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SignatureEmployee
    {
        public String encrypet(string InputText, string path, string password)
        {
            String plainString = InputText;

            // create an instance of the library
            PGPLib pgp = new PGPLib();

            String signedString = "";
            try
            {
                signedString = pgp.SignString(plainString,
                                                     new FileInfo(path),
                                                    password);
            }
            catch
            {
                return "false";
            }
            return signedString;
        }

        public Boolean Decreypt(string encrypt, int ID)
        {
            //Get Public File
            GetKey objKey = new GetKey();
            DataRow drKey = objKey.drSearchEmployeeKey(ID);
            string PublicKey1 = drKey[0].ToString();

            // obtain an OpenPGP signed message
            String signedString = encrypt;

            // Extract the message and check the validity of the signature
            String plainText;

            // create an instance of the library
            PGPLib pgp = new PGPLib();
            SignatureCheckResult signatureCheck;
            try
            {
                signatureCheck = pgp.VerifyString(signedString,
                                                 new FileInfo(PublicKey1), out plainText);
            }
            catch
            {
                return false;
            }



            string strData1 = plainText;
            // Print the results
            Console.WriteLine("Extracted plain text message is " + plainText);
            if (signatureCheck == SignatureCheckResult.SignatureVerified)
            {
                // Console.WriteLine("Signature OK");
                return true;
            }
            else if (signatureCheck == SignatureCheckResult.SignatureBroken)
            {
                //Console.WriteLine("Signature of the message is either broken or forged");
                return false;
            }
            else if (signatureCheck == SignatureCheckResult.PublicKeyNotMatching)
            {
                //   Console.WriteLine("The provided public key doesn't match the signature");
                return false;
            }
            else if (signatureCheck == SignatureCheckResult.NoSignatureFound)
            {
                //  Console.WriteLine("This message is not digitally signed");
                return false;
            }
            return false;
        }

        public void CreateSignature(string privateKeyPassword, string userId, int ID)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("../PageEmployee/Sig") + "/" + "key.store";
            KeyStore ks = new KeyStore(@path, "changeit");

            // userId = "rsa_demo@didisoft.com";
            // privateKeyPassword = "private key password";

            HashAlgorithm[] hashing = { HashAlgorithm.SHA1,
                                        HashAlgorithm.MD5,
                                        HashAlgorithm.SHA256,
                                        HashAlgorithm.SHA384,
                                        HashAlgorithm.SHA512};

            CompressionAlgorithm[] compression =
                                    { CompressionAlgorithm.ZIP,
                                      CompressionAlgorithm.ZLIB,
                                      CompressionAlgorithm.UNCOMPRESSED};

            CypherAlgorithm[] cypher = { CypherAlgorithm.CAST5,
                                         CypherAlgorithm.AES_128,
                                         CypherAlgorithm.AES_192,
                                         CypherAlgorithm.AES_256,
                                         CypherAlgorithm.BLOWFISH};

            ks.GenerateKeyPair(2048,
                                userId,
                                KeyAlgorithm.RSA,
                                privateKeyPassword,
                                compression,
                                hashing,
                                cypher);
            ExportDemo(path, userId, ID);
        }
        public void ExportDemo(string path, string userId, int ID)
        {


            // initialize the KeyStore
            KeyStore ks = new KeyStore(@path, "changeit");

            // should the exported files be ASCII or binary
            bool asciiArmored = true;

            // export public key having the specified userId
            // all public sub keys are exported too

            string pathPub = System.Web.HttpContext.Current.Server.MapPath("../PageEmployee/Sig") + "/" + ID + ".asc";
            string pathPri = System.Web.HttpContext.Current.Server.MapPath("../PageEmployee/Sig") + "/" + ID + "pr.asc";
            ks.ExportPublicKey(@pathPub, userId, asciiArmored);

            // export secret key having the specified userId, this is usually our own key
            // all secret sub keys are exported too
            ks.ExportPrivateKey(@pathPri, userId, asciiArmored);

            // export both public and secret key with all sub keys in one file
            // the file is in ASCII armored format by default
            // ks.ExportKeyRing(@"DataFiles\keypair.asc", "support@didisoft.com");
        }

    }
}