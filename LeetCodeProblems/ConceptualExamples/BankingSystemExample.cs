using BankingSystem.Models;
using BankingSystem.Repositories;
using BankingSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.Models
{

    //Here is a basic C# implementation of a debit banking system with functionality for account creation, deposits, withdrawals, and transfers.

    //This implementation follows Domain-Driven Design(DDD) principles with services, entities, and repositories.
    // Features Implemented

    // Create Account
    // Deposit Money
    // Withdraw Money
    // Transfer Funds
    // Log Transactions

    //    BankingSystem
    //│── Program.cs            (Entry point)
    //│── /Models(Contains domain models)
    //│    ├── Account.cs
    //│    ├── Transaction.cs
    //│── /Services(Business logic)
    //│    ├── AccountService.cs
    //│── /Repositories(Data storage simulation)
    //│    ├── AccountRepository.cs
    //│    ├── TransactionRepository.cs

    public class Account
    {
        public Guid AccountId { get; private set; }
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public Account(string name)
        {
            AccountId = Guid.NewGuid();
            Name = name;
            Balance = 0m;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Transactions.Add(new Transaction(AccountId, "Deposit", amount));
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > Balance) return false;  // Insufficient funds
            Balance -= amount;
            Transactions.Add(new Transaction(AccountId, "Withdraw", amount));
            return true;
        }

        public void Transfer(decimal amount, Account recipient)
        {
            if (Withdraw(amount)) // Deduct from sender
            {
                recipient.Deposit(amount); // Add to recipient
                Transactions.Add(new Transaction(AccountId, $"Transfer to {recipient.AccountId}", amount));
                recipient.Transactions.Add(new Transaction(recipient.AccountId, $"Transfer from {AccountId}", amount));
            }
        }
    }
}

namespace BankingSystem.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; private set; }
        public Guid AccountId { get; private set; }
        public string Type { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Timestamp { get; private set; }

        public Transaction(Guid accountId, string type, decimal amount)
        {
            TransactionId = Guid.NewGuid();
            AccountId = accountId;
            Type = type;
            Amount = amount;
            Timestamp = DateTime.UtcNow;
        }
    }
}

namespace BankingSystem.Repositories
{
    public class AccountRepository
    {
        private readonly List<Account> _accounts = new List<Account>();

        public void Add(Account account) => _accounts.Add(account);
        public Account GetById(Guid accountId) => _accounts.FirstOrDefault(a => a.AccountId == accountId);
        public List<Account> GetAll() => _accounts;
    }
}

