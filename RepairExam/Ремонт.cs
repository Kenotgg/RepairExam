using System;
using System.Collections.Generic;

namespace RepairExam
{
    public partial class Ремонт
    {
        public int Ун { get; set; }
        public int? Заявка { get; set; }
        public int? Исполнитель { get; set; }
        public string? Коментарий { get; set; }

        public virtual Заявка? ЗаявкаNavigation { get; set; }
        public virtual Исполнитель? ИсполнительNavigation { get; set; }
    }
}
