
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;


namespace Project1UI
{
    public  class OrderService { 
    

        private readonly HttpClient _httpClient = new();
        
        
        public OrderService(Uri serverUri)
        {
            
            _httpClient.BaseAddress = serverUri;
        }

      
        public async Task<List<Order>> ListOrderDetailsOfLocationAsync(string locationID)
        {
            
            Dictionary<string, string> query = new() { ["locationID"] = locationID };
            string requestUri = QueryHelpers.AddQueryString("/api/Location", query);

            HttpRequestMessage request = new(HttpMethod.Get, requestUri);
            
            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                throw;// UnexpectedServerBehaviorException("network error", ex);
            }

            response.EnsureSuccessStatusCode(); 
          
            if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
            {
                
            }

            var orders = await response.Content.ReadFromJsonAsync<List<Order>>();
            if (orders == null)
            {
              
            }

            return orders;
        }

        public async Task<List<Order>> ListOrderDetailsOfCustomerAsync(string customerID)
        {

            Dictionary<string, string> query = new() { ["customer"] = customerID };
            string requestUri = QueryHelpers.AddQueryString("/api/Order", query);

            HttpRequestMessage request = new(HttpMethod.Get, requestUri);

            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                throw;// UnexpectedServerBehaviorException("network error", ex);
            }

            response.EnsureSuccessStatusCode();

            if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
            {

            }

            var orders = await response.Content.ReadFromJsonAsync<List<Order>>();
            if (orders == null)
            {

            }

            return orders;
        }
        public async Task PlaceOrderAsync(string customerID, string locationID, string date, string productID, string quantity)
        {

            Dictionary<string, string> query = new() { ["customerID"] = customerID, ["locationID"] = locationID, ["date"] = date, ["productID"] = productID,
            ["quantity"] = quantity};
            string requestUri = QueryHelpers.AddQueryString("/api/Order", query);

            HttpRequestMessage request = new(HttpMethod.Put, requestUri);

            request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.SendAsync(request);
            }
            catch (HttpRequestException ex)
            {
                throw;// UnexpectedServerBehaviorException("network error", ex);
            }

            response.EnsureSuccessStatusCode();

            if (response.Content.Headers.ContentType?.MediaType != MediaTypeNames.Application.Json)
            {

            }

            var orders = await response.Content.ReadFromJsonAsync<List<Order>>();
            if (orders == null)
            {

            }

            
        }
    }
}
