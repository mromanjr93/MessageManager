using System;
using System.Collections.Generic;
using System.Text;

namespace MessageManager
{
    public class MessageFile
    {
        public string Language { get; set; }

        public List<Message> Messages { get; set; }
    }
}
