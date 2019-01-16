using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;

namespace BackEnd.Base
{
    public class CommonBackEndMethods
    {


        public int GetWebServiceValidation(string path, string user, string userPassword, out List<string> valuesFromWebService)
        {
            valuesFromWebService = null;
            try
            {
                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                //string jsonURL = this.hostUrl + ruleName;
                string jsonURL = "http://localhost:8081" + path;
                Trace.WriteLine("URL: " + jsonURL);
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
                                 (delegate { return true; });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string username = user;
                string password = userPassword;

                string authInfo = username + ":" + password;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

                var requisicaoWeb = WebRequest.CreateHttp(jsonURL);
                requisicaoWeb.Headers["Authorization"] = "Basic " + authInfo;
                requisicaoWeb.ContentType = "application/json; boundary=" + boundary;
                requisicaoWeb.Method = "GET";
                requisicaoWeb.KeepAlive = true;
                requisicaoWeb.Credentials = System.Net.CredentialCache.DefaultCredentials;
                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    object objResponse = reader.ReadToEnd();
                    var token = JToken.Parse(objResponse.ToString());
                    List<String> ruleWebServicesResults = new List<String>();
                    foreach (var value in token)
                    {
                        ruleWebServicesResults.Add(value.ToString());
                        Trace.WriteLine("Rule Name: " + value.ToString());
                    }
                    valuesFromWebService = ruleWebServicesResults;

                    return token.Count();
                }


            }
            catch
            {
                Trace.WriteLine("Error: No Rule Name was found");
                return 0;
            }
        }

        private string PostJsonMessage(string msg, string uri)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback
                               (delegate { return true; });
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                // Atlas test credentials
                String username = "ATLAS_AUTOMATION";
                String password = "ATLAS_AUTOMATION";

                string authInfo = username + ":" + password;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));

                request.Headers["Authorization"] = "Basic " + authInfo;

                request.Method = "POST";

                string postData = msg;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json; charset=UTF-8";//formdata
                request.ContentLength = byteArray.Length;

                Stream dataStream = request.GetRequestStream();
              
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                string res = ((HttpWebResponse)response).StatusDescription;
                if (res != "OK")
                {
                    Console.WriteLine("FAILED: POST Response is " + res);
                    throw new Exception();
                }
                Console.WriteLine("POST Response is " + res);

                return responseFromServer;
            }
            catch (Exception e)
            {
                Trace.WriteLine("Error on Post message:" + e);
                return "Error on Post message:" + e;
            }
        }
    }
}
