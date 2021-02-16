using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AtlanticoBank.Domain.Entities
{
    public class EstoqueCaixa : BaseEntity<long>
    {
        public int Cedula { get; set; }
        public int Qtd { get; set; }
        public long CaixaId { get; set; }
        
        [JsonIgnore]
        public Caixa Caixa { get; set; }

    }
}
