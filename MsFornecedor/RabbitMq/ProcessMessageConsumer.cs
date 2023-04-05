using Microsoft.Extensions.Options;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Repositorys.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace MsFornecedor.RabbitMq
{
    public class ProcessMessageConsumer : BackgroundService
    {
        private readonly RabbitMqConfiguration _configuration;

        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IRepositoryBairro _repository;
        public ProcessMessageConsumer(IOptions<RabbitMqConfiguration> option,IRepositoryBairro bairro)
        {
            _repository = bairro;
            _configuration = option.Value;
            var factory = new ConnectionFactory
            {
                HostName = "mensageria.prismafive.com.br",
                UserName = "maconha",
                Password = "151580"
            };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();

            _channel.QueueDeclare("AdicionarBairro", durable: true, exclusive: false, autoDelete: false, arguments: null);

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var meesage1 = JsonSerializer.Deserialize<Bairro>(message);
                _repository.AdicionarBairro(meesage1);
                //chamar repository

                _channel.BasicAck(e.DeliveryTag, false);
            };

            _channel.BasicConsume("AdicionarBairro", false, consumer);

            return Task.CompletedTask;
        }

    }
}
