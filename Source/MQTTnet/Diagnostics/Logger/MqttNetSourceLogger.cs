// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace MQTTnet.Diagnostics.Logger
{
    public sealed class MqttNetSourceLogger
    {
        readonly IMqttNetLogger _logger;
        readonly string _source;
        readonly string _clientId;

        public MqttNetSourceLogger(IMqttNetLogger logger, string source, string clientId)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _source = source;
            _clientId = clientId;
        }

        public bool IsEnabled => _logger.IsEnabled;
        
        public void Publish(MqttNetLogLevel logLevel, string message, object[] parameters, Exception exception)
        {
            _logger.Publish(logLevel, _source, _clientId, message, parameters, exception);
        }
    }
}