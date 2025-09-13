using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSEG.BankAccount.Models
{
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public IAccountState State { get; set; }

        public BankAccount(decimal initialBalance)
        {
                Balance = initialBalance;
                State = new ActiveState();
        }

        public void ChangeBalance(decimal balance) { 
           Balance+= balance;
        }

        public void ChangeState(IAccountState state) {
            State = state;
        }

        public void Deposit(decimal amount)
        {
            State.Deposite(this, amount);
        }

        public void Withdraw(decimal amount)
        {
            State.Withdraw(this, amount);
        }
        public void Close()
        {
            State.Close(this);
        }

    }
}
