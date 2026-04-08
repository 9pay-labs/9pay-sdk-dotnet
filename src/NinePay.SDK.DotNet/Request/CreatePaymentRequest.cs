using System;
using System.Collections.Generic;
using NinePay.SDK.DotNet.Enums;

namespace NinePay.SDK.DotNet.Request
{
    public class CreatePaymentRequest : RequestInterface
    {
        public string RequestCode { get; }
        public string Amount { get; }
        public string Description { get; }
        public string? BackUrl { get; private set; }
        public string? ReturnUrl { get; private set; }

        public string? Method { get; private set; }
        public string? ClientIp { get; private set; }
        public string? Currency { get; private set; }
        public string? Lang { get; private set; }
        public string? CardToken { get; private set; }
        public int? SaveToken { get; private set; }
        public string? TransactionType { get; private set; }
        public string? ClientPhone { get; private set; }
        public int? ExpiresTime { get; private set; }

        private readonly Dictionary<string, object> extraData = new();

        public CreatePaymentRequest(
            string requestCode,
            string amount,
            string description,
            string? backUrl,
            string? returnUrl)
        {
            if (string.IsNullOrEmpty(requestCode) ||
                string.IsNullOrEmpty(amount) ||
                string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Missing required fields: requestCode, amount, description");
            }

            RequestCode = requestCode;
            Amount = amount;
            Description = description;
            BackUrl = backUrl;
            ReturnUrl = returnUrl;
        }

        public CreatePaymentRequest(string requestCode, string amount, string description)
            : this(requestCode, amount, description, null, null)
        {
        }

        public CreatePaymentRequest WithMethod(PaymentMethod method)
        {
            Method = method.Value;
            return this;
        }

        public CreatePaymentRequest WithClientIp(string clientIp)
        {
            ClientIp = clientIp;
            return this;
        }

        public CreatePaymentRequest WithCurrency(Currency currency)
        {
            Currency = currency.Value;
            return this;
        }

        public CreatePaymentRequest WithLang(Language lang)
        {
            Lang = lang.Value;
            return this;
        }

        public CreatePaymentRequest WithCardToken(string cardToken)
        {
            CardToken = cardToken;
            return this;
        }

        public CreatePaymentRequest WithSaveToken(int saveToken)
        {
            SaveToken = saveToken;
            return this;
        }

        public CreatePaymentRequest WithTransactionType(TransactionType transactionType)
        {
            TransactionType = transactionType.Value;
            return this;
        }

        public CreatePaymentRequest WithClientPhone(string clientPhone)
        {
            ClientPhone = clientPhone;
            return this;
        }

        public CreatePaymentRequest WithExpiresTime(int expiresTime)
        {
            if (expiresTime < 0)
                throw new ArgumentException("Expires time must be positive");

            ExpiresTime = expiresTime;
            return this;
        }

        public CreatePaymentRequest WithParam(string key, object value)
        {
            extraData[key] = value;
            return this;
        }

        public Dictionary<string, object> ToPayload()
        {
            var payload = new Dictionary<string, object>
            {
                ["invoice_no"] = RequestCode,
                ["amount"] = Amount,
                ["description"] = Description
            };

            if (BackUrl != null) payload["back_url"] = BackUrl;
            if (ReturnUrl != null) payload["return_url"] = ReturnUrl;
            if (Method != null) payload["method"] = Method;
            if (ClientIp != null) payload["client_ip"] = ClientIp;
            if (Currency != null) payload["currency"] = Currency;
            if (Lang != null) payload["lang"] = Lang;
            if (CardToken != null) payload["card_token"] = CardToken;
            if (SaveToken != null) payload["save_token"] = SaveToken;
            if (TransactionType != null) payload["transaction_type"] = TransactionType;
            if (ClientPhone != null) payload["client_phone"] = ClientPhone;
            if (ExpiresTime != null) payload["expires_time"] = ExpiresTime;

            foreach (var kv in extraData)
            {
                payload[kv.Key] = kv.Value;
            }

            return payload;
        }
    }
}