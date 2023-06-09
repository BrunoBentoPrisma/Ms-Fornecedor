﻿using Microsoft.Extensions.Options;
using MsFornecedor.Repositorys.Entidades;
using MsFornecedor.Repositorys.Interfaces;
using MsFornecedor.Repositorys.Repository;
using MsFornecedor.Services.Interfaces;
using MsFornecedor.Services.Service;
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
        private readonly IRepositoryFornecedor _repositoryBairro;
        private const string ExchangeName = "AdicionarBairro";
        string QueueName = string.Empty;
        public ProcessMessageConsumer(IOptions<RabbitMqConfiguration> option, IRepositoryFornecedor repositoryBairro)
        {
            _repositoryBairro = repositoryBairro;
            _configuration = option.Value;
            var factory = new ConnectionFactory
            {
                HostName = "mensageria.prismafive.com.br",
                UserName = "maconha",
                Password = "151580"
            };
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();

            //_channel.QueueDeclare("AdicionarBairro", durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Fanout);
            QueueName = _channel.QueueDeclare().QueueName;
            _channel.QueueBind(QueueName, ExchangeName, "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var bairro = JsonSerializer.Deserialize<Bairro>(message);
                _repositoryBairro.AdicionarBairro(bairro);
                //_repositoryBairro.AdicionarBairro(meesage1);
                //chamar repository

                _channel.BasicAck(e.DeliveryTag, false);
            };

            _channel.BasicConsume(QueueName, false, consumer);

            return Task.CompletedTask;
        }

    }
}
