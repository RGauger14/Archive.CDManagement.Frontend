using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Archive.CDManagement.Frontend.Configuration;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;

namespace Archive.CDManagement.Frontend.Repositories
{
    public class CDRepository : ICDRepository
    {
        private readonly string _cdApiUrl;
        private readonly HttpClient httpClient;

        public CDRepository(HttpClient httpClient, MySettings settings)
        {
            _cdApiUrl = settings.CDApiUrl;
            this.httpClient = httpClient;
        }

        public void Create(CDModel cd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(CDModel cd)
        {
            throw new NotImplementedException();
        }

        public CDModel Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}
