using Olympus.Blocks.Helpers;
using Olympus.Blocks.Logging;
using Olympus.Communications.Email.Html;

namespace Olympus.Communications.Email.Delivery
{
    public class LocalEmailBin : IEmailDeliveryService
    {
        private readonly string _outputDirectory;
        private readonly MimeoLogger _logger;

        public LocalEmailBin(string localEmailBin, MimeoLogger logger)
        {
            _outputDirectory = config.LocalEmailBin ?? @"C:\Temp\EmailBin\";
            _logger = logger;
        }


        public async Task<bool> Send(
                string addressee,
                string subject,
                HtmlMessage message,
                List<Attachment> attachments = null)
        {
            return await Send(new List<string> { addressee }, subject, message);
        }

        public async Task<bool> Send(
                List<string> addressees,
                string subject,
                HtmlMessage message,
                List<Attachment> attachments = null)
        {
            // Since images won't be embedded, this test service will save the files and
            // ... reference them locally from the same location as the HTML file
            //
            if (!Directory.Exists(_outputDirectory))
            {
                Directory.CreateDirectory(_outputDirectory);
            }

            foreach (var image in message.ImageReferences)
            {
                //var imagePath = Path.Combine(_outputDirectory, image.FileName);

                //if (!File.Exists(imagePath))
                //{
                //    await File.WriteAllBytesAsync(imagePath, image.Image);
                //}
            }

            var destination =
                addressees.Count > 1
                    ? "(Multiple recipients)" : addressees.ToCommaDelimited();

            var fileName =
                $"{destination.LettersOrNumbersOnly()} - " +
                $"{subject.IfEmptyAlt("(Empty Subject)").LettersOrNumbersOnly()} - " +
                $"{DateTime.UtcNow.ToString().LettersOrNumbersOnly()}.html";

            var path = Path.Combine(_outputDirectory, fileName);
            _logger.Info($"Test Mode Enabled. Saving email message to {path}. Intended recipients: {destination}");

            await File.WriteAllTextAsync(path, message.Html);

            return true;
        }

        public Task<bool> Send(List<string> addressees, string subject, HtmlMessage message, List<Microsoft.Graph.Attachment> attachments = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Send(string addressee, string subject, HtmlMessage message, List<Microsoft.Graph.Attachment> attachments = null)
        {
            throw new NotImplementedException();
        }
    }
}

