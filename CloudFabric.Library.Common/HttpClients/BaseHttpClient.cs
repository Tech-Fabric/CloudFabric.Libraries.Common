﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CloudFabric.Library.Common.HttpClients
{
    public abstract class BaseHttpClient<TEntity> : IBaseHttpClient<TEntity> where TEntity : class
    {
        protected readonly HttpClient _client;
        public BaseHttpClient(HttpClient client)
        {
            _client = client;
        }
        public async Task<TEntity> GetAsync(string uri = "")
        {
            var response = await _client.GetAsync(uri);
            var jsonString = await response.Content.ReadAsStringAsync();
            return Deserialize(jsonString);
        }

        public async Task<TEntity> PostAsync(string uri, TEntity entity)
        {
            return await PostAsync<TEntity>(uri, entity);
        }

        public async Task<TEntity> PostAsync<TBody>(string uri, TBody body)
        {
            var response = await _client.PostAsync(uri, Encode(body));
            var jsonString = await response.Content.ReadAsStringAsync();
            return Deserialize(jsonString);
        }

        public async Task<TEntity> PutAsync(string uri, TEntity body)
        {
            return await PutAsync<TEntity>(uri, body);
        }

        public async Task<TEntity> PutAsync<TBody>(string uri, TBody body)
        {
            var response = await _client.PutAsync(uri, Encode(body));
            var jsonString = await response.Content.ReadAsStringAsync();
            return Deserialize(jsonString);
        }

        protected TEntity Deserialize(string content)
        {
            return JsonConvert.DeserializeObject<TEntity>(content);
        }


        protected ByteArrayContent Encode(TEntity body)
        {
            return Encode<TEntity>(body);
        }
        protected ByteArrayContent Encode<TBody>(TBody body)
        {
            var jsonContent = JsonConvert.SerializeObject(body);
            var buffer = Encoding.UTF8.GetBytes(jsonContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}
