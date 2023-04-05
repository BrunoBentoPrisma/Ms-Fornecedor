using MsFornecedor.RabbitMqClient.Intefaces;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;

namespace MsFornecedor.RabbitMqClient.RabbitMqClient
{
    public class RabbitMqConsumerBairro : IRabbitMqConsumerBairro
    {
        private IConnection _connection;
        private readonly string _hostName;
        private readonly string _userName;
        private readonly string _password;

        public RabbitMqConsumerBairro()
        {
            _hostName = "mensageria.prismafive.com.br";
            _userName = "prismafive";
            _password = "prixpto";
        }


        public void EditBairro()
        {
            throw new NotImplementedException();
        }

        public void DeleteBairro()
        {
            throw new NotImplementedException();
        }

        public void AdicionarBairro()
        {
            var factory = new ConnectionFactory
            {
                UserName = _userName,
                Password = _password,
                HostName = _hostName
            };

            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();

            channel.QueueDeclare(queue: "AdicionarBairro", false, false, false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
            };

            channel.BasicConsume("AdicionarBairro", true, consumer);
        }
    }


}
