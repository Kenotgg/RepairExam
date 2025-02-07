using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для AddRequest.xaml
    /// </summary>
    public partial class AddRequest : Page
    {
        public AddRequest()
        {
            InitializeComponent();
        }

        private void AppendChanges(object sender, RoutedEventArgs e)
        {
            using (RepairServiceContext db = new RepairServiceContext())
            {
                Клиент клиент = new Клиент {Фио = NameBox.Text, Телефон = PhoneBox.Text };
                db.Клиентs.Add(клиент);
                db.SaveChanges();
            Заявка заявка = new Заявка { Статус = "в работе", ДатаПодачи = DateTime.Now,Отправитель = клиент.Ун};
                db.Заявкаs.Add(заявка);
                db.SaveChanges();
                Ремонт ремонт = new Ремонт { Заявка = заявка.Ун, Исполнитель = 1, Коментарий = "ух" };
                db.Ремонтs.Add(ремонт);
                db.SaveChanges();
            }
               
        }
    }
}
