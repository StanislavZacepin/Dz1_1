using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ListWorkes.ViewModels
{
    
        public static class LoadComboBox 
        {
        public static ComboBox Combo(ComboBox comboBox, IEnumerable<string> observaivalcolection)
        {
            foreach (var item in observaivalcolection)
            {
                comboBox.Items.Add(item);
            }
            return comboBox;
        }
        }
    }


