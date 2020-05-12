using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

namespace MessageManager
{
    public static class MessageManagerConfiguration
    {
        public static IServiceCollection AddMessageManager(this IServiceCollection services, Action<MessageFileConfigurator> configurator)
        {
            var conf = new MessageFileConfigurator();

            configurator(conf);

            conf.Deserialize().GetAwaiter().GetResult();

            services.AddSingleton<IMessageManager, MessageManager>(p => new MessageManager(conf.Messages, conf.CultureInfo));

            return services;
        }
    }
}
