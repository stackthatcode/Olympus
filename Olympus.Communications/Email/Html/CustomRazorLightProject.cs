using RazorLight.Razor;

namespace Olympus.Communications.Email.Html
{
    internal class CustomRazorLightProject : RazorLightProject
    {
        public override Task<RazorLightProjectItem> GetItemAsync(string templateKey)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<RazorLightProjectItem>> GetImportsAsync(string templateKey)
        {
            throw new NotImplementedException();
        }
    }
}
