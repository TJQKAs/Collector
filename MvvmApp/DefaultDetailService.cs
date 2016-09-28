using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace MvvmApp
{
    public class DefaultDetailService : IDetailService
    {
        public ObservableCollection<Detail> GetInitialData()
        {
            return new ObservableCollection<Detail>
            {
                 new Detail { Code="111", ImageFile="/Images/braclet.jpg", Material = DetailMaterials.Rubber, Name="СуперБраслет", Type= DetailTypes.Band, Width=11},
                     new Detail { Code="222", ImageFile="/Images/gear.jpg", Material = DetailMaterials.Iron, Name="GEAR Pro", Type= DetailTypes.Gear, Width=12 },
                     new Detail { Code="134", ImageFile="/Images/instrument.jpg", Material = DetailMaterials.Ceramics, Name="Tools Comp", Type= DetailTypes.Tool, Width=11 },
                    new Detail { Code="564", ImageFile="/Images/sverlo.jpg", Material = DetailMaterials.Steel, Name="Электродрель", Type= DetailTypes.Drill, Width=15 },
                    new Detail { Code="143", ImageFile="/Images/braclet.jpg", Material = DetailMaterials.Rubber, Name="БраслетЭкст 34", Type= DetailTypes.Band, Width=11 }

             };
        }

        public ObservableCollection<Detail> OpenData(string fileName)
        {
            ObservableCollection<Detail> result = new ObservableCollection<Detail>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Detail>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                result = (ObservableCollection<Detail>)jsonFormatter.ReadObject(fs);
            }

            return result;
        }

        public void SaveData(string filename, ObservableCollection<Detail> detailsList)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ObservableCollection<Detail>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, detailsList);
            }
        }
    }
}
