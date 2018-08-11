using System;
using NATS.Client;

namespace Probst.AspNetCore.Nats
{
    internal class JsonEncodedNatsConnection : IJsonEncodedConnection
    {
        private readonly IEncodedConnection encodedConnection;

        public JsonEncodedNatsConnection(IEncodedConnection encodedConnection)
        {
            this.encodedConnection = encodedConnection;
        }

        public Options Opts => encodedConnection.Opts;

        public string ConnectedUrl => encodedConnection.ConnectedUrl;

        public string ConnectedId => encodedConnection.ConnectedId;

        public string[] Servers => encodedConnection.Servers;

        public string[] DiscoveredServers => encodedConnection.DiscoveredServers;

        public Exception LastError => encodedConnection.LastError;

        public ConnState State => encodedConnection.State;

        public IStatistics Stats => encodedConnection.Stats;

        public long MaxPayload => encodedConnection.MaxPayload;

        public Serializer OnSerialize { get => encodedConnection.OnSerialize; set => encodedConnection.OnSerialize = value; }

        public Deserializer OnDeserialize { get => encodedConnection.OnDeserialize; set => encodedConnection.OnDeserialize = value; }

        public void Close() => encodedConnection.Close();

        public void Dispose() => encodedConnection.Dispose();

        public void Flush(int timeout) => encodedConnection.Flush(timeout);

        public void Flush() => encodedConnection.Flush();

        public bool IsClosed() => encodedConnection.IsClosed();

        public bool IsReconnecting() => encodedConnection.IsReconnecting();

        public string NewInbox() => encodedConnection.NewInbox();

        public void Publish(string subject, object obj) => encodedConnection.Publish(subject, obj);

        public void Publish(string subject, string reply, object obj) => encodedConnection.Publish(subject, reply, obj);

        public object Request(string subject, object obj, int timeout) => encodedConnection.Request(subject, obj, timeout);

        public object Request(string subject, object obj) => encodedConnection.Request(subject, obj);

        public void ResetStats() => encodedConnection.ResetStats();

        public IAsyncSubscription SubscribeAsync(string subject, EventHandler<EncodedMessageEventArgs> handler) => encodedConnection.SubscribeAsync(subject, handler);

        public IAsyncSubscription SubscribeAsync(string subject, string queue, EventHandler<EncodedMessageEventArgs> handler) => encodedConnection.SubscribeAsync(subject, queue, handler);
    }
}