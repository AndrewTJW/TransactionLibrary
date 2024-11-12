﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using Google.Cloud.Firestore;

namespace Homework2Library
{
    [FirestoreData]
    public class TransactionList
    {
        private List<UserTransaction> Transactions;

        public TransactionList()
        {
            Transactions = new List<UserTransaction>();
        }

        public void AddTransaction(UserTransaction a_transaction)
        {
            Transactions.Add(a_transaction);
        }
        public void RemoveTransaction(UserTransaction a_transaction)
        {
            Transactions.Remove(a_transaction);
        }
        public void DisplayTransactionHistory()
        {
            foreach (UserTransaction tmp in Transactions)
            {
                tmp.DisplayTransactionDetails();
            }
        }

        public double getTotalRevenue()
        {
            double total = 0;
            foreach (UserTransaction tmp in Transactions)
            {
                if (tmp is Income tmp_income)
                {
                    total += tmp_income.getAmount();
                }
            }
            return total;
        }

        public double getTotalExpense()
        {
            double total = 0;
            foreach(UserTransaction tmp in Transactions)
            {
                if (tmp is Expense tmp_expense)
                {
                    total -= tmp_expense.getAmount();
                }
            }
            return total;
        }

        public void Clear()
        {
            Transactions.Clear();
        }
    }
}

