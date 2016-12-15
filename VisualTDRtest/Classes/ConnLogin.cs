using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualTDRtest.Classes
{
    
    public class ConnLogin
    {
        public String sTornada=string.Empty;
        public byte[] bTornada;
        public String Tornadis;

        public async Task<String> Login(String usu,String pass)
        {
            String url = "http://www.tdrtestnfc.esy.es/tdr_test/login.php";
            IEnumerable<KeyValuePair<string, string>> datos = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("usu",usu)
               ,new KeyValuePair<string, string>("pass", pass)
            };
            try
            {
                HttpContent q = new FormUrlEncodedContent(datos);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(url, q);
                    HttpContent content = response.Content;
                    String respuesta = await content.ReadAsStringAsync();
                    sTornada = respuesta;
                    return respuesta;
                }

            }
            catch (Exception)
            {

                return "Error";
            }

        }

        public async Task<String> Login(String usu,String email,String pass)
        {
            String url = "http://www.tdrtestnfc.esy.es/tdr_test/signup.php";
            IEnumerable<KeyValuePair<string, string>> datos = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("usu",usu),
            new KeyValuePair<string, string>("email", email),
            new KeyValuePair<string, string>("pass",pass)
            };
            try
            {
                HttpContent q = new FormUrlEncodedContent(datos);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(url, q);
                    HttpContent content = response.Content;
                    String respuesta = await content.ReadAsStringAsync();
                    sTornada = respuesta;
                    return respuesta;
                }

            }
            catch (Exception)
            {

                return "Error";
            }
        }
        public async Task<string> Email(String usu, String pass)
        {
            String url = "http://www.tdrtestnfc.esy.es/tdr_test/pedirinfo.php";
            IEnumerable<KeyValuePair<string, string>> datos = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("usu",usu)
               ,new KeyValuePair<string, string>("pass", pass)
            };
            try
            {
                HttpContent q = new FormUrlEncodedContent(datos);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(url, q);
                    HttpContent content = response.Content;
                    String respuesta = await content.ReadAsStringAsync();
                    Tornadis = respuesta;
                    return respuesta;
                }

            }
            catch (Exception)
            {

                return "Error";
            }

        }

        public async Task<string> Test(String usu)
        {
            String url = "http://www.tdrtestnfc.esy.es/tdr_test/tablareg.php";
            IEnumerable<KeyValuePair<string, string>> datos = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("usu",usu)
               
            };
            try
            {
                HttpContent q = new FormUrlEncodedContent(datos);

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(url, q);
                    HttpContent content = response.Content;
                    string respuesta =  await content.ReadAsStringAsync();
                    
					
                    
                    return respuesta;
                }

            }
            catch (Exception)
            {

                return null;
            }

        }
    }

    
}
