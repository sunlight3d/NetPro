﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using HttpClientApplication.Host.Models;
using System.Runtime.Serialization.Json;

namespace HttpClientApplication.Client
{
    class Program
    {
        static  async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync("https://localhost:44358/api/destinations");
                Console.WriteLine("Respone data as string");
                string resultAsString = await message.Content.ReadAsStringAsync();
                Console.WriteLine(resultAsString);
                List<Destination> destinationsResult = await message.Content.ReadAsAsync<List<Destination>>();
                Console.WriteLine("\nAll Destination");
                foreach (Destination destination in destinationsResult)
                {
                    Console.WriteLine($"{destination.CityName} - {destination.Airport}");
                }

                // ReadKey used that the console will not close when the code end to run.
                Console.ReadKey();

            }
        }
    }
}
