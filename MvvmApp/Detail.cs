using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace MvvmApp
{

    [DataContract]
    public class Detail : INotifyPropertyChanged
    {
        private string name; // название
        private DetailMaterials material;
        private DetailTypes type;
        private int width; // толщина
        private string code; // код детали
        private string imageFile;

        private ObservableCollection<string> files;
        //public ObservableCollection<string> Files { get; set; }
        // создаем новую коллекцию для сопутствующих файлов
        public Detail()
        {
            Files = new ObservableCollection<string>();
        }

        [DataMember]
        public ObservableCollection<string> Files
        {
            get { return files; }
            set
            { 
                files = value;
                OnPropertyChanged("Files");
            }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        [DataMember]
        public DetailMaterials Material
        {
            get { return material; }
            set
            {
                material = value;
                OnPropertyChanged("Material");
            }
        }
        [DataMember]
        public DetailTypes Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        [DataMember]
        public string ImageFile
        {
            get { return imageFile; }
            set
            {
                imageFile = value;
                OnPropertyChanged("Image");
            }
        }
        [DataMember]
        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }
        [DataMember]
        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged("Width");
            }
        }  // толщина

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public enum DetailMaterials // материал изделия
    {
        [Display(Name = "")]
        Nothing,
        [Display(Name = "Железо")]
        Iron,
        [Display(Name = "Нержавейка")]
        Steel,
        [Display(Name = "Керамика")]
        Ceramics,
        [Display(Name = "Резина")]
        Rubber
    }

    public enum DetailTypes // тип изделия
    {
        [Display(Name = "")]
        Nothing,
        [Display(Name = "Сверло")]
        Drill,
        [Display(Name = "Инструмент")]
        Tool,
        [Display(Name = "Браслет")]
        Band,
        [Display(Name = "Шестеренки")]
        Gear
    }
}

//--------------------------------------------------------------------------//


//    [DataContract]    
//        public class Detail : ViewModelBase
//    {

//        /// <summary>
//        /// The <see cref="Name" /> property's name.
//        /// </summary>
//        public const string NamePropertyName = "Name";

//        private string _name;

//        /// <summary>
//        /// Sets and gets the Name property.
//        /// Changes to that property's value raise the PropertyChanged event. 
//        /// </summary>
//       [DataMember]
//        public string Name
//        {
//            get
//            {
//                return _name;
//            }

//            set
//            {
//                if (_name == value)
//                {
//                    return;
//                }

//                _name = value;
//                RaisePropertyChanged(NamePropertyName);
//            }
//        }

//        /// <summary>
//        /// The <see cref="Material" /> property's name.
//        /// </summary>
//        public const string MaterialPropertyName = "Material";

//        private DetailMaterials _material;

//        /// <summary>
//        /// Sets and gets the Material property.
//        /// Changes to that property's value raise the PropertyChanged event. 
//        /// </summary>
//        [DataMember]
//        public DetailMaterials Material
//        {
//            get
//            {
//                return _material;
//            }

//            set
//            {
//                if (_material == value)
//                {
//                    return;
//                }

//                _material = value;
//                RaisePropertyChanged(MaterialPropertyName);
//            }
//        }

//        /// <summary>
//        /// The <see cref="Type" /> property's name.
//        /// </summary>
//        public const string TypePropertyName = "Type";

//        private DetailTypes _type;

//        /// <summary>
//        /// Sets and gets the Type property.
//        /// Changes to that property's value raise the PropertyChanged event. 
//        /// </summary>
//        [DataMember]
//        public DetailTypes Type
//        {
//            get
//            {
//                return _type;
//            }

//            set
//            {
//                if (_type == value)
//                {
//                    return;
//                }

//                _type = value;
//                RaisePropertyChanged(TypePropertyName);
//            }
//        }


//        /// <summary>
//        /// The <see cref="Width" /> property's name.
//        /// </summary>
//        public const string WidthPropertyName = "Width";

//        private int _width;

//        /// <summary>
//        /// Sets and gets the Width property.
//        /// Changes to that property's value raise the PropertyChanged event. 
//        /// </summary>
//        [DataMember]
//        public int Width
//        {
//            get
//            {
//                return _width;
//            }

//            set
//            {
//                if (_width == value)
//                {
//                    return;
//                }

//                _width = value;
//                RaisePropertyChanged(WidthPropertyName);
//            }
//        }

//        public Detail()
//        {
//            Files = new ObservableCollection<string>();
//        }


//        /// <summary>
//        /// The <see cref="Files" /> property's name.
//        /// </summary>
//        public const string FilesPropertyName = "Files";


//        private ObservableCollection<string> _files;

//        /// <summary>
//        /// Sets and gets the Files property.
//        /// Changes to that property's value raise the PropertyChanged event. 
//        /// </summary>
//        [DataMember]
//        public ObservableCollection<string> Files
//        {
//            get
//            {
//                return _files;
//            }

//            set
//            {
//                if (_files == value)
//                {
//                    return;
//                }

//                _files = value;
//                RaisePropertyChanged(FilesPropertyName);
//            }
//        }

//        /// <summary>
//        /// The <see cref="Code" /> property's name.
//        /// </summary>
//        public const string CodePropertyName = "Code";

//        private string _code;

//        /// <summary>
//        /// Sets and gets the Code property.
//        /// Changes to that property's value raise the PropertyChanged event. 
//        /// </summary>
//        [DataMember]
//        public string Code
//        {
//            get
//            {
//                return _code;
//            }

//            set
//            {
//                if (_code == value)
//                {
//                    return;
//                }

//                _code = value;
//                RaisePropertyChanged(CodePropertyName);
//            }
//        }

//        /// <summary>
//            /// The <see cref="ImageFile" /> property's name.
//            /// </summary>
//        public const string ImageFilePropertyName = "ImageFile";

//        private string _imageFile;

//        /// <summary>
//        /// Sets and gets the ImageFile property.
//        /// Changes to that property's value raise the PropertyChanged event. 
//        /// </summary>
//        [DataMember]
//        public string ImageFile
//        {
//            get
//            {
//                return _imageFile;
//            }

//            set
//            {
//                if (_imageFile == value)
//                {
//                    return;
//                }

//                _imageFile = value;
//                RaisePropertyChanged(ImageFilePropertyName);
//            }
//        }
//    }


//    public enum DetailMaterials // материал изделия
//    {
//        [Display(Name = "")]
//        Nothing,
//        [Display(Name = "Железо")]
//        Iron,
//        [Display(Name = "Нержавейка")]
//        Steel,
//        [Display(Name = "Керамика")]
//        Ceramics,
//        [Display(Name = "Резина")]
//        Rubber
//    }

//    public enum DetailTypes // тип изделия
//    {
//        [Display(Name = "")]
//        Nothing,
//        [Display(Name = "Сверло")]
//        Drill,
//        [Display(Name = "Инструмент")]
//        Tool,
//        [Display(Name = "Браслет")]
//        Band,
//        [Display(Name = "Шестеренки")]
//        Gear
//    }





//}
