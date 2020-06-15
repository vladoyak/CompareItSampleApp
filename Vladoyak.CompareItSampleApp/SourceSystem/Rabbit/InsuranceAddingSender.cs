using RabbitMQ.Client;
using SourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SourceSystem.Rabbit
{
    public class InsuranceAddingSender : IInsuranceAddingSender
    {
        string _hostName;
        string _queueName;

        public InsuranceAddingSender()
        {
            _hostName = "localhost";
            _queueName = "sourcesystem";
        }

        public void SendInsurance(Insurance insurance)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(_queueName, false, false, false, null);
                var json = JsonSerializer.Serialize<Insurance>(insurance);
                var body = Encoding.UTF8.GetBytes(json);
                channel.BasicPublish("", _queueName, null, body);
            }
        }
    }
}
