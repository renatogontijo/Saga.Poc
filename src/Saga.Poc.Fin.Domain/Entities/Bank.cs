using Saga.Poc.Saga.Fin.Domain.Validations;

namespace Saga.Poc.Saga.Fin.Domain.Entities
{
    public class Bank : BaseEntity<Bank>
    {
        protected Bank() :
            base(new BankValidation())
        {
        }

        public Bank(int number, string name) :
            this()
        {
            Number = number;
            Name = name;

            Validate(this);
        }

        public int Number { get; private set; }

        public string Name { get; private set; }
    }
}
