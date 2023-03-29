namespace Tutor.Infrastructure.Smtp
{
    public class EmailConfiguration
    {
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProxyAddress { get; set; }
        public int ProxyPort { get; set; }
    }
}
