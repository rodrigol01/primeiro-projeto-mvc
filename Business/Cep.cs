using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace Business
{
    public class Cep
    {
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public static Cep Busca(string cep)
        {
            var cepObj = new Cep();
            var url = "https://viacep.com.br/ws/01001000/json?code=" + cep;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            string json = string.Empty;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
                if (stream != null)
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        json = sr.ReadToEnd();
                    }

            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            JsonCepObject cepJson = jsonSerializer.Deserialize<JsonCepObject>(json);

            cepObj.CEP = cepJson.Code;
            cepObj.Endereco = cepJson.Address;
            cepObj.Bairro = cepJson.District;
            cepObj.Cidade = cepJson.City;
            cepObj.Estado = cepJson.State;
            return cepObj;
        }

        public class JsonCepObject
        {
            public string Code { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string District { get; set; }
            public string Address { get; set; }
        }
    }
}