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
using System.Collections.ObjectModel;
using ListWorkes.models;
using ListWorkes.ViewModels;
using System.ComponentModel;


namespace ListWorkes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Employee employee = new Employee();
        Department department = new Department();
       
        public MainWindow()
        {
            employee.generate();
            department.generate();
            InitializeComponent();
            __cbListWorkes.ItemsSource = employee.Workes;
            // LoadComboBox.Combo( __cbListWorkes, employee.Workes);
            __cbListDepartment.ItemsSource = department.Depar;
                //LoadComboBox.Combo( __cbListDepartment, department.Depar);


        }

       
        private void __cbListWorkes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
                var index = __cbListWorkes.SelectedIndex;
                if (__cbListWorkes.SelectedIndex == index)
                {
                    __cbListDepartment.SelectedIndex = index;
                 
                }                      
        }

        private void __cbListDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
                var index = __cbListDepartment.SelectedIndex;
            if (__cbListDepartment.SelectedIndex == index)
            {
                __cbListWorkes.SelectedIndex = index;


            }
      
       
        }

        private void _butDell_Click(object sender, RoutedEventArgs e)
        {
            var index = __cbListWorkes.SelectedIndex;
            // __cbListWorkes.Items.RemoveAt(index);
            // __cbListDepartment.Items.RemoveAt(index);
            employee.Workes.RemoveAt(index);
            department.Depar.RemoveAt(index);
        }

        private void _butAdd_Click(object sender, RoutedEventArgs e)
        {
            // __cbListWorkes.Items.Add("Новый Роботник ");
            // __cbListDepartment.Items.Add("Департамент ");
            employee.Workes.Add("Новый Роботник");
            department.Depar.Add("Департамент ");
        }

        private void __tbWorkes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var index = __cbListWorkes.SelectedIndex;
               // __cbListWorkes.Items.RemoveAt(index);
              
                // employee.Workes.Insert(index,sender.ToString());
                //__cbListWorkes.Items.Insert(index,employee.Workes[index]);
                if (sender != null)
                {
                   
                    employee.Workes.RemoveAt(index);
                    employee.Workes.Insert(index,sender.ToString());
                }
            }
        }

        private void __tbDepar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var index = __cbListDepartment.SelectedIndex;
                //__cbListDepartment.Items.RemoveAt(index);
                //    department.Depar.RemoveAt(index);
                //    department.Depar.Insert(index, sender.ToString());
                //    __cbListDepartment.Items.Insert(index, department.Depar[index]);

                if (sender != null)
                {

                    department.Depar.RemoveAt(index);
                    department.Depar.Insert(index, sender.ToString());
                }
            }
        }

       
        

    }
}

