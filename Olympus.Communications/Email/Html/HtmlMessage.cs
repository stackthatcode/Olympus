using Olympus.Communications.Email.Content;

namespace Olympus.Communications.Email.Html
{
    public class HtmlMessage
    {
        public bool UsesEmbeddedImages { get; set; }
        public string Html { get; set; }
        public List<EmbeddedImage> ImageReferences { get; set; }

        public HtmlMessage()
        {
            ImageReferences = new List<EmbeddedImage>();
        }
    }
}
