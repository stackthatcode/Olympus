using DCT.Middle.Instance.Email.Content;
using RazorEngine.Templating;
using RazorLight;

namespace Olympus.Communications.Email.Html
{
    public class HtmlTemplateService
    {
        private const string ActionTemplateResource = "DCT.Middle.Email.Html.ActionTemplate.cshtml";
        private const string ActionTemplateKey = "ActionTemplate";

        // *** Antaris implementation 
        //
        private IRazorEngineService _templateService;

        // *** RazorEngineLight
        //
        private RazorLightEngine _engine;


        public HtmlTemplateService Initialize()
        {
            // *** Antaris implementation
            //
            //if (_templateService == null)
            //{
            //    using (var templateStream = GetType().Assembly.GetManifestResourceStream(ActionTemplateResource))
            //    using (var reader = new StreamReader(templateStream))
            //    {
            //        var razorTemplate = reader.ReadToEnd();
            //        Engine.Razor.Compile(razorTemplate, ActionTemplateKey, typeof(Message));
            //    }
            //}

            // *** RazorLightEngine
            //

            _engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(HtmlTemplateService).Assembly)
                .UseMemoryCachingProvider()
                .Build();
            
            return this;
        }

        public HtmlMessage Build(Message message, bool useEmbeddedImages)
        {
            var output = new HtmlMessage();
            output.UsesEmbeddedImages = useEmbeddedImages;

            // *** RazorLightEngine
            //
            string html = _engine.CompileRenderAsync(ActionTemplateResource, message).Result;

            // This looks like a hack fix
            //
            output.Html = html.Replace("DCT.Middle.Email.Content.Message Message", "");

            // *** This is deprecated
            //output.ImageReferences.Add(new HtmlImage(message.Logo));

            return output;
        }
    }
}

