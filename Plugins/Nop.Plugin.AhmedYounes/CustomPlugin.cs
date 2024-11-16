using Nop.Services.Logging;
using Nop.Services.Plugins;

namespace Nop.Plugin.API.CRM
{
    public class CRMIntegrationPlugin : BasePlugin, IPlugin
    {
        private readonly ILogger _logger;

        public CRMIntegrationPlugin(ILogger logger)
        {
            _logger = logger;
        }

        public void Install()
        {
            _logger.Information("CRM Integration Plugin installed.");
            // Add installation logic (like database setup, etc.)
        }

        public void Uninstall()
        {
            _logger.Information("CRM Integration Plugin uninstalled.");
            // Add uninstallation logic (like cleaning up resources, removing settings, etc.)
        }
    }
}
