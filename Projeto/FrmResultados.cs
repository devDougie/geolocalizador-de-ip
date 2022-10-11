using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using Microsoft.VisualBasic.Devices;

namespace geolocalizador_de_ip
{
    public partial class FrmResultados : Form
    {
        public string ipString { get; set; } //O método get recebe o conteúdo da textbox 'tbxIP' do form 'FormMenu' e o método set envia para a string 'ipString';

        public FrmResultados()
        {
            InitializeComponent();
            
        }

        private void FormResultados_Load(object sender, EventArgs e)
        {
            var ip = ipString; //A variável 'ip' recebe o conteúdo da string 'ipString';

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://ip-api.com/json/" + ip + "?fields=1059321"); //Classe que fornece uma implementação específica de HTTP;

            request.AllowAutoRedirect = false; //Obtém ou define um valor que indica se a solicitação deve seguir as respostas de redirecionamento.

            HttpWebResponse ServerResponse = (HttpWebResponse)request.GetResponse(); //Classe que fornece uma implementação específica da classe 'WebResponse' para o protocolo HTTP.

            if (ServerResponse.StatusCode != HttpStatusCode.OK) //Verifica se há resposta do servidor;
            {
                MessageBox.Show("Servidor Indisponível!"); //Retorna mensagem caso não haja resposta do servidor;
                return;
            }

            //'using' é uma instrução que garante o uso correto de objetos.
            using (Stream webStream = ServerResponse.GetResponseStream()) //Implementa um TextReader que lê caracteres de um fluxo de bytes em uma codificação específica.
            {
                if (webStream != null) //Verificando se o Stream obtido não é nulo;
                {
                    using (StreamReader responseReader = new StreamReader(webStream)) //Utilizando um objeto para fazer a leitura da resposta JSON;
                    {
                        string response = responseReader.ReadToEnd(); //lendo a resposta até o final;
                        response = Regex.Replace(response, "[{},]", string.Empty); //remove colchetes, chaves e vírgula;
                        response = response.Replace("\"", ""); //remove áspas dupla e barra;
                        String[] substrings = response.Split('\n'); //coloca a resposta da API em um Array;
                        int cont = 0;
                        foreach (var substring in substrings)
                        {
                            if (cont == 1)
                            {
                                string[] valor = substring.Split(":".ToCharArray()); //remove dois pontos;
                                if (valor[0] == " erro")
                                {
                                    MessageBox.Show("IP não encontrado!");
                                    return;
                                }
                            }

                            if (cont == 2)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbContinente.Text = valor[1];
                            }

                            if (cont == 3)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbPais.Text = valor[1];
                            }

                            if (cont == 4)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbEstado.Text = valor[1];
                            }

                            if (cont == 5)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbCidade.Text = valor[1];
                            }

                            if (cont == 6)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbCodigoPostal.Text = valor[1];
                            }

                            if (cont == 7)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbLatitude.Text = valor[1];
                            }

                            if (cont == 8)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbLongitude.Text = valor[1];
                            }

                            if (cont == 9)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbFusoHorario.Text = valor[1];
                            }

                            if (cont == 10)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbProvedor.Text = valor[1];
                            }

                            if (cont == 11)
                            {
                                string[] valor = substring.Split(":".ToCharArray());
                                txbIp.Text = valor[1];
                            }
                            cont++;
                        }
                    }
                }
            }
        }
    }
}
