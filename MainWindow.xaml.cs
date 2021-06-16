using Consultar_CEP.references;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Consultar_CEP
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        CEPRequest cEPRequest;
        RangeCEPRequest rangeCEPRequest;
        public MainWindow()
        {
            InitializeComponent();
            cEPRequest = new CEPRequest();
            rangeCEPRequest = new RangeCEPRequest();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            //GetCEPFullAddress(cepSource.Text);

            try
            {
                CEPResponse response = cEPRequest.GetCEPResponse(cepSource.Text);

                apiReturnBox.Text = response.mensagem;
                logReturnBox.Text = response.dados[0].logradouroDNEC;

                //Sometimes, the API Return data in localidadeSubordinada. When it happens, the software is unable to interpret
                if (response.dados[0].localidadeSubordinada != "")
                {
                    cityReturnBox.Text = response.dados[0].localidadeSubordinada;
                    neigbhReturnBox.Text = response.dados[0].localidade;
                }
                else
                {
                    neigbhReturnBox.Text = response.dados[0].bairro;
                    cityReturnBox.Text = response.dados[0].localidade;
                }

                ufReturnBox.Text = response.dados[0].uf;

                if (response.dados[0].localidadeSubordinada != "")
                {
                    RangeCEPResponse rangeCEPResponse = rangeCEPRequest.GetRangeCEPResponse(response.dados[0].uf, response.dados[0].localidadeSubordinada);
                }
                else
                {
                    RangeCEPResponse rangeCEPResponse = rangeCEPRequest.GetRangeCEPResponse(response.dados[0].uf, response.dados[0].localidade);
                    cepRangeReturnBox.Text = rangeCEPResponse.dados[0].faixasCep[0].cepInicial.Insert(5, "-") + " - " + rangeCEPResponse.dados[0].faixasCep[0].cepFinal.Insert(5, "-");
                }

                if (response.mensagem.StartsWith("ATENÇÃO!"))
                {
                    newCEPReturnBox.Visibility = Visibility.Visible;
                    newCEPReturnBox.Text = response.dados[0].cep.Insert(5, "-");
                }
                else
                {
                    newCEPReturnBox.Visibility = Visibility.Hidden;
                }
            } catch (Exception exp)
            {
                MessageBox.Show($"Verifique o CEP Digitado!\nErro Gerado: {exp.Message}","Verifique o CEP digitado",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        //private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.Key == Key.Enter)
        //    {
        //        searchButton.
        //    }
        //}
    }
}
