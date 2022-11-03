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
using Datos;
using BLL;

namespace Carrera
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InscripcionBLL ibll = new InscripcionBLL();
        public MainWindow()
        {
            InitializeComponent();
            CmbRecorrido.ItemsSource = Enum.GetValues(typeof(Recorrido));
            CmbRecorrido.SelectedIndex = 0;
            CmbCategoría.ItemsSource = Enum.GetValues(typeof(Categoria));
            CmbCategoría.SelectedIndex = 3;

            DateTime today = DateTime.Today;
            DpFecha.SelectedDate = today;
        }

        private void TxtNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        int i1=1;
        int i2=1;
        int i3=1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Inscripcion nueva = new Inscripcion();
        
            nueva.Reco = (Recorrido)CmbRecorrido.SelectedValue;
            nueva.Cate = (Categoria)CmbCategoría.SelectedValue;
            nueva.FechaInscripcion = (DateTime)DpFecha.SelectedDate;
            nueva.Nombre = TxtNombre.Text.Trim();
            nueva.Edad = int.Parse(TxtEdad.Text);
            nueva.Email = TxtCorreo.Text.Trim();

            double valor;
            double desc;
            string Id;
            string identificador = "";
            
            string s = "";

            if (CmbRecorrido.SelectedValue.ToString() == "K2")
            {
                valor = 10000;
                Id = "K2";
                s = i1.ToString().PadLeft(3, '0');
                i1++;
               
            }
            else if (CmbRecorrido.SelectedValue.ToString() == "K4")
            {
                valor = 15000;
                Id = "K4";
                s = i2.ToString().PadLeft(3, '0');
                i2++;
                
            }
            else {
                valor = 20000;
                Id = "K8";
               
                s = i3.ToString().PadLeft(3, '0');
                i3++;
            }

            if (CmbCategoría.SelectedValue.ToString() == "Infantil")
            {
                desc = 0.25;
            }
            else if (CmbCategoría.SelectedValue.ToString() == "Amateur")
            {
                desc = 0.50;
            }
            else {
                desc = 1;
            }

            valor = valor * desc;
            nueva.Valor = valor;
            identificador = Id + "-" + s;
            nueva.Identificador = identificador;


            //Validación del formulario

            ibll.Add(nueva);

            LstInscripciones.ItemsSource = null;
            LstInscripciones.ItemsSource = ibll.GetAll();


        }
    }
}
 
