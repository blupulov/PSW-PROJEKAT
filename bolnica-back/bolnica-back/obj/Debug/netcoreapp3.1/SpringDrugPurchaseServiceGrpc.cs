// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/springDrugPurchaseService.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace bolnica_back.Protos {
  public static partial class SpringDrugPurchaseService
  {
    static readonly string __ServiceName = "rs.ac.uns.ftn.grpc.SpringDrugPurchaseService";

    static readonly grpc::Marshaller<global::bolnica_back.Protos.RequestForDrugPurchase> __Marshaller_rs_ac_uns_ftn_grpc_RequestForDrugPurchase = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::bolnica_back.Protos.RequestForDrugPurchase.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::bolnica_back.Protos.ResponseForDrugPurchase> __Marshaller_rs_ac_uns_ftn_grpc_ResponseForDrugPurchase = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::bolnica_back.Protos.ResponseForDrugPurchase.Parser.ParseFrom);

    static readonly grpc::Method<global::bolnica_back.Protos.RequestForDrugPurchase, global::bolnica_back.Protos.ResponseForDrugPurchase> __Method_purchaseDrug = new grpc::Method<global::bolnica_back.Protos.RequestForDrugPurchase, global::bolnica_back.Protos.ResponseForDrugPurchase>(
        grpc::MethodType.Unary,
        __ServiceName,
        "purchaseDrug",
        __Marshaller_rs_ac_uns_ftn_grpc_RequestForDrugPurchase,
        __Marshaller_rs_ac_uns_ftn_grpc_ResponseForDrugPurchase);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::bolnica_back.Protos.SpringDrugPurchaseServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for SpringDrugPurchaseService</summary>
    public partial class SpringDrugPurchaseServiceClient : grpc::ClientBase<SpringDrugPurchaseServiceClient>
    {
      /// <summary>Creates a new client for SpringDrugPurchaseService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public SpringDrugPurchaseServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SpringDrugPurchaseService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public SpringDrugPurchaseServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected SpringDrugPurchaseServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected SpringDrugPurchaseServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::bolnica_back.Protos.ResponseForDrugPurchase purchaseDrug(global::bolnica_back.Protos.RequestForDrugPurchase request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return purchaseDrug(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::bolnica_back.Protos.ResponseForDrugPurchase purchaseDrug(global::bolnica_back.Protos.RequestForDrugPurchase request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_purchaseDrug, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::bolnica_back.Protos.ResponseForDrugPurchase> purchaseDrugAsync(global::bolnica_back.Protos.RequestForDrugPurchase request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return purchaseDrugAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::bolnica_back.Protos.ResponseForDrugPurchase> purchaseDrugAsync(global::bolnica_back.Protos.RequestForDrugPurchase request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_purchaseDrug, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override SpringDrugPurchaseServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SpringDrugPurchaseServiceClient(configuration);
      }
    }

  }
}
#endregion