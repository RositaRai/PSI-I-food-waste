// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Serilog;
using Newtonsoft.Json;
using Castle.DynamicProxy;
using System;

namespace PSI_Food_waste.Services
{
    public class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
                Log.Logger.Information($"Method {invocation.Method.Name} called with parameters: {JsonConvert.SerializeObject(invocation.Arguments)}" +
    $"returned this response: { JsonConvert.SerializeObject(invocation.ReturnValue)}");
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"Error! In method : {invocation.Method}. Message: {JsonConvert.SerializeObject(ex)}");
                throw;
            }
        }
    }
}
