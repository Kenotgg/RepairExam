using System;
using System.Collections.Generic;

namespace RepairExam
{
    public partial class Исполнитель
    {
        public Исполнитель()
        {
            Ремонтs = new HashSet<Ремонт>();
        }

        public int Ун { get; set; }
        public string? Фио { get; set; }
        public string? Телефон { get; set; }
        public string? Инн { get; set; }
        public string? Паспорт { get; set; }

        public virtual ICollection<Ремонт> Ремонтs { get; set; }
    }
}
