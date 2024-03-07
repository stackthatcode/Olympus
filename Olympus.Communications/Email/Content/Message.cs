using System.Collections.Generic;
using Olympus.Communications.Email.Content;

namespace DCT.Middle.Instance.Email.Content
{
    public class Message
    {
        public CompanyBrand CompanyBrand { get; set; }
        public List<IContentBlock> ContentBlocks { get; set; }

        public Message()
        {
            ContentBlocks = new List<IContentBlock>();
        }
    }
}