namespace BankingSystem.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account CreateAccount(string name)
        {
            var account = new Account(name);
            _accountRepository.Add(account);
            return account;
        }

        public bool Deposit(Guid accountId, decimal amount)
        {
            var account = _accountRepository.GetById(accountId);
            if (account == null) return false;

            account.Deposit(amount);
            return true;
        }

        public bool Withdraw(Guid accountId, decimal amount)
        {
            var account = _accountRepository.GetById(accountId);
            if (account == null) return false;

            return account.Withdraw(amount);
        }

        public bool Transfer(Guid fromAccountId, Guid toAccountId, decimal amount)
        {
            var sender = _accountRepository.GetById(fromAccountId);
            var receiver = _accountRepository.GetById(toAccountId);

            if (sender == null || receiver == null) return false;
            if (sender.Balance < amount) return false; // Insufficient funds

            sender.Transfer(amount, receiver);
            return true;
        }

        public void ShowAccountDetails(Guid accountId)
        {
            var account = _accountRepository.GetById(accountId);
            if (account == null)
            {
                Console.WriteLine("Account not found.");
                return;
            }

            Console.WriteLine($"Account: {account.Name} | Balance: {account.Balance:C}");
            Console.WriteLine("Transactions:");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine($"{transaction.Timestamp} - {transaction.Type} - {transaction.Amount:C}");
            }
        }

        //Extra challenge, get account with largest transaction
        public Account GetAccountWithLargestTransaction()
        {
            Account largestTransactionAccount = null;
            decimal maxTransactionAmount = decimal.MinValue;

            foreach (var account in _accountRepository.GetAll())
            {
                foreach (var transaction in account.Transactions)
                {
                    if (transaction.Amount > maxTransactionAmount)
                    {
                        maxTransactionAmount = transaction.Amount;
                        largestTransactionAccount = account;
                    }
                }
            }

            //If no transactions exist this gets null
            return largestTransactionAccount;

            //If you were using a database and couldn't store these all in memory you'd do something like this in SQL to just get the account with the top amount
            //SELECT TOP 1 a.*
            //FROM Accounts a
            //JOIN Transactions t ON a.AccountId = t.AccountId
            //ORDER BY t.Amount DESC;

            //Same result with entity framework (need a dbcontext). This internally makse a SQL query.
            //public Account GetAccountWithLargestTransaction()
            //{
            //    using (var context = new BankingDbContext())
            //    {
            //        var result = context.Transactions
            //            .OrderByDescending(t => t.Amount) // Get the largest transaction first
            //            .Select(t => t.Account)          // Get the related account
            //            .FirstOrDefault();               // Fetch only one record

            //        return result;
            //    }
            //}
        }

        //This would use multithreading 
        //This assumes they're already loaded into memory
        public Account GetAccountWithLargestTransaction_PLINQ()
        {
            return _accountRepository.GetAll()
                .AsParallel() // Enables parallel processing
                .SelectMany(account => account.Transactions
                    .Select(t => new { Account = account, TransactionAmount = t.Amount }))
                .OrderByDescending(x => x.TransactionAmount)
                .Select(x => x.Account)
                .FirstOrDefault();
        }
    }
}


namespace BankingSystem
{
    class Program
    {
        static void BankingSystem_Main()
        {
            var accountRepo = new AccountRepository();
            var accountService = new AccountService(accountRepo);

            // Create accounts
            var alice = accountService.CreateAccount("Alice");
            var bob = accountService.CreateAccount("Bob");

            Console.WriteLine($"Alice's Account ID: {alice.AccountId}");
            Console.WriteLine($"Bob's Account ID: {bob.AccountId}\n");

            // Perform transactions
            accountService.Deposit(alice.AccountId, 1000);
            accountService.Withdraw(alice.AccountId, 200);
            accountService.Transfer(alice.AccountId, bob.AccountId, 300);

            // Display accounts
            accountService.ShowAccountDetails(alice.AccountId);
            Console.WriteLine();
            accountService.ShowAccountDetails(bob.AccountId);

            //Extra challenge, get acount with largest transaction
            var accountWithLargestTransaction = accountService.GetAccountWithLargestTransaction();
            if (accountWithLargestTransaction != null)
            {
                Console.WriteLine($"Account with the largest transaction: {accountWithLargestTransaction.Name}");
            }
            else
            {
                Console.WriteLine("No transactions found.");
            }
        }
    }
}

//Sample Output:
//Alice 's Account ID: 3a1f7d2e-8c2b-4a10-bf3c-f45d1d536876
//Bob 's Account ID: 12d8c0a3-6a50-4099-8b24-f25b1f8db5e8

//Account: Alice | Balance: $500.00
//Transactions:
//2025 - 03 - 01T12: 00:00Z - Deposit - $1,000.00
//2025 - 03 - 01T12: 01:00Z - Withdraw - $200.00
//2025 - 03 - 01T12: 02:00Z - Transfer to Bob - $300.00

//Account: Bob | Balance: $300.00
//Transactions:
//2025 - 03 - 01T12: 02:00Z - Transfer from Alice - $300.00

// Enhancements for Production

// Database Integration – Use SQL Server / MongoDB instead of in-memory storage.
// Concurrency Handling – Use locks or transactions to avoid race conditions.
// Logging & Monitoring – Use Serilog & AppInsights for logs.
// API Integration – Expose as a REST API using ASP.NET Core.