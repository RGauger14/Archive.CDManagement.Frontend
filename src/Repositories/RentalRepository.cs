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

        public RentalModel Create(RentalModel rental)
        {
            var serializeRental = JsonConvert.SerializeObject(rental);
            var requestContent = new StringContent(serializeRental, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = _httpClient.PutAsync($"api/rental", requestContent).GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Could not Create Rental");
            }

            var responseContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var rentalResponse = JsonConvert.DeserializeObject<RentalModel>(responseContent);

            return rentalResponse;
        }

        public void Delete(int id)
        {
            var response = _httpClient.DeleteAsync($"api/rental/{id}").GetAwaiter().GetResult();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Could not remove Rental with id {id}");
            }
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