using System;
using System.Collections.Generic;

namespace RepairExam
{
    public partial class Заявка
    {
        public Заявка()
        {
            Ремонтs = new HashSet<Ремонт>();
        }

        public int Ун { get; set; }
        public string? Статус { get; set; }
        public int? Отправитель { get; set; }
        public DateTime? ДатаПодачи { get; set; }
        public DateTime? ДатаВыполнения { get; set; }
        public string? Оборудование {  get; set; }
        public virtual Клиент? ОтправительNavigation { get; set; }
        public virtual ICollection<Ремонт> Ремонтs { get; set; }
    }
}
