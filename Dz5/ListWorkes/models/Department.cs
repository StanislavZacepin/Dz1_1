using System.Collections.ObjectModel;
using System.ComponentModel;


namespace ListWorkes.models
{
   
        public  class Department: INotifyPropertyChanged
        {
        
        private ObservableCollection<string> _Depar= new ObservableCollection<string>();
        public ObservableCollection<string> Depar
        {
            get=>_Depar;
            set
            {
                _Depar = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Depar)));
            } 
        }


        #region *** Список Департаментов
        string TextDepar =

                "социологии Старший преподаватель;" +
                "Департамент социологииДоцент;" +
                "Департамент социологииЛаборант-исследователь;" +
                "Департамент социологииПрофессор;" +
                "Центр перспективных исследований и разработок в сфере образованияДиректор центра;" +

                "Департамент социологииАссистент;" +

                "Учебно-научная социологическая;" +

                "Департамент социологииПомощник;" +

                "Учебно-научная социологическая;" +

                "Департамент социологииПрофессор;" +

                "Департамент социологииМенеджер;" +

                "Департамент социологииСтарший;" +

                "Департамент социологииГлавный;" +
                "Департамент социологии Стажер;";
          
          



        #endregion

        public void generate()
        {
            var component = TextDepar.Split(';');
            foreach (var item in component)
            {
                Depar.Add(item);
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        
        
       

    }
      }


