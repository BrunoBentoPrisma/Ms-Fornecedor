using MsFornecedor.RabbitMqClient.Intefaces;
using RabbitMQ.Client;

namespace MsFornecedor.RabbitMqClient.RabbitMqClient
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _model;

        public RabbitMqClient(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new ConnectionFactory() { HostName = _configuration["MsBairro"], Port = 8200 }.CreateConnection();
            _model = _connection.CreateModel();
            _model.ExchangeDeclare(exchange: "trigger", ExchangeType.Fanout);
        }

        public void GetBairro()
        {
            throw new NotImplementedException();
        }
    }
}
