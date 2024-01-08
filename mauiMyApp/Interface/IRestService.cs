using System;
namespace mauiMyApp.Interface
{
    public interface IRestService
    {
        Task<string> Get(string url);

    }
}

