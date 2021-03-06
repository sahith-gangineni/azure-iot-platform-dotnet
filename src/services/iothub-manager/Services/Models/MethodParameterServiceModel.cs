// <copyright file="MethodParameterServiceModel.cs" company="3M">
// Copyright (c) 3M. All rights reserved.
// </copyright>

using System;
using Microsoft.Azure.Devices;

namespace Mmm.Iot.IoTHubManager.Services.Models
{
    public class MethodParameterServiceModel
    {
        public MethodParameterServiceModel()
        {
        }

        public MethodParameterServiceModel(CloudToDeviceMethod azureModel)
        {
            this.Name = azureModel.MethodName;
            this.ResponseTimeout = azureModel.ResponseTimeout;
            this.ConnectionTimeout = azureModel.ConnectionTimeout;
            this.JsonPayload = azureModel.GetPayloadAsJson();
        }

        public string Name { get; set; }

        public TimeSpan? ResponseTimeout { get; set; }

        public TimeSpan? ConnectionTimeout { get; set; }

        public string JsonPayload { get; set; }

        public CloudToDeviceMethod ToAzureModel()
        {
            var method = new CloudToDeviceMethod(this.Name);
            if (this.ResponseTimeout.HasValue)
            {
                method.ResponseTimeout = this.ResponseTimeout.Value;
            }

            if (this.ConnectionTimeout.HasValue)
            {
                method.ConnectionTimeout = this.ConnectionTimeout.Value;
            }

            if (!string.IsNullOrEmpty(this.JsonPayload))
            {
                method.SetPayloadJson(this.JsonPayload);
            }

            return method;
        }
    }
}