namespace Olympus.Communications.Config
{

    // This acts a shim enabling external consumers a mechanism for feeding stuff to the IoC 
    // ... framework. It does "force the hand" of the consumer to retrieve data from config 
    // ... and embedded resources

    public class CompanyBrandConfig
    {
        // NOTE: Gmail does not accept embedded images
        //
        // ALSO: This is abstraction bleeding - or is it?
        // ... It is. IIRC LogoImageName is used in the Image CID
        //
        
        public string CompanyName { get; private set; }
        public string CompanyWebsiteUrl { get; private set; }
        public byte[] CompanyLogoBitmap { get; private set; }


        [Obsolete]
        public string CompanyLogoUrl { get; private set; }
        [Obsolete]
        public string CompanyLogoResource { get; private set; }


        public static CompanyBrandConfig ReadConfig(
                string companyName = null, 
                string companyWebsiteUrl = null, 
                byte[] companyLogoBitmap = null)
        {
            var config = new CompanyBrandConfig();

            config.CompanyName = companyName;
            config.CompanyWebsiteUrl = companyWebsiteUrl;
            config.CompanyLogoBitmap = companyLogoBitmap;


            // ## NOTE - What does mean, a link to the logo or the actual image itself?
            //
            //config.CompanyLogoUrl = companyLogoUrl;

            // ## NOTE - this kind of stuff belongs in a 
            //
            // Hardcoded resource name - good enough for now
            //
            //config.CompanyLogoResource 
            //        = "Mimeo.Communications.Middle.Email.Resources.DCGroupLogo.jpg";

            return config;
        }
    }
}
