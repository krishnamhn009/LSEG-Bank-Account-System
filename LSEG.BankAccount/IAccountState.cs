using LSEG.BankAccount.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSEG.BankAccount
{
    public interface IAccountState
    {
        void Deposite(LSEG.BankAccount.Models.BankAccount bankAccount, decimal amount);
        void Withdraw(LSEG.BankAccount.Models.BankAccount bankAccount, decimal amount);
        void Close(LSEG.BankAccount.Models.BankAccount bankAccount);
    }

    public class ActiveState : IAccountState
    {
       
        public void Close(Models.BankAccount bankAccount)
        {
            if (bankAccount.Balance < 0)
            {
                Console.WriteLine("Account is Overdrawn, No Close allowed");
                return;
            }
           if(bankAccount.Balance > 0)
            {
                Console.WriteLine("Account is Active, No Close allowed");
                return;
            }
            bankAccount.State = new ClosedState();
            Console.WriteLine("Account is now Closed");
        }

       
        public void Deposite(Models.BankAccount bankAccount, decimal amount)
        {
            bankAccount.ChangeBalance(amount);
            Console.WriteLine($"Deposited {amount}" + $" balance is {bankAccount.Balance}" );
        }

       
        public void Withdraw(Models.BankAccount bankAccount, decimal amount)
        {
            bankAccount.ChangeBalance(-amount);
            Console.WriteLine($"Withdrew {amount}" + $" balance is {bankAccount.Balance}");
            if (bankAccount.Balance < 0)
            {
                bankAccount.State = new OverdrawnState();
                Console.WriteLine("Account is now Overdrawn");
            }
        }
    }

    public class OverdrawnState : IAccountState
    {
        public void Close(Models.BankAccount bankAccount)
        {
            Console.WriteLine("Account is already Overdrawn, No Close allowed");
        }
        public void Deposite(Models.BankAccount bankAccount, decimal amount)
        {
            bankAccount.ChangeBalance(amount);
            Console.WriteLine($"Deposited {amount}" + $" balance is {bankAccount.Balance}");
            if (bankAccount.Balance >=0)
            {
                bankAccount.State = new ActiveState();
                Console.WriteLine("Account is now Active");
            }
        }
        public void Withdraw(Models.BankAccount bankAccount, decimal amount)
        {
            Console.WriteLine("Account is already Overdrawn, No Withdrawal allowed");
        }
    }

    public class ClosedState : IAccountState
    {
        public void Close(Models.BankAccount bankAccount)
        {
            Console.WriteLine("Account is already closed");
        }

        public void Deposite(Models.BankAccount bankAccount, decimal amount)
        {
            Console.WriteLine("Account is already closed, No Deposite allowed");
        }

        public void Withdraw(Models.BankAccount bankAccount, decimal amount)
        {
         Console.WriteLine("Account is already closed, No Withdrawal allowed");
        }
    }

    public class FrozenState : IAccountState
    {
        public void Close(Models.BankAccount bankAccount)
        {
            Console.WriteLine("Account is Frozen, No Close allowed");
        }
        public void Deposite(Models.BankAccount bankAccount, decimal amount)
        {
            bankAccount.ChangeBalance(amount);
            if (bankAccount.Balance >= 0)
            {
                bankAccount.State = new ActiveState();
                Console.WriteLine("Account is now Active");
            }
        }
        public void Withdraw(Models.BankAccount bankAccount, decimal amount)
        {
            Console.WriteLine("Account is Frozen, No Withdrawal allowed");
        }
    }
}
