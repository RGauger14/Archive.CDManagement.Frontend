using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Archive.CDManagement.Frontend.Configuration;
using Archive.CDManagement.Frontend.Models;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Repositories
{
    public class StaffRepository
    {
        private readonly HttpClient _httpClient;

        public StaffRepository(HttpClient httpClient, MySettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.CDApiUrl);
        }

        public void Create(StaffModel staff)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(StaffModel staff)
        {
            throw new NotImplementedException();
        }
        public StaffModel Read(int id)
        {
            var response = _httpClient.GetAsync($"api/staff/{id}").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<StaffModel>(content);

        }
    }
}
