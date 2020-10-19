using Saga.Poc.Saga.Fin.App.Requests;
using System.Threading.Tasks;

namespace Saga.Poc.Saga.Fin.App.Interfaces
{
    public interface IBuyCattleService
    {
        Task BuyCattleRegisterNew(BuyCattleRegisterNewRequest request);
    }
}
