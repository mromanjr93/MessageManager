using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
