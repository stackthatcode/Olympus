namespace Olympus.Communications.Email.Content
{
    public class EmbeddedImage : IContentImage
    {
        public byte[] Data { get; private set; }
        public string Cid { get; private set; }

        public string Src => @$"cid:${Cid}";
        public string Alt { get; private set; }
        public string Title { get; private set; }

        public EmbeddedImage(byte[] data, string alt = null, string title = null)
        {
            Data = data;
            Cid = Guid.NewGuid().ToString();

            Alt = alt;
            Title = title;
        }
    }
}

