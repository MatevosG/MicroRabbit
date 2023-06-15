using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;

        public TransferService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:7277/api/Banking";

            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, transferContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
