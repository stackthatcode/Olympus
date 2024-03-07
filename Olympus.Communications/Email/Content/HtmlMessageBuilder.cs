using DCT.Middle.Instance.Email.Content;
using Olympus.Blocks.Helpers;
using Olympus.Communications.Config;

// *** Warning - if this namespace is relocated, the ResourceName constant will have to be updated
//
namespace Olympus.Communications.Email.Content
{
    public class HtmlMessageBuilder
    {
        private readonly CompanyBrandConfig _config;
        private readonly Message _outputModel = new Message();
        private bool _usesEmbeddedImages { get; set; } = false;


        public HtmlMessageBuilder(CompanyBrandConfig config)
        {
            _config = config;
        }

        
        
        // 
        public HtmlMessageBuilder AddCompanyBrand(CompanyBrand brand)
        {
            throw new NotImplementedException();
        }


        public HtmlMessageBuilder UsesEmbeddedImages(bool usesEmbeddedImages)
        {
            this._usesEmbeddedImages = usesEmbeddedImages;
            return this;
        }

        

        public HtmlMessageBuilder AddHtmlTextBlock(string content)
        {
            _outputModel.ContentBlocks.Add(new HtmlBlock() { Content = content });
            return this;
        }

        public HtmlMessageBuilder AddParagraph(string content)
        {
            _outputModel.ContentBlocks.Add(new HtmlBlock() { Content = $"<p>{content}</p>" });
            return this;
        }

        public HtmlMessageBuilder AddActionButton(string url, string buttonText)
        {
            _outputModel.ContentBlocks.Add(
                new ActionBlock()
                {
                    Url = url,
                    ButtonText = buttonText
                });
            return this;
        }


        
        public HtmlMessageBuilder AddDefaultCompanyBrand()
        {
            if (this._usesEmbeddedImages)
            {
                var logoImage = this.GetResource(_config.CompanyLogoResource);
                var logo = new EmbeddedImage(logoImage);
                var companyBrand = new CompanyBrand(_config.CompanyName, _config.CompanyWebsiteUrl, logo);

                return this;
            }

            else
            {
                //var logo = new ImageUrlRef(_config.);
                //_outputModel.Logo = new ContentImage() { ImageName = _config.CompanyLogoUrl };
                
                return this;
            }
        }


        public Message Output()
        {
            throw new NotImplementedException();
        }
    }
}
