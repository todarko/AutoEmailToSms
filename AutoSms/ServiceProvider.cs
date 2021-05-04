using System;
using System.Collections.Generic;
using System.Text;

namespace AutoSms
{
    public struct TextServiceProvider
    {
        public const string AttSms = "@txt.att.net";
        public const string AttMms = "@mms.att.net";
        public const string BoostMobileSms = "@sms.myboostmobile.com";
        public const string BoostMobileMms = "@myboostmobile.com";
        public const string SprintSms = "@messaging.sprintpcs.com";
        public const string SprintMms = "@pm.sprint.com";
        public const string TmobileSms = "@tmomail.net";
        public const string TmobileMms = "@tmomail.net";
        public const string VerizonSms = "@vtext.com";
        public const string VerizonMms = "@vzwpix.com";
        public const string VirginMobileSms = "@vmobl.com";
        public const string VirginMobileMms = "@vmpix.com";
        public const string XfinityMobileSms = "@vtext.com";
        public const string XfinityMobileMms = "@mypixmessages.com";
    }

    public struct EmailServiceProvider
    {
        public const string Gmail = "smtp.gmail.com";
        public const string Microsoft = "smtp.office365.com";
        public const string Yahoo = "smtp.mail.yahoo.com";
    }
}
