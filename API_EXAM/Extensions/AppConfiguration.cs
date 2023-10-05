using Microsoft.Extensions.Configuration;
using System.IO;


namespace API_EXAM
{
    public class AppConfiguration
    {
        private readonly string _jwtSecret = string.Empty;
        private readonly string _conString = string.Empty;
        private readonly string _adapterUrl = string.Empty;
        private readonly string _docsPath = string.Empty;
        private readonly string _courceCertFilePath = string.Empty;
        private readonly string _converter = string.Empty;
        private readonly string _camunda = string.Empty;
        private readonly string _camundaKey = string.Empty;
        private readonly string _templatePath = string.Empty;

        private readonly string _maiUserName = string.Empty;
        private readonly string _mailPassword = string.Empty;
        private readonly string _mailHost = string.Empty;
        private readonly string _mailPort = string.Empty;
        private readonly string _urlForMail = string.Empty;
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
             _jwtSecret = root.GetSection("ApplicationSettings").GetSection("jwt_secret").Value;
          
            //ConnectionString
            _conString = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            //Adapter
            _adapterUrl = root.GetSection("Adapter").GetSection("url").Value;
            _converter = root.GetSection("Adapter").GetSection("converter").Value;
            _camunda = root.GetSection("Adapter").GetSection("camunda").Value;
            _camundaKey = root.GetSection("Adapter").GetSection("camundaKey").Value;

            //Path
            _docsPath = root.GetSection("Template").GetSection("path").Value;
            _courceCertFilePath = root.GetSection("Template").GetSection("certFile").Value;
            _templatePath = root.GetSection("Template").GetSection("template").Value;

            _mailPort = root.GetSection("Mail").GetSection("Port").Value;
            _mailHost = root.GetSection("Mail").GetSection("Host").Value;
            _mailPassword = root.GetSection("Mail").GetSection("Password").Value;
            _maiUserName = root.GetSection("Mail").GetSection("Username").Value;

            //Message
            _urlForMail = root.GetSection("UrlForEmail").GetSection("url").Value;

        }

        public string TemplatePath
        {
            get => _templatePath;
        }
        public string UrlForEmail
        {
            get => _urlForMail;
        }

        public string MailUsername
        {
            get => _maiUserName;
        }
        public string MailPassword
        {
            get => _mailPassword;
        }
        public string MailHost
        {
            get => _mailHost;
        }
        public string MailPort
        {
            get => _mailPort;
        }



        public string AdapterUrl
        {
            get => _adapterUrl;
        }
        public string ConverterUrl
        {
            get => _converter;
        }
        public string CamundaUrl
        {
            get => _camunda;
        }
        public string CamundaKey
        {
            get => _camundaKey;
        }
        public string ConnectionString
        {
            get => _conString;
        }
        public string JWTSecret
        {
            get => _jwtSecret;
        }

        public string DocsPath
        {
            get => _docsPath;
        }
        public string CourceCertFilePath
        {
            get => _courceCertFilePath;
        }
    }
}
