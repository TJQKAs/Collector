using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmApp
{    // интерфйес и три метода 
    public interface IDetailService
    {// изначальная коллекция 
        ObservableCollection<Detail> GetInitialData();
        // для открытия файла json 
        ObservableCollection<Detail> OpenData(string filename);
       // для сохранения файла  json
        void SaveData(string filename, ObservableCollection<Detail> detailsList);
    }
}
