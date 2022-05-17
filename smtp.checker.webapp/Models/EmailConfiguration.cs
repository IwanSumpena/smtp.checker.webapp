namespace smtp.checker.webapp.Models
{
    public class EmailConfiguration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public bool IsBodyHtml { get; set; }
        public bool EnableSsl { get; set; }
    }
}
