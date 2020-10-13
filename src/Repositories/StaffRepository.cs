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
    public class StaffRepository : IStaffRepository
    {
        private readonly HttpClient _httpClient;

        public StaffRepository(HttpClient httpClient, MySettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.CDApiUrl);
        }

        public void Create(StaffModel staff)
        {
            var serializeStaff = JsonConvert.SerializeObject(staff);
            var requestContent = new StringContent(serializeStaff, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = _httpClient.PutAsync($"api/staff", requestContent).GetAwaiter().GetResult();

            if(response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Could not create Staff Member");
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(StaffModel staff)
        {
            var serialzeStaff = JsonConvert.SerializeObject(staff);
            var requestContent = new StringContent(serialzeStaff, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = _httpClient.PostAsync($"api/staff", requestContent).GetAwaiter().GetResult();

            if(response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Could not edit Staff Member");
            }
        }

        public List<StaffModel> GetAll()
        {
            var response = _httpClient.GetAsync($"api/Staff").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<StaffModel>>(content);
        }

        public StaffModel Read(int id)
        {
            var response = _httpClient.GetAsync($"api/staff/{id}").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<StaffModel>(content);
        }
    }
}