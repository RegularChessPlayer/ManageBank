using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Domain.Input;
using AtlanticoBank.Domain.Output;
using AtlanticoBank.Infrastructure.Data.Repository.Interfaces;
using AtlanticoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticoBank.Services.Services
{
    public class CaixaService : ICaixaService
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly IEstoqueCaixaRepository _estoqueCaixaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly int SaqueMax = 10000;

        public CaixaService(ICaixaRepository caixaRepository, IEstoqueCaixaRepository estoqueCaixaRepository, IUnitOfWork unitOfWork) {
            _caixaRepository = caixaRepository;
            _estoqueCaixaRepository = estoqueCaixaRepository;
            _unitOfWork = unitOfWork;
        }
       
        public async Task<IEnumerable<Caixa>> ListCaixaAsync()
        {
            return await _caixaRepository.ListAsync();
        }

        public async Task<CaixaResponse> SacarAsync(SaqueInput saqueInput)
        {

            try
            {

                var estoqueCaixas = await _estoqueCaixaRepository.ListAsync(saqueInput.CaixaId);

                var total = estoqueCaixas.Sum(ec => ec.Cedula * ec.Qtd);

                if (saqueInput.Valor > total) {
                    return new CaixaResponse("Quantidade em dinheiro no caixa inferior ao valor do saque!");
                }

                Dictionary<int, int> cedQtd = new Dictionary<int, int>();

                foreach (var ec in estoqueCaixas) {
                    cedQtd.Add(ec.Cedula, ec.Qtd);
                }

                var dictSaque = ComputeSaque(cedQtd, saqueInput.Valor);

                foreach (var ec in estoqueCaixas) {
                    ec.Qtd -= dictSaque[ec.Cedula];
                }
                
                await _unitOfWork.CompleteAsync();
                var caixa = await _caixaRepository.FindByIdAsync(saqueInput.CaixaId);
                return new CaixaResponse(caixa);
            }
            catch (Exception ex) {
                return new CaixaResponse($"An error occurred on saque: {ex.Message}");     
            }

        }

        public async Task<CaixaResponse> SaveCaixaAsync(Caixa caixa)
        {
            try
            {

                await _caixaRepository.AddAsync(caixa);
                await _unitOfWork.CompleteAsync();

                return new CaixaResponse(caixa);
            }
            catch (Exception e)
            {
                return new CaixaResponse($"An error occurred when saving : {e.Message} ");
            }

        }

        public async Task<CaixaResponse> UpdateCaixaAsync(long id, CaixaInput caixaInput)
        {
            var existingCaixa = await _caixaRepository.FindByIdAsync(id);

            if (existingCaixa == null)
                return new CaixaResponse("Friend not found");

            existingCaixa.Active = caixaInput.Status;

            try
            {

                _caixaRepository.Update(existingCaixa);
                await _unitOfWork.CompleteAsync();

                return new CaixaResponse(existingCaixa);
            }
            catch (Exception ex)
            {
                return new CaixaResponse($"An error occurred when updating : {ex.Message}");
            }

        }

        public async Task<CaixaResponse> DeleteCaixaAsync(long id)
        {
            var existingCaixa = await _caixaRepository.FindByIdAsync(id);

            if (existingCaixa == null)
                return new CaixaResponse("Caixa not found");

            try
            {
                _caixaRepository.Remove(existingCaixa);
                await _unitOfWork.CompleteAsync();

                return new CaixaResponse(existingCaixa);
            }
            catch (Exception ex)
            {
                return new CaixaResponse($"An error occurred when deleting : {ex.Message}");
            }

        }

        private Dictionary<int, int> ComputeSaque(Dictionary<int, int> cedQtd, int valorSaque) {

            Dictionary<int, int> cedQtdResult = new Dictionary<int, int>(cedQtd);
            
            foreach (var entry in cedQtd)
            {
                cedQtdResult[entry.Key] = valorSaque / entry.Key;
                valorSaque = valorSaque % entry.Key;
            }
            
            return cedQtdResult;
        }


    }
}
