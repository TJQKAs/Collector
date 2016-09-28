using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using GalaSoft.MvvmLight;
using System.Windows;
using GalaSoft.MvvmLight.CommandWpf;
using System.Globalization;

namespace MvvmApp
{
 


    public class DetailsViewModel : INotifyPropertyChanged
    {
        IDetailService dataService;
        IDialogService dialogService;
        private ObservableCollection<string> operation;
      

        public DetailsViewModel()
        {
            dataService = new DefaultDetailService();
            dialogService = new DialogService();
            Details = dataService.GetInitialData();
            Operation = new ObservableCollection<string>();

            


        }
        public DetailsViewModel(IDetailService dataService, IDialogService dialogService)
        {
            this.dataService = dataService;
            this.dialogService = dialogService;
        }
        private Detail selectedDetail;

        public Detail SelectedDetail
        {
            get { return selectedDetail; }
            set { selectedDetail = value;
                this.TextboxEnabled = true;
                OnPropertyChanged("SelectedDetail"); }
        }



 //--------------------------------------------------------------------------
        public static string timenow() {

            DateTime localDate = DateTime.Now;
            string cultureNames = "ru-RU";
            var culture = new CultureInfo(cultureNames);
            string timenow1 = " : " + localDate.ToString(culture) + ";";
            return timenow1;
    }
//------------------------------------------------------------

        public ObservableCollection<string> Operation
        {
            get { return operation; }
            set
            {
                operation = value;
                OnPropertyChanged("Operation");
            }
        }

 //---------------------------------------------------------

 //---------------------------------------------------------
        private Boolean _textbox_enabled;
        public Boolean TextboxEnabled 
        {
            get { return _textbox_enabled; }
            set
            {
                _textbox_enabled = value;
                OnPropertyChanged("TextboxEnabled");
            }
        }
//-----------------------------------------------

        private RelayCommand<Detail> _addCommand;

        /// <summary>
        /// Gets the AddCommand.
        /// </summary>
        public RelayCommand<Detail> AddCommand
        {
            get
            {
                return _addCommand
                    ?? (_addCommand = new RelayCommand<Detail>(
                    detail =>
                    {
                    try
                        {
                            Detail newDetail = new Detail();
                            Details.Insert(0, newDetail);
                            SelectedDetail = newDetail;
                            Operation.Add((Operation.Count+1).ToString() + " Новая деталь " + " добавлена  " + timenow());
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }
       
        private RelayCommand<Detail> _removeCommand;

        /// <summary>
        /// Gets the RemoveCommand.
        /// </summary>
        public RelayCommand<Detail> RemoveCommand
        {
            get
            {
                return _removeCommand
                    ?? (_removeCommand = new RelayCommand<Detail>(
                    detail =>
                    {
                    try
                        {
                            Detail detail1 = detail as Detail;
                            if (detail1 != null)
                            {
                                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Подтверждаете удаление детали?","", System.Windows.MessageBoxButton.YesNo);
                                if (messageBoxResult == MessageBoxResult.Yes)
                                {
                                    Operation.Add((Operation.Count + 1).ToString() + " Деталь " + detail1.Name + " удалена " + timenow());
                                    Details.Remove(detail1);
                                    this.TextboxEnabled = false;
                                }
                                //dialogService.ShowMessage("Объект удален");
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }
        private RelayCommand _openCommand;

        /// <summary>
        /// Gets the OpenCommand.
        /// </summary>
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand
                    ?? (_openCommand = new RelayCommand(
                    () =>
                    {
                    try
                        {
                            if (dialogService.OpenFileDialog() == true)
                            {
                                Details = dataService.OpenData(dialogService.FilePath);
                                Operation.Add((Operation.Count+1).ToString() + " Файл открыт: " + dialogService.FilePath + "; " + timenow());
                                dialogService.ShowMessage("Файл открыт");
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommand _addFileCommand;

        /// <summary>
        /// Gets the AddFileCommand.
        /// </summary>
        public RelayCommand AddFileCommand
        {
            get
            {
                return _addFileCommand
                    ?? (_addFileCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            if (dialogService.OpenFileDialog() == true)
                            {
                                if (SelectedDetail != null)
                                {
                                    string xname = dialogService.FilePath;
                                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(xname);
                                    SelectedDetail.Files.Add(fileNameWithoutExtension);
                                    Operation.Add((Operation.Count+1).ToString() + " К Детале " + SelectedDetail.Name + " добавлен сопутствующий файл: " + fileNameWithoutExtension + "  " + timenow());
                                    //SelectedDetail.Files.Add(dialogService.FilePath);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }
               ));
            }
        }

        //------------------------------------------------------------------

        private RelayCommand _removeFileCommand;

        /// <summary>
        /// Gets the RemoveFileCommand.
        /// </summary>
        public RelayCommand RemoveFileCommand
        {
            get
            {
                return _removeFileCommand
                    ?? (_removeFileCommand = new RelayCommand(
                    () =>
                    {
                    try
                        {
                            if (SelectedDetail != null && SelectedDetail.Files.Count > 0)
                            {
                                SelectedDetail.Files.Remove(selectedFile);
                                Operation.Add((Operation.Count+1).ToString() + " У Детали " + SelectedDetail.Name + " удален сопутствующий файл :" + SelectedFile + "   " + timenow());
                                //dialogService.ShowMessage("Объект удален");
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }

        private RelayCommand _saveCommand;

        /// <summary>
        /// Gets the SaveCommand.
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand
                    ?? (_saveCommand = new RelayCommand(
                    () =>
                    {
                    try
                        {

                            if (dialogService.SaveFileDialog() == true)
                            {
                                dataService.SaveData(dialogService.FilePath, Details);
                                Operation.Add((Operation.Count+1).ToString() + " Файл сохранен: " + dialogService.FilePath + "; " + timenow());
                                dialogService.ShowMessage("Файл сохранен");
                            }
                        }
                        catch (Exception ex)
                        {
                            dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }

        ObservableCollection<Detail> details;
        private string selectedFile;
 

        public string SelectedFile { get { return selectedFile; }
                                     set { selectedFile = value;
                OnPropertyChanged("SelectedFile");
            } }

        public ObservableCollection<Detail> Details
        {
            get { return details; }
            private set
            {
                details = value;
                OnPropertyChanged("Details");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
