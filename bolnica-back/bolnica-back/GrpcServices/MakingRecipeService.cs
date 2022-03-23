using bolnica_back.DTOs;
using bolnica_back.Protos;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace bolnica_back.GrpcServices
{
    public class MakingRecipeService : IHostedService
    {
        private Channel channel;
        private SpringRecipeMakingService.SpringRecipeMakingServiceClient client;

        public MakingRecipeService()
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringRecipeMakingService.SpringRecipeMakingServiceClient(channel);
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

        public async void SendMessageForRecipe(MakeRecipeGrpcDto dto)
        {
            try
            {
                ResponseForRecipeMaking res = await client.makeRecipeAsync(new RequestForRecipeMaking()
                {
                    Jmbg = dto.Jmbg, DrugName = dto.DrugName, Quantity = dto.Quantity
                });

                System.Diagnostics.Debug.WriteLine("Message: " + res.Message + ", Status: " + res.Status);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
