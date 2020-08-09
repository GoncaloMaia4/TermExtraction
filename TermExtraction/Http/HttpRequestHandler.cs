using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TermExtraction.Model;

namespace TermExtraction.Http
{
    public class HttpRequestHandler
    {
        private const string key = "gonçalo:f62192e0c82c7fa90802cdaac7bb80cabfaa2c8c3be69097fb925f0dc665545e";
        private const string alertURL = "https://services.prewave.ai/adminInterface/api/testAlerts?key=" + key;
        private const string queryTermURL = "https://services.prewave.ai/adminInterface/api/testQueryTerm?key=" + key;


        public List<Alert> GetAlerts()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(alertURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert HttpWebResponse to string so it can be deserialized to List<Alert> object
            Stream newStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(newStream);
            var result = sr.ReadToEnd();

            var alertList = JsonConvert.DeserializeObject<List<Alert>>(result);

            return alertList;
        }

        public List<QueryTerm> GetQueryTerms()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(queryTermURL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert HttpWebResponse to string so it can be deserialized to List<QueryTerm> object
            Stream newStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(newStream);
            var result = sr.ReadToEnd();

            var queryTermList = JsonConvert.DeserializeObject<List<QueryTerm>>(result);

            return queryTermList;
        }
    }
}
