namespace Olympus.Communications.Config
{
    public class MailgunConfig
    {
        public string MailgunResource { get; set; }
        public string MailgunApiKey_Cipher { get; set; }
        public string FromAddress { get; set; }
        public string ReplyToAddress { get; set; }
        public string PostmasterAddress { get; set; } // aleksj@dcexport for now
        public string EmailDomain { get; set; } // dcexport.com
        

        // Again - this object should not know how to pull stuff from config. That's the job
        // ... of the consumer. Mimeo is like all about productivity. Lol!
        //
        public static MailgunConfig ReadConfig(
                string mailgunResourceUri = null,
                string mailgunApiKey_Cipher = null,

                // This should allow a certain degree of flexibility
                //
                string fromAddress = null,
                string replyToAddress = null,
                string postmasterAddress = null)
        {
            var output = new MailgunConfig();

            output.MailgunResource = mailgunResourceUri;
            output.MailgunApiKey_Cipher = mailgunApiKey_Cipher;

            output.FromAddress = fromAddress;
            output.ReplyToAddress = replyToAddress;
            output.PostmasterAddress = postmasterAddress;
            
            return output;
        }
    }
}

