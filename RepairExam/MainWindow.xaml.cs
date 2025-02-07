using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RepairExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Scaffold - DbContext "Server=DESKTOP-932LPHA\\SQLEXPRESS;Database=RepairService;Trusted_Connection=False;" Microsoft.EntityFrameworkCore.SqlServer
            //Scaffold-DbContext "Server=DESKTOP-932LPHA\SQLEXPRESS;Database=RepairService;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer

            using (RepairServiceContext db = new RepairServiceContext())
            {
                
               
                
            }
            
        }
    }
}