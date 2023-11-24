

using task29August.NewFolder.RequestDto;
using task29August.RequestModel;

namespace task29August.repository
{
    public interface IEmail
    {
        Task SendingMailAsync(MailRequest request);
    }
}
