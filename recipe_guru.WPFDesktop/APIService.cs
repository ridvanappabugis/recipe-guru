using Flurl.Http;
using recipe_guru.Model;
using recipe_guru.WPFDesktop.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace recipe_guru.WPFDesktop
{
    class APIService
    {
        public static string username;
        public static string password;
        public string _resource;
        public string endpoint = $"{Resources.ApiUrl}";

        public APIService(string resource)
        {
            _resource = resource;
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

                var list = await $"{endpoint}{_resource}?{query}"
                    .WithBasicAuth(username, password)
                    .GetJsonAsync<T>();
                return list;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Wrong username or password.");
                }
                if (ex.Call.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("Forbidden.");
                }
                throw;
            }
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{endpoint}{_resource}/{id}";

            return await url
                .WithBasicAuth(username, password)
                .GetJsonAsync<T>();
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}{_resource}";

            try
            {
                return await url
                    .WithBasicAuth(username, password)
                    .PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, {string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error");
                return default(T);
            }

        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{endpoint}{_resource}/{id}";

                return await url
                    .WithBasicAuth(username, password)
                    .PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString());
                return default(T);
            }

        }

        public async Task<T> Delete<T>(int id)
        {
            try
            {
                return await $"{endpoint}{_resource}/{id}"
                    .WithBasicAuth(username, password)
                    .DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Error");
                return default(T);
            }

        }
    }
}
