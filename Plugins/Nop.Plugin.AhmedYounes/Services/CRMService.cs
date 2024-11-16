using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Nop.Plugin.API.CRM.Services
{
    public class CRMService
    {
        private readonly ServiceClient _serviceClient;

        public CRMService()
        {
            var connectionString = "AuthType=ClientSecret;" +
                                   "Url=https://ititasks.crm11.dynamics.com/;" +
                                   "ClientId=cefdd43b-ca9d-4043-9285-9b9006c48f24;" +
                                   "ClientSecret=MVh8Q~MZWuW0IVTDJMq1yJP8npKZiQtraxvsNaEL;" +
                                   "Authority=https://login.microsoftonline.com/";

            _serviceClient = new ServiceClient(connectionString);

            if (!_serviceClient.IsReady)
            {
                throw new Exception("Unable to connect to Dynamics CRM.");
            }
        }

        public async Task<bool> CheckExistingCustomerByEmail(string email)
        {
            var query = new QueryByAttribute("contact")
            {
                ColumnSet = new ColumnSet("emailaddress1")
            };
            query.AddAttributeValue("emailaddress1", email);

            var result = await Task.Run(() => _serviceClient.RetrieveMultiple(query));
            return result.Entities.Count > 0;
        }

        public async Task<bool> CreateContactInCRM(string firstName, string lastName, string email)
        {
            try
            {
                var newContact = new Entity("contact")
                {
                    ["firstname"] = firstName,
                    ["lastname"] = lastName,
                    ["emailaddress1"] = email
                };

                await Task.Run(() => _serviceClient.Create(newContact));
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error creating contact: {ex.Message}");
                return false;
            }
        }
    }
}
