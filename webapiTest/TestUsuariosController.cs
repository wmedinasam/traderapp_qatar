using webapi.Models;
using webapi.Controllers;
using System.Collections.Generic;
using NuGet.Protocol;
using Microsoft.AspNetCore.Mvc.Testing;
using webapi;
using System.Net.Http.Json;

namespace webapiTest
{
    [TestClass]
    public class TestUsuariosController
    {
        private HttpClient _client;

        
        [TestMethod]
        public async Task GetUsuarioligas_ShouldReturnCorrectUsuarioLiga() 
        {
            // expected result.
            string expectedString = "{\"id\":1,\"nombre\":\"Admin\",\"pass\":\"123\",\"email\":\"admin@admin.com\",\"status\":1,\"tipo\":1,\"tipoNavigation\":null,\"fasegruposResultados\":[],\"usuarioligas\":[]}";

            // test
            var webAppFactory = new WebApplicationFactory<Program>();
            _client = webAppFactory.CreateDefaultClient();
            var response = await _client.GetAsync("/api/Usuarios/1");
            var stringResult = await response.Content.ReadAsStringAsync();
            Assert.AreEqual(expectedString, stringResult);
        }
    }
}
