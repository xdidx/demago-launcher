using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gta_demago_launcher
{
    class WsResponse
    {
        public string error = "";
        public string message = "";
    }

    class WsVersionResponse : WsResponse
    {
        public float version = 0;
        public float maxVersion = 0;
        public string maxVersionDownloadLink = "";
        public string texturesLink = ""; 
        public string musicsLink = ""; 
    }

    static class DemagoWebService
    {
        public static WsVersionResponse checkCurrentVersion(string md5Checksum)
        {
            WebRequest request = WebRequest.Create("http://nesblog.com/gta-demago/ws/version.php?checksum=" + md5Checksum);


            //var data = Encoding.ASCII.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
            
                WsVersionResponse versionResponse = JsonConvert.DeserializeObject<WsVersionResponse>(responseFromServer);
                return versionResponse;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur: "+e.Message);
                return null;
            }
        }
    }
}
