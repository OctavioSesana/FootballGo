using System.Net.Http.Headers;
using System.Net.Http.Json;
using Domain.Model;

namespace API.Clients
{
    public static class ReservaApiClient
    {
        private static readonly HttpClient client = new();

        static ReservaApiClient()
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(30);
        }

        public static async Task<Reserva> GetAsync(int id)
        {
            try
            {
                var response = await client.GetAsync($"reservas/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var reserva = await response.Content.ReadFromJsonAsync<Reserva>();
                    if (reserva == null)
                        throw new Exception("Respuesta vacía al obtener reserva.");
                    return reserva;
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener reserva con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener reserva con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener reserva con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<Reserva>> GetAllAsync()
        {
            try
            {
                var response = await client.GetAsync("reservas");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Reserva>>()
                           ?? Enumerable.Empty<Reserva>();
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al obtener lista de reservas. Status: {response.StatusCode}, Detalle: {errorContent}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al obtener lista de reservas: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al obtener lista de reservas: {ex.Message}", ex);
            }
        }

        public static async Task<Reserva> AddAsync(Reserva reserva)
        {
            var response = await client.PostAsJsonAsync("reservas", reserva);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al crear reserva. Status: {response.StatusCode}. {error}");
            }

            var created = await response.Content.ReadFromJsonAsync<Reserva>();
            if (created == null)
                throw new Exception("La API no devolvió la reserva creada.");
            return created;
        }

        public static async Task UpdateAsync(Reserva reserva)
        {
            try
            {
                var response = await client.PutAsJsonAsync("reservas", reserva);
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al actualizar reserva con Id {reserva.IdReserva}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al actualizar reserva con Id {reserva.IdReserva}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al actualizar reserva con Id {reserva.IdReserva}: {ex.Message}", ex);
            }
        }

        public static async Task DeleteAsync(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"reservas/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error al eliminar reserva con Id {id}. Status: {response.StatusCode}, Detalle: {errorContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al eliminar reserva con Id {id}: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al eliminar reserva con Id {id}: {ex.Message}", ex);
            }
        }

        public static async Task<IEnumerable<Reserva>> GetByCriteriaAsync(string texto)
        {
            try
            {
                var response = await client.GetAsync($"reservas/criteria?texto={Uri.EscapeDataString(texto)}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Reserva>>()
                           ?? Enumerable.Empty<Reserva>();
                }

                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al buscar reservas. Status: {response.StatusCode}, Detalle: {errorContent}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error de conexión al buscar reservas: {ex.Message}", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception($"Timeout al buscar reservas: {ex.Message}", ex);
            }
        }
    }
}
