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
        public static IServiceCollection AddMessageManager(this IServiceCollection services, params string[] messageFiles)
        {
            List<Message> messages = new List<Message>();

            foreach (var messageFile in messageFiles)
            {
                using (FileStream fs = File.OpenRead(messageFile))
                {
                    messages.AddRange(JsonSerializer.DeserializeAsync<List<Message>>(fs).GetAwaiter().GetResult());
                }
            }

            services.AddSingleton<IMessageManager, MessageManager>(p => new MessageManager(messages));

            return services;
        }
    }
}
