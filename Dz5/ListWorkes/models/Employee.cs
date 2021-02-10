using System.Collections.ObjectModel;
using System.ComponentModel;


namespace ListWorkes.models
{
   
        public  class Employee: INotifyPropertyChanged
        {
       // public string name { get; set; }
        private ObservableCollection<string> _Workes = new ObservableCollection<string>();

        public ObservableCollection<string> Workes
        {
            get => _Workes;
            set
            {
                _Workes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Workes)));
            }
        }
        #region*** Список имен
           string TextWork = "Воеводина Екатерина Владимировна;" +
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
        
       
        public void generate()
        {
            var component = TextWork.Split(';');
            foreach (var item in component)
            {
                Workes.Add(item);
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

       // public override string ToString() => name;

    }


       
}
  


