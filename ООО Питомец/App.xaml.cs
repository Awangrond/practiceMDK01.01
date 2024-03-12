using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ООО_Питомец.Model;

namespace ООО_Питомец
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Model.PetShopDB DB;

        public static Model.Users usersHelp { get; set; }
        public static Model.Products productsHelp { get; set; }

        
    }
}
