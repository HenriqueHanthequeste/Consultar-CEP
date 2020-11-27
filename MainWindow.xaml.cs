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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            GetCEPFullAddress(cepSource.Text);
        }

        public async Task GetCEPFullAddress(string cep)
        {
            var cepAPI = RestService.For<ICepAPIService>("https://buscacepinter.correios.com.br");

            var addresConsult = await cepAPI.GetAddressAsync(cep);

            apiReturnBox.Text = addresConsult.mensagem;
            logReturnBox.Text = addresConsult.dados[0].logradouroDNEC;

            //Sometimes, the API Return data in localidadeSubordinada. When it happens, the software is unable to interpret
            if(addresConsult.dados[0].localidadeSubordinada != "")
            {
                cityReturnBox.Text = addresConsult.dados[0].localidadeSubordinada;
                neigbhReturnBox.Text = addresConsult.dados[0].localidade;
            }
            else
            {
                neigbhReturnBox.Text = addresConsult.dados[0].bairro;
                cityReturnBox.Text = addresConsult.dados[0].localidade;
            }
            
            ufReturnBox.Text = addresConsult.dados[0].uf;

            if (addresConsult.dados[0].localidadeSubordinada != "")
            {
                await GetRangeCEP(addresConsult.dados[0].uf, addresConsult.dados[0].localidadeSubordinada);
            } else
            {
                await GetRangeCEP(addresConsult.dados[0].uf, addresConsult.dados[0].localidade);
            }

            if (addresConsult.mensagem.StartsWith("ATENÇÃO!"))
            {
                newCEPReturnBox.Visibility = Visibility.Visible;
                newCEPReturnBox.Text = addresConsult.dados[0].cep.Insert(5, "-");
            }
            else
            {
                newCEPReturnBox.Visibility = Visibility.Hidden;
            }
        }

        public async Task GetRangeCEP(string uf, string city)
        {
            var rangeCEPAPI = RestService.For<IRangeCEPAPIService>("https://buscacepinter.correios.com.br");

            var rangeConsult = await rangeCEPAPI.GetRangeCEPAsync(uf, city);

            cepRangeReturnBox.Text = rangeConsult.dados[0].faixasCep[0].cepInicial.Insert(5, "-") + " - " + rangeConsult.dados[0].faixasCep[0].cepFinal.Insert(5, "-");

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
