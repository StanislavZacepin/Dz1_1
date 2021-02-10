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
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ListWorkes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string __SqlInsertToName_DaperTable = @"INSERT INTO [dbo].[Departments] (Name) VALUES (N'{0}') ";
        const string __SqlInsertToName_WorkesTable = @"INSERT INTO [dbo].[Employees] (Name,Age,DepartmentId) VALUES (N'{0}','{1}''{2}') ";
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();

        public static string ConnectionString => Configuration.GetConnectionString("Default");
        //  говорим обьекту конфигурацыи что нам нужно стока подключения по имени дефолт
        
        Employee employee = new Employee();
        Department department = new Department();
        

        public MainWindow()
        {
            /// <summary>
            //подключения к бд
            /// </summary>
            // var connections_string2 = @"Data Source=\\localhost;Initial Catalog=TestBD_Workes;Integrated Security=True;Timeout=30";
            // var connections_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestBD_Workes;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var connection_string_builder = new SqlConnectionStringBuilder(connections_string); в файле конфигурацыы известили о подключении 


            /// <summary>
            //конфигурацыя . добавления файла appsettings.json указываем чтобы фаил был обязательным(false)
            //и чтобы система заней слидила и при изменениях автоматически перезагружался при изменения на диске (true)
            // и потом собираем конфигурацыю ,
            //но так как мы выводим в статическое свойства в класса для того чтобы была доступна в любом месте. Просто за каментим это
            /// </summary>
            //var config_builder = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json",false,true);
            //var config = config_builder.Build();
            InitializeComponent();


           

            employee.generate();
             department.generate();

            //  __cbListWorkes.ItemsSource = employee.Workes;          
            //  __cbListDepartment.ItemsSource = department.Depar;

            
            //const string __SqlInsertToDaper_WorkesTable = @"INSERT INTO [dbo].[Departments] (Daper) VALUES (N'{0}')";

            AddTable(employee.Workes, department.Depar);
            //AddTable(department.Depar, __SqlInsertToDaper_WorkesTable);



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
            if (e.Key == Key.Enter)
            {
                var index = __cbListWorkes.SelectedIndex;
                // __cbListWorkes.Items.RemoveAt(index);

                // employee.Workes.Insert(index,sender.ToString());
                //__cbListWorkes.Items.Insert(index,employee.Workes[index]);
                if (sender != null)
                {

                    employee.Workes.RemoveAt(index);
                    employee.Workes.Insert(index, sender.ToString());
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
       
        private static void AddTable(ObservableCollection<string> Name,ObservableCollection<string> Depar)
        {
            string sql = "SELECT * FROM [Departments]";
            string sql2 = "SELECT * FROM [Employees]";
            Random rnd18_50 = new Random();
            var connection_string = ConnectionString;
            DataRelation dataRelation;
            
            using (var connection = new SqlConnection(connection_string))
            {
                connection.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(ds);
                DataSet ds2 = new DataSet();
                SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, connection);
                adapter.Fill(ds2);
               
                foreach (var item in Depar)
                {
                    var command = new SqlCommand(string.Format(__SqlInsertToName_DaperTable, item), connection);
                    command.ExecuteNonQuery();
                }
                    foreach (var itemWork in Name)
                    {

                       var command = new SqlCommand(string.Format(__SqlInsertToName_WorkesTable, itemWork, rnd18_50.Next(18, 51),rnd18_50.Next(0,15) ), connection);

                    command.ExecuteNonQuery();

                }

               
                dataRelation = new DataRelation("ties", ds.Tables["Departments"].Columns["Id"], ds2.Tables["Employees"].Columns["DepartmentId"]);
                connection.Dispose();
            }
        }
       

    }
}
#region *** Список Департаментов
//string TextDepar = "социологииДоцент;" +
//        "социологии Доцент;" +
//        "социологии Доцент;" +
//        "социологии Старший преподаватель;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииЛаборант-исследователь;" +
//        "Департамент социологииПрофессор;" +
//        "Центр перспективных исследований и разработок в сфере образованияДиректор центра;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииАссистент;" +
//        "Департамент социологииДоцент;" +
//        "Учебно-научная социологическая;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииПомощник;" +
//        "Департамент социологииДоцент;" +
//        "Учебно-научная социологическая;" +
//        "Департамент социологииДоцент;" +
//        "Учебно-научная социологическая;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииПрофессор;" +
//        "Департамент социологииПрофессор;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииПрофессор;" +
//        "Департамент социологииМенеджер;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииПрофессор;" +
//        "Департамент социологииПрофессор;" +
//        "Департамент социологииСтарший;" +
//        "Департамент социологииДоцент;" +
//        "Департамент социологииГлавный;" +
//        "Департамент социологии Стажер;" +
//        "Департамент социологииПрофессор;" +
//        "Департамент социологииДоцент";



#endregion
