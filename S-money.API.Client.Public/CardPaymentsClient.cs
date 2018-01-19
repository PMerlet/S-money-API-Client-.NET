﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using Smoney.API.Client.Models.Operations;
using System.Net;

namespace Smoney.API.Client
{
    public partial class APIClient
    {
        private const string cardpayments = "payins/cardpayments";

        public IEnumerable<CardPayment> GetCardPayments(string userIdentifier = null, int? pageNumber = null)
        {
            UseV2();

            var uri = CreateUri(userIdentifier, cardpayments, pageNumber);
            return GetAsync<IEnumerable<CardPayment>>(uri);
        }

        public int GetCardPaymentsCount(string userIdentifier = null)
        {
            UseV2();

            var uri = CreateUri(userIdentifier, cardpayments);
            return GetCount(uri);
        }

        public CardPayment GetCardPayment(string id, string userIdentifier = null)
        {
            UseV2();

            var uri = CreateUri(userIdentifier, cardpayments);
            return GetAsync<CardPayment>(uri + id);
        }

        public CardPaymentCreated PostCardPayment(CardPaymentRequest cardPayment, string userIdentifier = null)
        {
            UseV2();

            var uri = CreateUri(userIdentifier, cardpayments);
            return PostAsync<CardPaymentRequest, CardPaymentCreated>(uri, cardPayment);
        }
    }
}