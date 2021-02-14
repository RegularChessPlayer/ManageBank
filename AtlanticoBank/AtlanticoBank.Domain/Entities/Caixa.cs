using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticoBank.Domain.Entities
{
    public class Caixa : BaseEntity<long>
    {
        public string Name { get; set; }
        public bool? Active { get; set; }
        public ICollection<EstoqueCaixa> EstoqueCaixas { get; set; }
    }
}
