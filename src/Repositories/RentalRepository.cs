using System;
using System.Collections.Generic;
using System.Net.Http;
using Archive.CDManagement.Frontend.Configuration;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly HttpClient _httpClient;

        public RentalRepository(HttpClient httpClient, MySettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.CDApiUrl);
        }

        public void Create(RentalModel rental)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(RentalModel rental)
        {
            throw new NotImplementedException();
        }
        public RentalModel Read(int id)
        {
            var response = _httpClient.GetAsync($"api/rental/{id}").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<RentalModel>(content);
        }

        public List<RentalModel> GetAll()
        {
            var response = _httpClient.GetAsync($"api/rentals").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<RentalModel>>(content);
        }

    }
}