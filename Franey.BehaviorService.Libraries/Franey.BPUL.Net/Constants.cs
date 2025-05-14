namespace Franey.BPUL.Net

{
    public static class Verbiage
    {
        public const string ResponseNotimplemented = @"No Response was Implemented for passing Rule.";
        public const string ResponseNodefault = @"Default Handler(s) (Message) not implemented or not roperly set.";
        public const string NoDefaultFactory = @"No Default Handling Factory Detected in Chain";


        public const string Entitydesc = "{type} {action}\n";
        public const string TypeChainstrategy = @"This Chain Strategy Provider";
        public const string TypeConcurrenttrategy = @"This Concurrent Strategy Provider";
        public const string TypeUow = @"This Unit of Work";
        public const string TypeChainfactory = @"This Chain Handler";
        public const string TypeDefchainfactory = @"This Default Chain Handler";

        public const string Init = @"is Instantiating.";
        public const string Dispose = @"is Disposing.";
        public const string Eol = "\n";
    }

    public static class Codes
    {
        public const string Failed = @"Failed";
        public const string Ok = @"Ok";
        public const string Successful = @"Successful";
        public const string Error = @"Error";
        public const string Warning = @"Warning";
        public const string FullChainNotSatisified = @"NoSet";
    }
}
