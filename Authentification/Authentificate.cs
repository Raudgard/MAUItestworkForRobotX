using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;

namespace MAUItestworkForRobotX.Authentification
{
    internal static class Authentificate
    {
        private const string authPath = "https://testwork.cloud39.ru/BonusWebApi/Account/Login";
        public static AuthResponseData? AuthResponseData { get; private set; }

        /// <summary>
        /// Посылает запрос авторизации на сервер.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Код статуса ответа сервера.</returns>
        public static async Task<HttpStatusCode> GetAuth(string login, string password)
        {
            AuthData authData = new AuthData { Login = login, Password = password };

            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            JsonContent content = JsonContent.Create(authData);
            using var response = await client.PostAsync(authPath, content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseJsonText = await response.Content.ReadAsStringAsync();
                AuthResponseData = JsonSerializer.Deserialize<AuthResponseData>(responseJsonText);
            }
            else
            {
                AuthResponseData = null;
            }

            return response.StatusCode;
        }

    }
}
