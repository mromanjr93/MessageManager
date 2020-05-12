using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;

namespace MessageManager
{
    public class Message
    {
        public string Key { get; set; }

        public string Code { get; set; }

        public string Property { get; set; }

        public string Value { get; set; }

        
        public Message FormatProperty(params string[] values)
        {
            Property = string.Format(Property, values);
            return this;
        }

        public Message FormatValue(params string[] values)
        {
            Value = string.Format(Value, values);
            return this;
        }

        public Notification GetNotification(bool useCode = false)
        {
            return new Notification(useCode ? Code : Property, Value);
        }
    }
}
