using System;
using System.Collections.Generic;

namespace RepairExam
{
    public partial class Клиент
    {
        public Клиент()
        {
            Заявкаs = new HashSet<Заявка>();
        }

        public int Ун { get; set; }
        public string? Фио { get; set; }
        public string? Телефон { get; set; }

        public virtual ICollection<Заявка> Заявкаs { get; set; }
    }
}
