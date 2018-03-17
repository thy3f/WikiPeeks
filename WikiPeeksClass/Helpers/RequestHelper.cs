using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace WikiPeeks.Helpers
{
    class RequestHelper
    {
        private static string url;
        private static HttpWebRequest request;
        private static StreamReader reader;

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public RequestHelper()
        {
            url = Properties.Resources.url;
            request = CreateRequest();
            reader = CreateResponse();

        }

        public static string Url
        {
            get => url;
            set => url = UrlHelper.Url;
        }

        internal static HttpWebRequest Request
        {
            get
            {
                return request;
            }

            set => request = value;
        }

        public static HttpWebRequest CreateRequest()
        {
            url = UrlHelper.Url;
            if(url == null)
            {
                string date = DateHelper.getDate();
                UrlHelper.Url = UrlHelper.SetUrl(DateHelper.getMonth(date), DateHelper.getDay(date));
                url = UrlHelper.Url;
            }

            // Try to reduce time for GET Request
            WebRequest.DefaultWebProxy = null;
            ServicePointManager.DefaultConnectionLimit = 20;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Proxy = WebRequest.DefaultWebProxy;
            return request;
        }

        public static StreamReader CreateResponse()
        {
            request = CreateRequest();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
                reader = new StreamReader(stream);
            return reader;
        }

        public static string GetResponse()
        {
            reader = CreateResponse();
            return reader.ReadToEnd();
        }
    }
}
