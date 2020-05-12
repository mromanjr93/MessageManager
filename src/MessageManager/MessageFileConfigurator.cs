using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MessageManager
{
    public class MessageFileConfigurator
    {
        private List<string> _files = new List<string>();
        
        internal CultureInfo CultureInfo = null;

        internal Dictionary<string, List<Message>> Messages = new Dictionary<string, List<Message>>();

        public void AddFileMessage(string fileName)
        {
            _files.Add(fileName);
        }

        public void SetDefaultCultureInfo(CultureInfo cultureInfo)
        {
            this.CultureInfo = cultureInfo;
        }


        internal async Task Deserialize()
        {
            if (_files is null)
            {
                throw new InvalidOperationException("No files added");
            }

            foreach (var file in _files)
            {
                using (FileStream fs = File.OpenRead(file))
                {
                    var message = await JsonSerializer.DeserializeAsync<MessageFile>(fs);

                    if (Messages.ContainsKey(message.Language))
                    {
                        Messages[message.Language].AddRange(message.Messages);
                    }
                    else
                    {
                        Messages.Add(message.Language, message.Messages);
                    }
                }
            }
        }
    }
}
