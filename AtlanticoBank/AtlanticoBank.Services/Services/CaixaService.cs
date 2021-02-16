using AtlanticoBank.Domain.Entities;
using AtlanticoBank.Domain.Output;
using AtlanticoBank.Infrastructure.Data.Repository.Interfaces;
using AtlanticoBank.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticoBank.Services.Services
{
    public class CaixaService : ICaixaService
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CaixaService(ICaixaRepository caixaRepository, IUnitOfWork unitOfWork) {
            _caixaRepository = caixaRepository;
            _unitOfWork = unitOfWork;
        }
       
        public async Task<IEnumerable<Caixa>> ListCaixaAsync()
        {
            return await _caixaRepository.ListAsync();
        }

        public Task<IEnumerable<Caixa>> SacarAsync(int value)
        {
            throw new NotImplementedException();
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

        public async Task<CaixaResponse> UpdateCaixaAsync(long id, Caixa caixa)
        {
            var existingCaixa = await _caixaRepository.FindByIdAsync(id);

            if (existingCaixa == null)
                return new CaixaResponse("Friend not found");

            //existingCaixa.Name = friendInput.Name;

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

    }
}
