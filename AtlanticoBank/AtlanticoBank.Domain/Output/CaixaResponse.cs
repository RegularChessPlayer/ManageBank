using AtlanticoBank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticoBank.Domain.Output
{
    public class CaixaResponse : BaseResponse
    {
        public Caixa Caixa { get; private set; }

        public CaixaResponse(bool success, string message, Caixa caixa) : base(success, message)
        {
            Caixa = caixa;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="caixa">Saved friend.</param>
        /// <returns>Response.</returns>
        public CaixaResponse(Caixa caixa) : this(true, string.Empty, caixa)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CaixaResponse(string message) : this(false, message, null)
        { }

    }
}
