using Flurl.Http;
using recipe_guru.Model;
using recipe_guru.WPFDesktopApp.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace recipe_guru.WPFDesktopApp
{
    class APIService
    {

        public string _apiUrl = $"{Resources.ApiUrl}";

        public static int UserId { get; set; }
        public static recipe_guru.Model.Korisnik User { get; set; }
        public static string Username { get; set; }
        public static string Password { get; set; }

        private readonly string _route;

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> GetAll<T>(object searchRequest = null)
        {
            try
            {
                var query = "";
                if (searchRequest != null)
                {
                    query = await searchRequest.ToQueryString();
                }

                var list = await $"{_apiUrl}/{_route}?{query}"
                    .WithBasicAuth(Username, Password)
                    .GetJsonAsync<T>();
                return list;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Wrong Username or Pasword", "Error", MessageBoxButton.OK);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Error", MessageBoxButton.OK);

                }
                throw;
            }
        }


        public async Task<T> Get<T>(object search)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Wrong Username or Pasword", "Error", MessageBoxButton.OK);
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden", "Error", MessageBoxButton.OK);

                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButton.OK);

                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{_apiUrl}/{_route}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error", MessageBoxButton.OK);
                return default(T);
            }

        }
    }
}
