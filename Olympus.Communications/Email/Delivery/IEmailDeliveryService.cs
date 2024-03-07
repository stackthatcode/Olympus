using Olympus.Communications.Email.Html;

namespace Olympus.Communications.Email.Delivery
{
    public interface IEmailDeliveryService
    {
        Task<bool> Send(
            List<string> addressees, 
            string subject, 
            HtmlMessage message, 
            List<Attachment> attachments = null);

        Task<bool> Send(
            string addressee, 
            string subject, 
            HtmlMessage message, 
            List<Attachment> attachments = null);
    }
}

