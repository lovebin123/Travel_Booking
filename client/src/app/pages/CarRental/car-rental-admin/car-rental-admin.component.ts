import { Component, inject, OnInit, TemplateRef } from '@angular/core';
import { CarRentalListComponent } from "../../../components/cards/Car Rental/car-rental-list/car-rental-list.component";
import { CarRentalService } from '../../../services/CarRental/car-rental.service';
import { NgbModal, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CarRemtalAddUpdateModalComponent } from "../../../components/cards/Car Rental/car-remtal-add-update-modal/car-remtal-add-update-modal.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-car-rental-admin',
  standalone: true,
  imports: [CarRentalListComponent, CarRemtalAddUpdateModalComponent,NgbToastModule,CommonModule,FormsModule],
  templateUrl: './car-rental-admin.component.html',
  styleUrl: './car-rental-admin.component.scss'
})
export class CarRentalAdminComponent implements OnInit {
  constructor(private carRental:CarRentalService){}
  data:any;
ngOnInit(): void {
  this.loadData();
}
modal=inject(NgbModal);
addSuccessfull=false;
loadData()
{
  this.carRental.getAllCarRentals().subscribe({
    next:(resposne:any)=>{
      console.log(resposne);
      this.data=resposne;
    }
  })
}
add(content:TemplateRef<any>)
{
  const modalRef=this.modal.open(content,{centered:true,size:'lg'});
  modalRef.result.catch((data)=>{
    this.addSuccessfull=data;
  })
}
handleChange(event:any)
{
  this.loadData();
}
}
