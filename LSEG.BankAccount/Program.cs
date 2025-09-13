// See https://aka.ms/new-console-template for more information
using LSEG.BankAccount.Models;

var account = new BankAccount(100);

account.Withdraw(50);   // Active
account.Withdraw(100);  // Goes Overdrawn
account.Deposit(70);    // Back to Active
account.Withdraw(120);  // Overdrawn again
account.Deposit(50);    // Still overdrawn
account.Deposit(100);   // Back to Active
account.Withdraw(150);  // Overdrawn again
account.Deposit(200);   // Back to Active
account.Withdraw(250);  // Overdrawn again
account.Deposit(250);   // Back to Active
account.Withdraw(50);   // Active
account.Withdraw(200);  // Overdrawn
account.Deposit(200);   // Active again
account.Withdraw(300);  // Overdrawn
account.Deposit(500);   // Active
account.Withdraw(500);  // Balance 0
account.Close();        // Closed
account.Deposit(100);   // Not allowed
