using Aula_01_Consulta_CEP.Servico;
using Aula_01_Consulta_CEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aula_01_Consulta_CEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs e)
        {
            string cep = TextBox.Text.Trim();
            
            //TODO - lógica do programa
            if (isValideCep(cep) == true)
            {
                try
                {

                    Endereco ende = ViaCepServico.BuscaEnderecoViaCep(cep);

                    if (ende == null)
                    {
                        Resultado.Text = $"Cep não existe";
                    }
                    else
                    { 

                        Resultado.Text = $"Endereço: {ende.logradouro}\nBairro: {ende.bairro}\n";
                    }

                }
                catch (WebException er)
                {

                    DisplayAlert("Erro", "Você não esta conectado a internet", "Ok");
                }
                catch (Exception ee)
                {
                    DisplayAlert("Erro", ee.Message, "Ok");
                }
            }

            //TODO - Validações

        }

        private bool isValideCep(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                //Erro
                DisplayAlert("Erro", "Cep invalido! O Cep deve conter 8 caracteres","Ok");

                valido = false;
            }

            int NovoCep = 0;

            if (!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("Erro", "O Cep deve conter  apenas números", "Ok");

                valido = false;
            }

            return valido;
        }
    }
}
