using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticoBank.Domain.Entities
{
    public class EstoqueCaixa : BaseEntity<long>
    {
        public int Cedula { get; set; }
        public int Qtd { get; set; }
        public long CaixaId { get; set; }
        public Caixa Caixa { get; set; }

    }
}
