using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BackendService.Rabbit
{
    public class InsuranceAddingReceiver : BackgroundService
    {
        string _hostName = "localhost";
        private IConnection _connection;
        private IModel _channel;
        private string _queueName;

        public InsuranceAddingReceiver()
        {
            _queueName = "sourcesystem";
            InitializeRabbitMQListener();

        }

        private void InitializeRabbitMQListener()
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(_queueName, false, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.Span);
                var insurance = JsonSerializer.Deserialize<Insurance>(content);

                _channel.BasicAck(ea.DeliveryTag, false);
            };

            _channel.BasicConsume(_queueName, false, consumer);

            return Task.CompletedTask;
        }
    }
}
