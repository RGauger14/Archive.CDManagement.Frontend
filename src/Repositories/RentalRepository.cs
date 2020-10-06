using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
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

        public void RemoveRentalItem(int rentalId, int rentalItemId)
        {
            var response = _httpClient.DeleteAsync($"api/rental/{rentalId}/rentalItem/{rentalItemId}").GetAwaiter().GetResult();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Could not remove rental item with id {rentalItemId} from rental with id {rentalId}");
            }
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

        public void AddRentalItem(RentalItemModel rentalItem)
        {
            var content = new StringContent(JsonConvert.SerializeObject(rentalItem), Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = _httpClient.PostAsync($"api/rental/rentalItem", content).GetAwaiter().GetResult();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Could not add rental item to rental");
            }
        }

        public void ReturnRental(int id)
        {
            var response = _httpClient.GetAsync($"api/rental/{id}/return").GetAwaiter().GetResult();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Could not return rental");
            }
        }
    }
}