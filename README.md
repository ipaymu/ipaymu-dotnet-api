# Ipaymu-Dotnet-Api

.Net package for iPaymu.com Indonesia payment gateway.

## Installation

Install Ipaymu-Dotnet-Api with:

### .NET CLI
```sh
dotnet add package Ipaymu.Dotnet.Api --version 1.0.1
```

### paket CLI
```sh
paket add Ipaymu.Dotnet.Api --version 1.0.1
```

Then, import it using:

```c#
using IpaymuLibrary;
```
## Example
### Direct Payment
```c#
    private static async Task DirectPayment()
    {
        DirectPayment.sandbox = true;  // sendbox set true or false 
        DirectPayment.va = "1179000899";// iPaymu VA
        DirectPayment.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";
        DirectPayment.name = "bayu";
        DirectPayment.phone = "085777777777";
        DirectPayment.email = "admin@email.com";
        DirectPayment.amount = "10000";
        DirectPayment.notifyUrl = "https://your-website/callback-url";
        DirectPayment.expired = "24";
        DirectPayment.expiredType = "hours";
        DirectPayment.comment = "tes";
        DirectPayment.referenceId = "1";
        DirectPayment.paymentMethod = "va";
        DirectPayment.paymentChannel = "bca";

        DirectPayment dr = new DirectPayment();
        await dr.Initialize;
        Console.WriteLine(CheckTransaction.responses);
    }
```

### Direct Payment COD
```c#
    private static async Task DirectPaymentCod()
    {

        DirectPaymentCod.sandbox = true;  // sendbox set true or false 
        DirectPaymentCod.va = "1179000899";//iPaymu VA
        DirectPaymentCod.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        DirectPaymentCod.name = "bayu";
        DirectPaymentCod.phone = "085777777777";
        DirectPaymentCod.email = "admin@email.com";
        DirectPaymentCod.amount = "10000";
        DirectPaymentCod.notifyUrl = "https://your-website/callback-url";
        DirectPaymentCod.expired = "24";
        DirectPaymentCod.expiredType = "hours";
        DirectPaymentCod.comment = "tes";
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
        Console.WriteLine(DirectPaymentCod.responses);
    }
```

### Check Transaction
```c#
    private static async Task CheckTransaction()
    {
        CheckTransaction.sandbox = true;  // sendbox set true or false 
        CheckTransaction.va = "1179000899";//iPaymu VA
        CheckTransaction.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        CheckTransaction.transactionId = "1"; // Paymu transaction id
        CheckTransaction.account = "1179000899"; //iPaymu VA

        CheckTransaction ct = new CheckTransaction();
        await ct.Initialize;
        Console.WriteLine(CheckTransaction.responses);
    }
```

### List PaymentMethod
```c#
    private static async Task ListPaymentMethod()
    {
        ListPaymentMethod.sandbox = true;   // sendbox set true or false 
        ListPaymentMethod.va = "1179000899"; //iPaymu VA
        ListPaymentMethod.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";

        ListPaymentMethod ListPayment = new ListPaymentMethod();
        await ListPayment.Initialize;
        Console.WriteLine(ListPaymentMethod.responses);
    }
```

### Check Balance
```c#
   private static async Task CheckBalance()
    {
        CheckBalance.sandbox = true; // sendbox set true or false 
        CheckBalance.va = "1179000899"; //iPaymu VA
        CheckBalance.apiKey = "QbGcoO0Qds9sQFDmY0MWg1Tq.xtuh1";
        CheckBalance.account = "1179000899"; //iPaymu VA

        CheckBalance CheckBalances = new CheckBalance();
        await CheckBalances.Initialize;
        Console.WriteLine(CheckBalance.responses);
    }
```