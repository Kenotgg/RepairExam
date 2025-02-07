using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            using (RepairServiceContext db = new RepairServiceContext())
            {
                
                var requests = from request in db.Заявкаs
                               join client in db.Клиентs on request.Отправитель equals client.Ун
                               join repair in db.Ремонтs on request.Ун equals repair.Заявка
                               join master in db.Исполнительs on repair.Исполнитель equals master.Ун
                               select new
                               {
                                   RequestId = request.Ун,
                                   Name = client.Фио,
                                   Comment = repair.Коментарий,
                                   Master = master.Фио,
                                   Start = request.ДатаПодачи,
                                   End = request.ДатаВыполнения,
                                   Equipment = request.Оборудование
                                   //Name = client.Фио,


                               };

                // 2. Группировка по ID заявки
                var groupedRequests = requests.GroupBy(r => r.RequestId)
                    .Select(group => new
                    {
                        RequestId = group.Key,
                        ClientName = group.First().Name, // Берем имя клиента из первой записи
                        MasterNames = string.Join(", ", group.Select(r => r.Master)), // Объединяем имена мастеров в строку
                        Comments = string.Join(", ", group.Select(r => r.Comment)), // Объединяем комментарии в строку
                        Start = group.First().Start, // Начальная дата
                        End = group.First().End, // Конечная дата

                    }).ToList();

                // 3. Преобразование в список строк для ListBox
                List<string> listBoxItems = groupedRequests.Select(g => $"Заявка: {g.RequestId}, Клиент: {g.ClientName}, Мастера: {g.MasterNames}, Комментарии: {g.Comments}").ToList();
                MainListbox.ItemsSource = listBoxItems;

            }
                
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void GoToCreate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(PageController.AddRequest, UriKind.Relative);
        }
        
    }
}
