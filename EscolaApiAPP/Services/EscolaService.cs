using EscolaApiAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EscolaApiAPP.Services
{
    public class EscolaService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        private const string BaseUrl = "http://localhost:5116/Escola"; 

        public EscolaService()
        {
            _httpClient = new HttpClient();
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // GET: /Escola/GetAll
        public async Task<List<Escola>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Escola>>($"{BaseUrl}/GetAll", _jsonOptions);
        }

        // GET: /Escola/{codEscola}
        public async Task<Escola> GetByCodEscolaAsync(string codEscola)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/{codEscola}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Escola>(_jsonOptions);
            }
            return null;
        }

        // POST: /Escola/Cadastrar
        public async Task<bool> CadastrarAsync(Escola escola)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Cadastrar", escola);
            return response.IsSuccessStatusCode;
        }

        // PUT: /Escola/Atualizar
        public async Task<bool> AtualizarAsync(Escola escola)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/Atualizar", escola);
            return response.IsSuccessStatusCode;
        }

        // DELETE: /Escola/{codEscola}
        public async Task<bool> DeletarAsync(string codEscola)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{codEscola}");
            return response.IsSuccessStatusCode;
        }
    }
}
