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


namespace ListWorkes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // public static List<string> Workes { get; set; } 
        //public static List<string> Depar { get; set; }

        //public delegate void  Action (object sender, EventArgs e);
        //   Action action;

        public MainWindow()
        {
            InitializeComponent();
            // action = __cbListWorkes_DropDownOpened;
            //action += __cbListDepartment_DropDownOpened;



        }

        public void GenerateList(ref List<string> __list, string txt)
        {

            var component = txt.Split(';');
            foreach (var item in component)
            {
                __list.Add(item);
            }

        }
        public void Employee(ref List<string> __list)
        {


            #region*** Список имен
            string listWork = "Воеводина Екатерина Владимировна;" +
                "Грунтовский Иосиф Иосифович;" +
                "Дудина Ольга Мухаметшевна;" +
                "Епхиев Олег Муратович;" +
                "Залесский Петр Карлович;" +
                "Иванова Яна Сергеевна;" +
                "Кибакин Михаил Викторович;" +
                "Киселёва Наталья Ильинична;" +
                "Кораблин Юрий Алексеевич;" +
                "Котов Дмитрий Алексеевич;" +
                "Круглова Елена Леонидовна;" +
                "Кунижева Диана Анзоровна;" +
                "Лаамарти Юлия Александровна;" +
                "Лебедева Светлана Юрьевна;" +
                "Львов Степан Васильевич;" +
                "Марков Дмитрий Игоревич;" +
                "Микрюков Владимир Олегович;" +
                "Мишин Кирилл Юрьевич;" +
                "Назаренко Сергей Владимирович;" +
                "Николаев Александр Александрович;" +
                "Новиков Алексей Викторович;" +
                "Носкова Антонина Вячеславовна;" +
                "Оборский Алексей Юрьевич;" +
                "Орлова Елена Александровна;" +
                "Осипова Ольга Степановна;" +
                "Панова Татьяна Викторовна;" +
                "Перемибеда Павел Александрович;" +
                "Письменная Елена Евгеньевна;" +
                "Примаков Вячеслав Леонидович;" +
                "Проскурина Александра Сергеевна;" +
                "Прохода Владимир Анатольевич;" +
                "Прохорова Ирина Геннадьевна;" +
                "Проценко Полина Андреевна;" +
                "Разов Павел Викторович;" +
                "Райдугин Дмитрий Сергеевич";

            #endregion

            GenerateList(ref __list, listWork);

        }
        public void Department(ref List<string> __list)
        {


            #region *** Список Департаментов
            string listDepar = "социологииДоцент;" +
                  "социологииДоцент;" +
                  "социологииДоцент;" +
                  "социологииСтарший преподаватель;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииЛаборант-исследователь;" +
                  "Департамент социологииПрофессор;" +
                  "Центр перспективных исследований и разработок в сфере образованияДиректор центра;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииАссистент;" +
                  "Департамент социологииДоцент;" +
                  "Учебно-научная социологическая;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииПомощник;" +
                  "Департамент социологииДоцент;" +
                  "Учебно-научная социологическая;" +
                  "Департамент социологииДоцент;" +
                  "Учебно-научная социологическая;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииПрофессор;" +
                  "Департамент социологииПрофессор;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииПрофессор;" +
                  "Департамент социологииМенеджер;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииПрофессор;" +
                  "Департамент социологииПрофессор;" +
                  "Департамент социологииСтарший;" +
                  "Департамент социологииДоцент;" +
                  "Департамент социологииГлавный;" +
                  "Департамент социологииСтажер;" +
                  "Департамент социологииПрофессор;" +
                  "Департамент социологииДоцент";

            #endregion

            GenerateList(ref __list, listDepar);

        }

        private void __cbListWorkes_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> Workes = new List<string>();

            Employee(ref Workes);
            foreach (var item in Workes)
            {
                __cbListWorkes.Items.Add(item);
            }

        }

        private void __cbListDepartment_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> Depar = new List<string>();

            Department(ref Depar);
            foreach (var item in Depar)
            {
                __cbListDepartment.Items.Add(item);
            }
        }

        private void __cbListWorkes_DropDownOpened(object sender, EventArgs e)
        {
            //    if(!__cbListWorkes.IsDropDownOpen)
            //    action(this, e);
            // когда удаляю DropDownOpened методы и удалю их с событий пишет ошибки не знаю как убрать поэтому оставил
        }

        private void __cbListDepartment_DropDownOpened(object sender, EventArgs e)
        {
            // когда удаляю DropDownOpened методы и удалю их с событий пишет ошибки не знаю как убрать поэтому оставил
        }

        private void __cbListWorkes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = __cbListWorkes.SelectedIndex;
            if (__cbListWorkes.SelectedIndex == index)
            {
                __cbListDepartment.SelectedIndex = index;
                __tbWorkes.IsEnabled = true;
                if (__cbAdd.IsEnabled == false && __cbChange.IsEnabled == false)
                {
                    __cbAdd.IsEnabled = true;
                    __cbChange.IsEnabled = true;
                    __cbDel.IsEnabled = true;
                }
             }
        }

        private void __cbListDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = __cbListDepartment.SelectedIndex;
            if (__cbListDepartment.SelectedIndex == index)
            {
                __cbListWorkes.SelectedIndex = index;
                __tbDepar.IsEnabled = true;
                if (__cbAdd.IsEnabled == false && __cbChange.IsEnabled == false)
                {
                    __cbAdd.IsEnabled = true;
                    __cbChange.IsEnabled = true;
                    __cbDel.IsEnabled = true;
                }
            }
        }

        private void __tbWorkes_KeyDown(object sender, KeyEventArgs e)
        {
           // if(this!=null)
            if(e.Key == Key.Enter)
            {
                    if (__cbAdd.IsChecked == true)
                    {
                    __cbListWorkes.Items.Add(this);
                        
                    }
            }
        }

        private void __cbChange_Click(object sender, RoutedEventArgs e)
        {
            if(__cbChange.IsChecked == true)
            {
                __cbAdd.IsChecked = false;
                __cbDel.IsChecked = false;
            }
            
        }

        private void __cbAdd_Click(object sender, RoutedEventArgs e)
        {
            if (__cbAdd.IsChecked == true)
            {
                __cbChange.IsChecked = false;
                __cbDel.IsChecked = false;
            }
           
        }

        private void ___cbDel_Click(object sender, RoutedEventArgs e)
        {
            if (__cbDel.IsChecked == true)
            {
                __cbAdd.IsChecked = false;
                __cbChange.IsChecked = false;

            }
        }
    }
}

