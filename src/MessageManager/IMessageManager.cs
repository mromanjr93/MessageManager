using System.Globalization;

namespace MessageManager
{
    public interface IMessageManager
    {
        Message GetMessage(string key);

        void SetRequestCultureInfo(CultureInfo cultureInfo);
    }
}
