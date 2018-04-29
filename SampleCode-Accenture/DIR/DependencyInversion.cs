using System;

namespace SampleCode_Accenture.DIR
{
    public class DependencyInversion
    {
        //Applying DIP resolves these problems by removing direct dependencies between classes. 
        public interface ITransferSource
        {
            long AccountNumber { get; set; }
            decimal Balance { get; set; }
            void RemoveFunds(decimal value);
        }
        public interface ITransferDestination
        {
            long AccountNumber { get; set; }
            decimal Balance { get; set; }
            void AddFunds(decimal value);
        }
        public class BOABankAccount : ITransferSource, ITransferDestination
        {
            public long AccountNumber { get; set; }
            public decimal Balance { get; set; }

            public void AddFunds(decimal value)
            {
                Balance += value;
            }
            public void RemoveFunds(decimal value)
            {
                Balance -= value;
            }
        }
        public class TransferAmounts
        {
            public decimal Amount { get; set; }
            public void Transfer(ITransferSource TransferSource, ITransferDestination TransferDestination)
            {
                TransferSource.RemoveFunds(Amount);
                TransferDestination.AddFunds(Amount);
            }
        }

        class DependencyInversionPrincipleDemo
        {
            public static void DIPDemo()
            {
                Console.WriteLine("\n\nDependency Inversion Principle Demo ");

                //Created abstract class/interfaces objects for low level classes.
                ITransferSource TransferSource = new BOABankAccount();
                TransferSource.AccountNumber = 123456789;
                TransferSource.Balance = 1000;
                Console.WriteLine("Balance in Source Account : " + TransferSource.AccountNumber + " Amount " + TransferSource.Balance);

                ITransferDestination TransferDestination = new BOABankAccount();
                TransferDestination.AccountNumber = 987654321;
                TransferDestination.Balance = 0;
                Console.WriteLine("Balance in Destination Account : " + TransferDestination.AccountNumber + " Amount " + TransferDestination.Balance);


                TransferAmounts TransferAmountsObject = new TransferAmounts();
                TransferAmountsObject.Amount = 100;

                // High level class using abstract class/interface objects 
                TransferAmountsObject.Transfer(TransferSource, TransferDestination);
                Console.WriteLine("Transaction successful");

                Console.WriteLine("Balance in Source Account : " + TransferSource.AccountNumber + " Amount " + TransferSource.Balance);
                Console.WriteLine("Balance in Destination Account : " + TransferDestination.AccountNumber + " Amount " + TransferDestination.Balance);
            }
        }
    }
}
