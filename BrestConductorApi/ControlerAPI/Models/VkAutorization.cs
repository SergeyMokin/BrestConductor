using VkNet;
using VkNet.Enums.Filters;
using System.IO;
using System;

namespace ControlerAPI.Models
{
    public class VkAutorization
    {
        private VkApi api;
        private ApiAuthParams parametrs;

        public VkAutorization(VkApi _api)
        {
            api = _api;
            InstallVkParams(6271941, File.ReadAllText(@"D:\Login.txt"), File.ReadAllText(@"D:\Password.txt"), Settings.Wall);
            VkAutorize();
        }

        public void InstallVkParams(ulong _applicationId, string _login, string _password, Settings _settings)
        {
            parametrs = new ApiAuthParams
            {
                ApplicationId = _applicationId,
                Login = _login,
                Password = _password,
                Settings = _settings
            };
        }

        public void VkAutorize()
        {
            try
            {
                api.Authorize(parametrs);
            }
            catch
            {
                throw new Exception("Can't login in vk...");
            }
        }
    }
}