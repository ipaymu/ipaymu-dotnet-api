using System;
using IpaymuLibrary;
public class Exercise
{
    static async Task Main()
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }

    }

    private static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Va: 1179000899");
        Console.WriteLine("ApiKey: QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1");
        Console.WriteLine("sandbox");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Direct Payment");
        Console.WriteLine("2) Direct Payment COD");
        Console.WriteLine("3) Check Transaction");
        Console.WriteLine("4) Payment Method");
        Console.WriteLine("5) Redirect Payment");
        Console.WriteLine("6) Check Balance");

        Console.WriteLine("7) Exit");
        Console.Write("\r\nSelect an option: ");


        switch (Console.ReadLine())
        {
            case "1":
                
                FDirectPayment();
                Console.ReadLine();
                return true;
            case "2":
                FDirectPaymentCod();
                Console.ReadLine();
                return true;
            case "3":
                FCheckTransaksi();
                Console.ReadLine();
                return true;
            case "4":
                FListPaymentMethod();
                Console.ReadLine();
                return true;
            case "5":
                FRedirectPayment();
                Console.ReadLine();
                return true;
            case "6":
                FCheckBalance();
                Console.ReadLine();
                return true;
            case "7":
                return false;
            default:
                return true;
        }


       
    }


    private static async Task FRedirectPayment()
    {
        //---------------------- Redirect Payment--------------------------//

        // sendbox set true or false 
        RedirectPayment.sandbox = true;

        RedirectPayment.va = "1179000899";

        RedirectPayment.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        RedirectPayment.product = new string[] { "T-Shirt", "Jacket", "Shoes" };

        RedirectPayment.qty = new string[] { "1", "1", "2" };

        RedirectPayment.price = new string[] { "100000", "250000", "350000" };

        RedirectPayment.notifyUrl = "https://your-website/callback-url";

        RedirectPayment.returnUrl = "https://your-website/thank-you-page";

        RedirectPayment.cancelUrl = "https://your-website/cancel-page";

        RedirectPayment.referenceId = "1";

        RedirectPayment.buyerName = "bayu";

        RedirectPayment.buyerEmail = "buyer@mail.com";

        RedirectPayment.buyerPhone = "08123123";

        RedirectPayment.paymentMethod = "va";

        RedirectPayment.paymentChannel = "bca";




        Console.WriteLine("---------------------Redirect Payment--------------------------");
        RedirectPayment ipy = new RedirectPayment();
        await ipy.Initialize;

        Console.WriteLine(RedirectPayment.responses);
      
    }

    private static async Task FDirectPayment()
    {
        //---------------------- Direct Payment--------------------------//

        // sendbox set true or false 

        DirectPayment.sandbox = true;

        DirectPayment.va = "1179000899";

        DirectPayment.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        DirectPayment.name = "bayu";

        DirectPayment.phone = "085777777777";

        DirectPayment.email = "admin@email.com";

        DirectPayment.amount = "10000";

        DirectPayment.notifyUrl = "https://your-website/callback-url";

        DirectPayment.expired = "24";

        DirectPayment.expiredType = "hours";

        DirectPayment.comment = "tes sayangq";

        DirectPayment.referenceId = "1";

        DirectPayment.paymentMethod = "va";

        DirectPayment.paymentChannel = "bca";


        DirectPayment dr = new DirectPayment();
        await dr.Initialize;

        Console.WriteLine("----------------------Direct Payment--------------------------");
        Console.WriteLine(DirectPayment.responses);
        Console.ReadLine();
    }

    private static async Task FDirectPaymentCod()
    {
        //---------------------- Direct Payment COD--------------------------//

        // sendbox set true or false 

        DirectPaymentCod.sandbox = true;

        DirectPaymentCod.va = "1179000899";

        DirectPaymentCod.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        DirectPaymentCod.name = "bayu";

        DirectPaymentCod.phone = "085777777777";

        DirectPaymentCod.email = "admin@email.com";

        DirectPaymentCod.amount = "10000";

        DirectPaymentCod.notifyUrl = "https://your-website/callback-url";

        DirectPaymentCod.expired = "24";

        DirectPaymentCod.expiredType = "hours";

        DirectPaymentCod.comment = "tes sayangq";

        DirectPaymentCod.referenceId = "1";

        DirectPaymentCod.paymentMethod = "va";

        DirectPaymentCod.paymentChannel = "bca";


        DirectPaymentCod.product = new string[] { "T-Shirt", "Jacket", "Shoes" };

        DirectPaymentCod.qty = new string[] { "1", "1", "2" };

        DirectPaymentCod.price = new string[] { "100000", "250000", "350000" };


        DirectPaymentCod.weight = new string[] { "1", "1", "1" };

        DirectPaymentCod.width = new string[] { "1", "1", "2" };

        DirectPaymentCod.height = new string[] { "1", "1", "1" };

        DirectPaymentCod.length = new string[] { "1", "1", "2" };

        DirectPaymentCod.deliveryArea = "bali";

        DirectPaymentCod.deliveryAddress = "tabanan";


        DirectPaymentCod drc = new DirectPaymentCod();
        await drc.Initialize;

        Console.WriteLine("----------------------Direct Payment COD--------------------------");
        Console.WriteLine(DirectPaymentCod.responses);
    }

    private static async Task FCheckTransaksi()
    {


        //---------------------- Check Transaksi--------------------------//

        // sendbox set true or false 

        CheckTransaction.sandbox = true;

        CheckTransaction.va = "1179000899";

        CheckTransaction.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        CheckTransaction.transactionId = "1";

        CheckTransaction.account = "1179000899";


        CheckTransaction ct = new CheckTransaction();
        await ct.Initialize;


        Console.WriteLine("----------------------Check Transaksi--------------------------");
        Console.WriteLine(CheckTransaction.responses);
    }

    private static async Task FListPaymentMethod()
    {
        //---------------------- List Payment Method--------------------------//

        // sendbox set true or false 

        ListPaymentMethod.sandbox = true;

        ListPaymentMethod.va = "1179000899";

        ListPaymentMethod.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";


        ListPaymentMethod ListPayment = new ListPaymentMethod();
         await ListPayment.Initialize;

        Console.WriteLine("----------------------List Payment Method--------------------------");
        Console.WriteLine(ListPaymentMethod.responses);
    }

    private static async Task FCheckBalance()
    {


        // sendbox set true or false 

        CheckBalance.sandbox = true;

        CheckBalance.va = "1179000899";

        CheckBalance.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        CheckBalance.account = "1179000899";

        CheckBalance CheckBalances = new CheckBalance();
        await CheckBalances.Initialize;

        Console.WriteLine("----------------------Check Balance--------------------------");
        Console.WriteLine(CheckBalance.responses);
    }
}