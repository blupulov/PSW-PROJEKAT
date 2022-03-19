using bolnica_back.Protos;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace bolnica_back.GrpcServices
{
    public class TestService : IHostedService
    {

        private Channel channel;
        private SpringGrpcService.SpringGrpcServiceClient client;

        public TestService() {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringGrpcService.SpringGrpcServiceClient(channel);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            channel?.ShutdownAsync();
            return Task.CompletedTask;
        }

        public async void SendMessage()
        {
            try
            {
                MessageResponseProto response = await client.communicateAsync(new MessageProto() { Message = "PROSLO", RandomInteger = new Random().Next(1, 101) });
                Console.WriteLine(response.Response + " is response; status: " + response.Status);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.StackTrace);
            }
        }
    }
}
