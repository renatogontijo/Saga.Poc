using Saga.Poc.Saga.Fin.App.Commands;
using Saga.Poc.Saga.Fin.App.Interfaces;
using Saga.Poc.Saga.Fin.App.Requests;
using Saga.Poc.Saga.Fin.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Infra.Bus.Handler;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.App.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBusHandler _bus;
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(IBusHandler bus,
            IBankAccountRepository bankAccountRepository)
        {
            _bus = bus;
            _bankAccountRepository = bankAccountRepository;
        }

        public async Task CreateNewBankAccount(CreateBankAccountRequest request)
        {
            var command = new CreateNewBankAccountCommand(request.BankId,
                request.AccountNumber, request.CustomerName, request.InitialBalance);
            await _bus.SendCommand(command);
        }
    }
}
