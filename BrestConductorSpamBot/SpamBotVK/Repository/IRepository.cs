using System;
using System.Collections.Generic;
namespace SpamBotVK.Repository
{
    interface IRepository
    {
        Dictionary<int, Tuple<string, string>> GetBusstations();

        void InitializeBusstations();
    }
}
