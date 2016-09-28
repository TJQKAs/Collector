using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Globalization;
using MvvmApp;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32;

namespace MvvmApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // выход
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


    public class ToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //selected по умолчанию null, 
            var detail = value as Detail;
            if (detail == null)
                return false;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class ToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //selected по умолчанию null, 
            var detailType = (DetailTypes) value;
            var result = "/Images/nothing.png";
            switch (detailType)
            {
                case DetailTypes.Band:
                    result = "/Images/braclet.jpg";
                    break;
                case DetailTypes.Drill:
                    result = "/Images/sverlo.jpg";
                    break;
                case DetailTypes.Gear:
                    result = "/Images/gear.jpg";
                    break;
                case DetailTypes.Tool:
                    result = "/Images/instrument.jpg";
                    break;
                default:
                    break;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class MyEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumVal = value as Enum;
            if (enumVal == null)
                return "";
            return enumVal.GetDescriptionFromEnumValue();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public static class EnumExtensions
    {
        public static string GetDescriptionFromEnumValue(this Enum value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .SingleOrDefault() as DisplayAttribute;
            return attribute == null ? value.ToString() : attribute.Name;
        }
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}

