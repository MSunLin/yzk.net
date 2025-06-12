using System;
using System.Collections.Generic;
using System.Text;
using LogServices;
using ConfigServices;

namespace MailServices
{
    public class MailService: IMailService
    {
        private readonly ILogProvider log;
        private readonly IConfigService config; 

        public MailService(ILogProvider log, IConfigService config)
        {
            this.log = log;
            this.config = config;
        }

        public void Send(string title, string to, string body)
        {
            log.LogInfo($"准备发送邮件：");
            // 获取配置
            string smtpserver= config.GetConfig("SmtpServer");
            string UserName = config.GetConfig("UserName");
            string Password = config.GetConfig("Password");
            Console.WriteLine($"地址{smtpserver}，用户名{UserName},密码{Password}");
            Console.WriteLine($"发送邮件！{title}.{to}");
            log.LogInfo($"邮件内容：{body}");
            log.LogInfo($"邮件发送成功！");
        }
    }
}
