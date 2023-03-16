using ProtoBuf;
using ProtoBuf.Serializers;
using System.Net;
using System.Text;
using System.Text.Json;

namespace TicTacToeAPI.Utils
{
    public static class HttpListenerExtension
    {
        public static async Task SendTextAsync(this HttpListenerResponse response, string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            response.ContentLength64 = buffer.Length;
            using (Stream stream = response.OutputStream)
            {
                await stream.WriteAsync(buffer);
                await stream.FlushAsync();
            }
            response.Close();
        }

        public static Task SendJsonAsync<T>(this HttpListenerResponse response, T data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true,
            });
            return response.SendTextAsync(json);
        }

        public static void SendProto<T>(this HttpListenerResponse response, T data)
        {
            Serializer.Serialize(response.OutputStream, data);
            response.Close();
        }
    }
}