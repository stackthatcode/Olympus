namespace Olympus.Communications.Email.Content
{
    public class ImageUrlRef : IContentImage
    {
        public string Src { get; }
        public string Alt { get; }
        public string Title { get; }

        public ImageUrlRef(string src, string alt = null, string title = null)
        {
            Src = src;
            Alt = alt;
            Title = title;
        }
    }
}
