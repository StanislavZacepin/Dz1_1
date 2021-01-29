using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ListWorkes.ViewModels
{
    
        public static class LoadComboBox
        {
        public static void Combo(ref ComboBox comboBox, ref ObservableCollection<string> observaivalcolection)
        {
            foreach (var item in observaivalcolection)
            {
                comboBox.Items.Add(item);
            }
        }
        }
    }


