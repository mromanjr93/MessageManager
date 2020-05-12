using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MessageManager
{
    internal class MessageManager : IMessageManager
    {
        private static Dictionary<string, List<Message>> _messages;

        private readonly CultureInfo _defaultCultureInfo;

        private CultureInfo _requestCultureInfo;

        public MessageManager(Dictionary<string, List<Message>> messages, System.Globalization.CultureInfo cultureInfo = null)
        {
            _messages = messages;
            _defaultCultureInfo = cultureInfo ?? new CultureInfo("en-US");
            _requestCultureInfo = _requestCultureInfo ?? new CultureInfo("en-US");
        }

        public Message GetMessage(string key)
        {
            List<Message> messages = new List<Message>();

            if (_messages.TryGetValue(_requestCultureInfo.Name, out messages))
            {

                return messages.FirstOrDefault(c => c.Key == key);
            }
            else
            {
                if (_messages.TryGetValue(_defaultCultureInfo.Name, out messages))
                {

                    return messages.FirstOrDefault(c => c.Key == key);
                }
            }


            throw new KeyNotFoundException(key);
        }

        public void SetRequestCultureInfo(CultureInfo requestCultureInfo)
        {
            this._requestCultureInfo = requestCultureInfo;
        }
    }
}
