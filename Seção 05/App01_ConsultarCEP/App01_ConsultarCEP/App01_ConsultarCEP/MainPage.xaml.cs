using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

            //TODO - Validação.
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            try{
                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {

                        RESULTADO.Text = string.Format("Endereço: 1{2},{3},{0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço nao encontrado para o CEP informado:" + cep, "OK");
                    }
            }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            
        }

            //TODO - Lógica do Programa.
            private bool isValidCEP(string cep)
            {
            bool valido = true;
           /* if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve Coneter 8 Caracteres.", "OK");
                valido = false;
            }*/
            int NovoCEP = 0;
            if(!int.TryParse(cep,out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! Digite um CEP válido.", "OK");
                valido = false;
            }

            return valido;

            }
        }
    
}
