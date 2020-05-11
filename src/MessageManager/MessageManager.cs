using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MessageManager
{
    internal class MessageManager : IMessageManager
    {
        private static List<Message> _messages;
        public MessageManager(List<Message> messages)
        {
            _messages = messages;
        }

        public Message GetMessage(string key)
        {
           return _messages.FirstOrDefault(p => p.Key == key);
        }
    }
}
