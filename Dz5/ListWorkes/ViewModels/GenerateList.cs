using System.Collections.ObjectModel;

namespace ListWorkes.ViewModels
{
    
      
        
            public static class GenerateList
            {
                public static void generate(ref ObservableCollection<string> observableCollection,string txt)
                {
                    var component = txt.Split(';');
                    foreach (var item in component)
                    {
                        observableCollection.Add(item);
                    }
                }
               

            }
        }
   

