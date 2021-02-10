﻿using System.Collections.ObjectModel;
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
          string TextDepar = "социологииДоцент;" +
                  "социологии Доцент;" +
                  "социологии Доцент;" +
                  "социологии Старший преподаватель;" +
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
                  "Департамент социологии Стажер;" +
                  "Департамент социологииПрофессор;" +
                  "Департамент социологииДоцент";



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


