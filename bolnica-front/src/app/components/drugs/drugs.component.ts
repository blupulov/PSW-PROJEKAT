import { Component, OnInit } from '@angular/core';
import { DrugDTO } from 'src/app/Models/drugDTO';
import { MakeDrugDTO } from 'src/app/Models/makeDrugDTO';
import { DrugService } from 'src/app/services/drug.service';

@Component({
  selector: 'app-drugs',
  templateUrl: './drugs.component.html',
  styleUrls: ['./drugs.component.css']
})

export class DrugsComponent implements OnInit {

  allDrugs: DrugDTO[] = new Array<DrugDTO>();
  drug: MakeDrugDTO = new MakeDrugDTO();
  mode: string = 'add';
  selectedDrug: string;
  quantity: number;

  constructor(private drugService: DrugService) { }

  ngOnInit(): void {
    this.loadAllDrugs();
  }

  loadAllDrugs(){
    this.drugService.getAllDrugs().subscribe(
      res => {
        this.allDrugs = res;
      }
    )
  }

  onSubmit(){
    this.drugService.createDrug(this.drug).subscribe(
      res => {
        alert('Drug created');
        this.loadAllDrugs();
      },
      err => {
        alert('Drug is not created');
      }
    )
  }

  onSubmitProcure(){
    this.drugService.procureDrug(this.selectedDrug, this.quantity).subscribe(
      res => {
        alert('The drug was successfully procured');
        this.procureDrugMod();
      }
    )
  }  

  addDrugMod(){
    this.drug = new MakeDrugDTO();
    this.mode = 'add';
  }

  procureDrugMod(){
    this.selectedDrug = '';
    this.quantity = 0;
    this.mode = 'procure';
  }
}
