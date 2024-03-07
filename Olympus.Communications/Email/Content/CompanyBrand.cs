namespace Olympus.Communications.Email.Content
{
    public class CompanyBrand
    {
        public string CompanyName { get; private set; }
        public string CompanyWebsiteUrl { get; private set; }
        public IContentImage CompanyLogo { get; private set; }

        public CompanyBrand(string companyName, string websiteUrl, IContentImage logo)
        {
            this.CompanyName = companyName;
            this.CompanyWebsiteUrl = websiteUrl;
            this.CompanyLogo = logo;
        }
    }
}
