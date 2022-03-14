import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DoctorDTO } from 'src/app/Models/doctorDTO';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-all-specialists',
  templateUrl: './all-specialists.component.html',
  styleUrls: ['./all-specialists.component.css']
})
export class AllSpecialistsComponent implements OnInit {

  doctors: DoctorDTO[] = new Array<DoctorDTO>();

  constructor(private doctorService: DoctorService, private router: Router) { }

  ngOnInit(): void {
    this.loadAllSpecialists();
  }

  loadAllSpecialists(){
    this.doctorService.getAllSpecialistDoctors().subscribe(
      res => {
        this.doctors = res;
      }
    )
  }

  selectDoctor(doctor: DoctorDTO){
    this.doctorService.selectedDoctor = doctor;
    this.router.navigateByUrl('/specialistProfile');
  }

}
