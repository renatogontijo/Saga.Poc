using Saga.Poc.Saga.Core.Events;
using Saga.Poc.Saga.Infra.Bus.Handler;
using Saga.Poc.Saga.Infra.Bus.Rebus;
using Saga.Poc.Saga.Infra.Bus.Rebus.Notifications;
using Saga.Poc.Saga.Infra.Data.UnitOfWork;
using Saga.Poc.Saga.Zoo.App.Commands;
using Saga.Poc.Saga.Zoo.Domain.Interfaces.Repositories;
using Saga.Poc.Saga.Zoo.Domain.Interfaces.Services;
using Rebus.Handlers;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Zoo.App.CommandHandlers
{
    public class DailyExtractLotHandler : CommandHandler,
        IHandleMessages<CreateNewDailyExtractLotCommand>,
        IHandleMessages<UpdateDailyExtractLotCommand>
    {
        private readonly IDailyExtractLotCreateDomainService _dailyExtractLotCreateDomainService;
        private readonly IDailyExtractLotRepository _dailyExtractLotRepository;

        public DailyExtractLotHandler(IBusHandler bus,
            IHandleMessages<DomainNotification> notifications,
            IUoW uow,
            IDailyExtractLotCreateDomainService dailyExtractLotCreateDomainService,
            IDailyExtractLotRepository dailyExtractLotRepository) :
            base(bus, notifications, uow)
        {
            _dailyExtractLotCreateDomainService = dailyExtractLotCreateDomainService;
            _dailyExtractLotRepository = dailyExtractLotRepository;
        }

        public async Task Handle(CreateNewDailyExtractLotCommand message)
        {
            var createObj = await _dailyExtractLotCreateDomainService
                .CreateNewDailyExtractLot(message.Name, message.ManamementCategoryId, message.HeadsAmount);

            var dailyExtractLot = createObj.Item1;
            var isNewDailyExtractLot = createObj.Item2;

            var result = await _uow.SaveChangesAsync();

            if (isNewDailyExtractLot)
                await _bus.RaiseIntegrationEvent(new CreatedDailyExtractLotEvent(message.AggregateId, dailyExtractLot.Id));
            else
                await _bus.RaiseIntegrationEvent(new UpdatedDailyExtractLotEvent(message.AggregateId, dailyExtractLot.Id, dailyExtractLot.ManagementCategoryId, dailyExtractLot.HeadsAmount));
        }

        public async Task Handle(UpdateDailyExtractLotCommand message)
        {
            var result = false;

            var dailyExtractLot = await _dailyExtractLotRepository.GetById(message.DailyExtractLotId);
            if (dailyExtractLot != null)
            {
                if (dailyExtractLot.Name != message.Name)
                    dailyExtractLot.ChangeName(message.Name);

                if (dailyExtractLot.ManagementCategoryId != message.ManamementCategoryId)
                {
                    var managementCategory = await _dailyExtractLotRepository.GetManagementCategoryById(message.ManamementCategoryId);
                    dailyExtractLot.ChangeManagementCategory(managementCategory);
                }

                if (!dailyExtractLot.IsValid())
                {
                    var messageType = message.GetType().Name;
                    foreach (var error in dailyExtractLot.ValidationResult.Errors)
                        await NotifyError(messageType, error.ErrorMessage);
                }
                else
                {
                    _dailyExtractLotRepository.Update(dailyExtractLot);

                    result = await _uow.SaveChangesAsync();

                    if (result)
                        await _bus.RaiseIntegrationEvent(new UpdatedDailyExtractLotEvent(message.AggregateId, dailyExtractLot.Id, dailyExtractLot.ManagementCategoryId, dailyExtractLot.HeadsAmount));
                }
            }
        }
    }
}
