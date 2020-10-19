using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using Archive.CDManagement.Frontend.Configuration;
using Archive.CDManagement.Frontend.Models;
using Archive.CDManagement.Frontend.Models.Reports;
using Archive.CDManagement.Frontend.Repositories.Abstractions;
using Newtonsoft.Json;

namespace Archive.CDManagement.Frontend.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private HttpClient _httpClient;

        public ReportRepository(HttpClient httpClient, MySettings settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.CDApiUrl);
        }

        public List<ReportModel> GetAll()
        {
            var response = _httpClient.GetAsync($"api/rental").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<ReportModel>>(content);
        }

        public List<CDRentedModel> GetAllCdRentedCount()
        {
            var response = _httpClient.GetAsync("api/report/allcdrentalcount").GetAwaiter().GetResult();
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<CDRentedModel>>(content);
        }

        public Stream GetRentalsCsv(int staffIdFilter, int cdIdFilter)
        {
            var response = _httpClient.GetAsync($"api/report/rentalreport?staffId={staffIdFilter}&cdId={cdIdFilter}").GetAwaiter().GetResult();
            return response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
        }

        public Stream GetCdCountCsv()
        {
            var response = _httpClient.GetAsync("api/report/cdcountreport").GetAwaiter().GetResult();
            return response.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
        }
    }
}