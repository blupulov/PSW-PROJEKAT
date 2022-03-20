using bolnica_back.Protos;
using Grpc.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace bolnica_back.GrpcServices
{
    public class PurchaseDrugService : IHostedService
    {
        private Channel channel;
        private SpringDrugPurchaseService.SpringDrugPurchaseServiceClient client;
            
        public PurchaseDrugService()
        {
            channel = new Channel("127.0.0.1:8787", ChannelCredentials.Insecure);
            client = new SpringDrugPurchaseService.SpringDrugPurchaseServiceClient(channel);
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

        public async void SendMessageForPurchase(string drugName, int quantity)
        {
            try
            {
                ResponseForDrugPurchase response = await client.purchaseDrugAsync(new RequestForDrugPurchase
                {
                    DrugName = drugName,
                    DrugQuantity = quantity
                });

                //ODGOVOR SAMO PREKO MEJLA
                if (response.Status.Equals("200"))
                    System.Diagnostics.Debug.WriteLine(response.Response);
                else
                    System.Diagnostics.Debug.WriteLine(response.Response);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }
    }
}
