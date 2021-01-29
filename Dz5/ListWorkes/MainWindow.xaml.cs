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
using ListWorkes.model;
using ListWorkes.ViewModels;
using System.ComponentModel;

namespace ListWorkes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        

        public ObservableCollection<string> Workes = new ObservableCollection<string>();
        public ObservableCollection<string> Depar = new ObservableCollection<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            GenerateList.generate(ref Workes, Employee.listWork);
            GenerateList.generate(ref Depar, Department.listDepar);
            //LoadComboBox.Combo(ref __cbListWorkes, ref Workes);
            //LoadComboBox.Combo(ref __cbListDepartment, ref Depar);


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
            Workes.RemoveAt(index);
            Depar.RemoveAt(index);
        }

        private void _butAdd_Click(object sender, RoutedEventArgs e)
        {
            //Workes.Add("Новый Роботник ");
            //Depar.Add("Департамент ");
            
        }

        private void __tbWorkes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
            //    var index = __cbListWorkes.SelectedIndex;
            //    Workes[index]=  Workes[index] =(string)sender;
            }
        }

        private void __tbDepar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //var index = __cbListDepartment.SelectedIndex;
                //__cbListDepartment.Items[index] = sender;
            }
        }
    }
}

