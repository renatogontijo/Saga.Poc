using Saga.Poc.Saga.Core.Events;
using Saga.Poc.Saga.Fin.App.Commands;
using Saga.Poc.Saga.Fin.App.Commands.Saga;
using Saga.Poc.Saga.Fin.App.Events;
using Saga.Poc.Saga.Fin.App.Saga.Data;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Rebus.Handlers;
using Rebus.Sagas;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.App.Saga.Workflows
{
    public class SagaBuyWorkflow : Saga<SagaBuyWorkflowData>,
        IAmInitiatedBy<BuyRegisterSagaCommand>,
        IHandleMessages<BuyFailedEvent>,
        IHandleMessages<BuyRegisteredEvent>,
        IHandleMessages<UpdateBankAccountBanlanceFailedEvent>,
        IHandleMessages<UpdatedBankAccountBalanceEvent>,
        IHandleMessages<CreatedDailyExtractLotEvent>,
        IHandleMessages<UpdatedDailyExtractLotEvent>
    {
        private readonly IBusHandler _bus;

        public SagaBuyWorkflow(IBusHandler bus)
        {
            _bus = bus;
        }

        public async Task Handle(BuyRegisterSagaCommand message)
        {
            Data.BankId = message.BankId;
            Data.AccountNumber = message.AccountNumber;
            Data.BuyDate = message.BuyDate;
            Data.BuyValue = message.BuyValue;

            var command = new BuyRegisterNewCommand(message.AggregateId, message.SupplierName, message.BuyDate, message.BuyValue,
                message.BankId, message.AccountNumber, message.ManagementCategoryId, message.PurchasedHeads);
            await _bus.SendCommand(command);

            await VerifyProcess();
        }

        public async Task Handle(BuyRegisteredEvent message)
        {
            Data.BuyRegistered = true;

            await RequestCreateDailyExtractLot(message);

            await VerifyProcess();
        }

        public async Task Handle(BuyFailedEvent message)
        {
            Data.BuyFailed = true;

            await VerifyProcess();
        }

        public async Task Handle(UpdateBankAccountBanlanceFailedEvent message)
        {
            Data.BankAccountUpdateFailed = true;

            await VerifyProcess();
        }

        public async Task Handle(UpdatedBankAccountBalanceEvent message)
        {
            Data.BankAccountUpdated = true;

            await VerifyProcess();
        }

        public async Task Handle(CreatedDailyExtractLotEvent message)
        {
            Data.DailyExtractLotRegisted = true;

            await UpdateBankBalance();

            await VerifyProcess();
        }

        public async Task Handle(UpdatedDailyExtractLotEvent message)
        {
            Data.DailyExtractLotRegisted = true;

            await UpdateBankBalance();

            await VerifyProcess();
        }

        protected override void CorrelateMessages(ICorrelationConfig<SagaBuyWorkflowData> config)
        {
            config.Correlate<BuyRegisterSagaCommand>(m => m.AggregateId, d => d.Id);
            config.Correlate<BuyRegisteredEvent>(m => m.AggregateId, d => d.Id);
            config.Correlate<BuyFailedEvent>(m => m.AggregateId, d => d.Id);
            config.Correlate<UpdateBankAccountBanlanceFailedEvent>(m => m.AggregateId, d => d.Id);
            config.Correlate<UpdatedBankAccountBalanceEvent>(m => m.AggregateId, d => d.Id);
            config.Correlate<CreatedDailyExtractLotEvent>(m => m.AggregateId, d => d.Id);
            config.Correlate<UpdatedDailyExtractLotEvent>(m => m.AggregateId, d => d.Id);
        }

        private async Task VerifyProcess()
        {
            await Task.Run(() =>
            {
                if (Data.Completed)
                    MarkAsComplete();
            });
        }

        private async Task UpdateBankBalance()
        {
            var cmdUpdateBalance = new UpdateBankAccountBalanceCommand(Data.Id, Data.BankId, Data.AccountNumber, Data.BuyValue);
            await _bus.SendCommand(cmdUpdateBalance);
        }

        private async Task RequestCreateDailyExtractLot(BuyRegisteredEvent buyEvent)
        {
            var iEvent = new CreateDailyExtractLotEvent(buyEvent.AggregateId, buyEvent.BuyCattleId,
                buyEvent.SupplierName, buyEvent.BuyDate, buyEvent.BuyValue, buyEvent.BankId, buyEvent.AccountNumber,
                buyEvent.ManagementCategoryId, buyEvent.PurchasedHeads);
            await _bus.RaiseIntegrationEvent(iEvent);
        }
    }
}
