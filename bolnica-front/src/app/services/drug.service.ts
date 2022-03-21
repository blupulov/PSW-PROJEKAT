import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DrugDTO } from "../Models/drugDTO";
import { MakeDrugDTO } from "../Models/makeDrugDTO";

@Injectable({
  providedIn: 'root'
})

export class DrugService{

  private apiServerUrl = 'http://localhost:31236/api/drug';

  constructor(private http:HttpClient) {}

  getAllDrugs(){
    return this.http.get<DrugDTO[]>(this.apiServerUrl);
  }

  createDrug(drug: MakeDrugDTO){
    return this.http.post(this.apiServerUrl, drug);
  }

  procureDrug(drugName: string, quantity: number){
    return this.http.post(this.apiServerUrl + '/procure/' + drugName + '/' + quantity, {});
  }
  
}