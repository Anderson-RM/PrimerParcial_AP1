using PrimerParcial_AP1.BLL;
using PrimerParcial_AP1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PrimerParcial_AP1.UI.Registros{
     
    public partial class rArticulos : Window
    {
        int existencia = 0;
        double costo = 0; 
        double total = 0; 

        private Articulos Articulos = new Articulos(); 

        public rArticulos()
        {
            InitializeComponent();
            this.DataContext = this.Articulos;
        }

        /*Buscando Registro*/
        private void BuscarCarroButton_Click(object sender, RoutedEventArgs e)
        {
            
            var articulo = ArticulosBLL.Buscar(int.Parse(ArticuloIdTextBox.Text));

            if (articulo != null)
            {
                this.Articulos = articulo;
            }
            else
            {
                this.Articulos = new Articulos();
            }

            this.DataContext = this.Articulos;

        }

        /*Nuevo Registro*/
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        /*Guardar*/
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            bool ok = ArticulosBLL.Guardar(Articulos);

            if (ok)
            {
                MessageBox.Show("Se ha guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Funcion Fallida.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /*Eliminar*/
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {             

            if (ArticulosBLL.Eliminar(int.Parse(ArticuloIdTextBox.Text)))
            {
                MessageBox.Show("Se ha eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("no se pudo eliminar el registro.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /*Llenando TextBox*/
        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExistenciaTextBox.Text == "" || Regex.IsMatch(ExistenciaTextBox.Text, "^[a-zA-Z]+$"))
            {
                existencia = 0;
            }
            else
            {
                existencia = int.Parse(ExistenciaTextBox.Text);
            }

        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            total = 0;

            if (CostoTextBox.Text == "" || Regex.IsMatch(ExistenciaTextBox.Text, "^[a-zA-Z]+$"))
            {
                costo = 0;

            }
            else
            {
                costo = int.Parse(CostoTextBox.Text);
                ValorInventarioTextBox.Text = total.ToString();
            }

            total = costo * existencia;
            ValorInventarioTextBox.Text = total.ToString();
        }


        private void ValorInventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValorInventarioTextBox.Text = total.ToString();
        }
    
        public void Limpiar()
        {
            this.Articulos = new Articulos();
            this.DataContext = this.Articulos;
        }

        /*Validar*/
        public bool Validar()
        {
            if (!Regex.IsMatch(ArticuloIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Id Solo permite un digito del 0 - 9.", "Funcion Fallida.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!Regex.IsMatch(ExistenciaTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Existencia solo permite digitos del 0 - 9.", "Funcion Fallida.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!Regex.IsMatch(CostoTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Costo solo permite digitos del 0 - 9.", "Funcion Fallida.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (DescripcionTextBox.Text == "")
            {
                MessageBox.Show("Favor llenar el campo Descripcion.", "Obligatorio.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
       
    }
}
