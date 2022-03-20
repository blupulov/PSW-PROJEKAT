package com.example.apotekabek.grpcService;

import com.example.apotekabek.grpcDto.RequestForDrugPurchaseDto;
import com.example.apotekabek.service.DrugService;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;
import org.springframework.beans.factory.annotation.Autowired;
import rs.ac.uns.ftn.grpc.RequestForDrugPurchase;
import rs.ac.uns.ftn.grpc.ResponseForDrugPurchase;
import rs.ac.uns.ftn.grpc.SpringDrugPurchaseServiceGrpc;

@GrpcService
public class DrugPurchaseService extends SpringDrugPurchaseServiceGrpc.SpringDrugPurchaseServiceImplBase {
    @Autowired
    private DrugService drugService;

    @Override
    public void purchaseDrug(RequestForDrugPurchase req, StreamObserver<ResponseForDrugPurchase> responseObserver){
        System.out.println("Drug name: " + req.getDrugName() + ", drug quantity: " + req.getDrugQuantity());

        RequestForDrugPurchaseDto dto = new RequestForDrugPurchaseDto(req.getDrugName(), req.getDrugQuantity());

        ResponseForDrugPurchase response;

        if(drugService.processRequestForDrugPurchase(dto))
            response = ResponseForDrugPurchase.newBuilder()
                    .setResponse("Successful transaction.")
                    .setStatus("200").build();
        else
            response = ResponseForDrugPurchase.newBuilder()
                    .setResponse("There are not required drugs in the warehouse.")
                    .setStatus("404").build();
        
        responseObserver.onNext(response);
        responseObserver.onCompleted();
    }
}
