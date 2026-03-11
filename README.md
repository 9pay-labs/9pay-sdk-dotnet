# 9PAY Payment Gateway .NET SDK

[![NuGet](https://img.shields.io/nuget/v/NinePay.SDK.DotNet.svg)](https://www.nuget.org/packages/NinePay.SDK.DotNet)
[![NuGet Downloads](https://img.shields.io/nuget/dt/NinePay.SDK.DotNet.svg)](https://www.nuget.org/packages/NinePay.SDK.DotNet)

Official .NET SDK for integrating 9PAY Payment Gateway.

This package allows you to:

- Create payment requests with strongly typed parameters.
- Query transaction status.
- Verify webhook / callback data.

---

## Requirements

- .NET 6.0 / 7.0 / 8.0

Dependencies (automatically installed):

- Newtonsoft.Json
- DotNetEnv

---

## Installation

### Via .NET CLI

```bash
dotnet add package NinePay.SDK.DotNet
```

### Via PackageReference

```xml
<PackageReference Include="NinePay.SDK.DotNet" Version="1.0.0" />
```

---

## Environment Configuration

Create a .env file in your project root:

```bash
NINEPAY_MERCHANT_ID=YOUR_MERCHANT_ID
NINEPAY_SECRET_KEY=YOUR_SECRET_KEY
NINEPAY_CHECKSUM_KEY=YOUR_CHECKSUM_KEY
NINEPAY_ENV=SANDBOX
```

## Configuration

```csharp
using NinePay.SDK.DotNet.Config;

var merchantId = Environment.GetEnvironmentVariable("NINEPAY_MERCHANT_ID");
var secretKey = Environment.GetEnvironmentVariable("NINEPAY_SECRET_KEY");
var checksumKey = Environment.GetEnvironmentVariable("NINEPAY_CHECKSUM_KEY");
var env = Environment.GetEnvironmentVariable("NINEPAY_ENV");

var config = new NinePayConfig(
    merchantId,
    secretKey,
    checksumKey,
    env
);
```

---

## Initialization

```csharp
using NinePay.SDK.DotNet.Gateway;

var gateway = new NinePayGateway(config);
```

---

## Create Payment

```csharp
using NinePay.SDK.DotNet.Request;
using NinePay.SDK.DotNet.Response;
using NinePay.SDK.DotNet.Enums;

var request = new CreatePaymentRequest(
    "INV_" + DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), // Invoice No
    "50000",                                               // Amount
    "Payment for Order 1",                                 // Description
    "https://site.com/callback",                           // Back URL
    "https://site.com/return"                              // Return URL
);

request.WithMethod(PaymentMethod.ATM_CARD)
       .WithClientIp("127.0.0.1")
       .WithCurrency(Currency.VND)
       .WithLang(Language.VI);

ResponseInterface response = gateway.CreatePayment(request);

if (response.IsSuccess())
{
    var redirectUrl = response.GetData()["redirect_url"];
    Console.WriteLine("Redirect user to: " + redirectUrl);
}
else
{
    Console.WriteLine("Error: " + response.GetMessage());
}
```

---

## Query Transaction

```csharp
ResponseInterface response = gateway.Inquiry("INV_123456");

if (response.IsSuccess())
{
    Console.WriteLine(response.GetData());
}
else
{
    Console.WriteLine(response.GetMessage());
}
```

---

## Verify Webhook / Callback

```csharp
string result = Request.Query["result"];
string checksum = Request.Query["checksum"];

if (gateway.Verify(result, checksum))
{
    string decodedResult = gateway.DecodeResult(result);
    // Process JSON decodedResult...
}
```

---

## License

MIT License © 9Pay