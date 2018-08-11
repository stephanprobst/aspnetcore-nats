using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;
using Newtonsoft.Json;

namespace Probst.AspNetCore.Nats
{
    public static class NatsExtension
    {
        public static IServiceCollection AddNats(this IServiceCollection services, Action<Options> configOptions)
        {
            services.AddSingleton<ConnectionFactory>();

            var options = ConnectionFactory.GetDefaultOptions();
            configOptions(options);

            services.AddSingleton<Options>(options);

            services.AddSingleton<IConnection>(provider =>
            {
                var connectionFactory = provider.GetRequiredService<ConnectionFactory>();

                return connectionFactory.CreateConnection(provider.GetRequiredService<Options>());
            });

            services.AddSingleton<IJsonEncodedConnection>(provider =>
            {
                var connectionFactory = provider.GetRequiredService<ConnectionFactory>();

                var encodedConnection = connectionFactory.CreateEncodedConnection(provider.GetRequiredService<Options>());

                encodedConnection.OnSerialize = obj => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
                encodedConnection.OnDeserialize = bytes => JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes));

                return new JsonEncodedNatsConnection(encodedConnection);
            });

            services.AddSingleton<IEncodedConnection>(provider =>
            {
                var connectionFactory = provider.GetRequiredService<ConnectionFactory>();

                var encodedConnection = connectionFactory.CreateEncodedConnection(provider.GetRequiredService<Options>());

                encodedConnection.OnSerialize = obj => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
                encodedConnection.OnDeserialize = bytes => JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bytes));

                return encodedConnection;
            });

            return services;
        }
    }
}
