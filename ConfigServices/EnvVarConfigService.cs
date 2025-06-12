using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigServices
{
    public class EnvVarConfigService : IConfigService
    {
        public string GetConfig(string config)
        {
            return Environment.GetEnvironmentVariable(config);
        }
    }
}
