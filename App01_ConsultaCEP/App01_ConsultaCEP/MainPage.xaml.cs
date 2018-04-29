﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCEP.Servico.Modelo;
using App01_ConsultaCEP.Servico;

namespace App01_ConsultaCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			BOTAO.Clicked += BuscarCEP;
		}



        //=======================================================================================================
        // BuscarCEP
        //-------------------------------------------------------------------------------------------------------
        // Buscap pelo CEP indicado. Acao do Botao Buscar_CEP.
        //=======================================================================================================
        private void BuscarCEP(object sender, EventArgs e)
		{
            //TODO - Logica do progama
            string cep = CEP.Text.Trim();

            //TODO - Validacoes
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                        RESULTADO.Text = String.Format("Endereço: {0},{1} -> {2} {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                    else
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado:" + cep, "OK");
                }
                catch(Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
		}

        //=======================================================================================================
        // isValidCEP
        //-------------------------------------------------------------------------------------------------------
        // Valida se o CEP é válido
        //=======================================================================================================
        private bool isValidCEP(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                return false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números.", "OK");
                return false;
            }


            return true;
        }
	}
}
