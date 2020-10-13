using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using Archive.CDManagement.Frontend.Configuration;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Repositories
{
    public class CDRepository : ICDRepository
    {
        private readonly HttpClient _httpClient;

        public CDRepository(HttpClient httpClient, MySettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.CDApiUrl);
        }

        public void Create(CDModel cd)
        {
            var serializeCD = JsonConvert.SerializeObject(cd);
            var requestContent = new StringContent(serializeCD, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = _httpClient.PutAsync($"api/cd", requestContent).GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Could not Create CD");
            }
        }

        public void Delete(int id)
        {
            var response = _httpClient.DeleteAsync($"api/cd/{id}").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Could not remove CD with id {id}");
            }
        }

        public void Edit(CDModel cd)
        {
            throw new NotImplementedException();
        }

        public CDModel Read(int id)
        {
            var response = _httpClient.GetAsync($"api/cd/{id}").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<CDModel>(content);
        }

        public List<CDModel> GetAll()
        {
            var response = _httpClient.GetAsync($"api/cds").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<CDModel>>(content);
        }
    }
}