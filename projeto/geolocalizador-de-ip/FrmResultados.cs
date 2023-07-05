using System;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace geolocalizador_de_ip
{
    public partial class FrmResultados : Form
    {
        public FrmResultados()
        {
            InitializeComponent();
        }

        public string ipString { get; set; } // O método 'get' recebe o conteúdo da textbox 'tbxIP' do form 'FormMenu' e o método 'set' envia para a string 'ipString';

        private void FormResultados_Load(object sender, EventArgs e)
        {
            ActiveControl = null; // Define o foco para nenhum controle;

            var ip = ipString; // A variável 'ip' recebe o conteúdo da string 'ipString';

            var url = "http://ip-api.com/json/" + ip + "?fields=15738879&lang=pt-BR"; // Construindo a URL para fazer a solicitação ao serviço web com base no endereço IP fornecido;

            using (HttpClient httpClient = new HttpClient()) // Criando uma nova instância da classe HttpClient que permite enviar solicitações HTTP para um servidor e receber respostas;
            {
                // Removendo o cabeçalho e definindo o formato do conteúdo da resposta para JSON:
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // Passando o endereço da API para obter os detalhes de geolocalização:
                httpClient.BaseAddress = new Uri(url);
                HttpResponseMessage httpResponse = httpClient.GetAsync(url).GetAwaiter().GetResult();

                
                if (httpResponse.IsSuccessStatusCode) // Se a API for bem-sucedida e a resposta for recebida, os detalhes do local serão obtidos:
                {
                    // A resposta HTTP é lida e convertida para um objeto 'Ip_Api' (desserialização do conteúdo JSON da resposta HTTP):
                    var geolocationInfo = httpResponse.Content.ReadAsAsync<Ip_Api>(new[] { new JsonMediaTypeFormatter() }).GetAwaiter().GetResult();

                    if (geolocationInfo != null)
                    {
                        //txbIp.Text = geolocationInfo.ip;
                        txbHost.Text = geolocationInfo.query;
                        txbProvedor.Text = geolocationInfo.isp;

                        txbPais.Text = geolocationInfo.country;
                        txbEstado.Text = geolocationInfo.regionName + " (" + geolocationInfo.region + ")";
                        txbCidade.Text = geolocationInfo.city;
                        txbContinente.Text = geolocationInfo.continent + " (" + geolocationInfo.continentCode + ")";

                        if (txbPais.Text == "Brasil")
                        {
                            txbCodigoPostal.Text = geolocationInfo.zip + "-000";
                        }
                        else 
                        {
                            txbCodigoPostal.Text = geolocationInfo.zip;
                        }
                        
                        txbLatitude.Text = geolocationInfo.lat;
                        txbLongitude.Text = geolocationInfo.lon;

                        txbMoeda.Text = geolocationInfo.currency;
                        txbFusoHorario.Text = geolocationInfo.timezone;
                    }
                }
            }


        }
    }

    // Classe que corresponde à estrutura do JSON retornado pelo serviço web:
    public class Ip_Api
    {
        public string query { get; set; }
        public string continent { get; set; }
        public string continentCode { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string zip { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone { get; set; }
        public string currency { get; set; }
        public string isp { get; set; }
        public string org { get; set; }
        public string asname { get; set; }
    }
}