import { Component, inject, OnInit, TemplateRef } from '@angular/core';
import { CarRentalListComponent } from "../../../components/cards/Car Rental/car-rental-list/car-rental-list.component";
import { CarRentalService } from '../../../services/CarRental/car-rental.service';
import { NgbModal, NgbPaginationModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CarRemtalAddUpdateModalComponent } from "../../../components/cards/Car Rental/car-remtal-add-update-modal/car-remtal-add-update-modal.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-car-rental-admin',
  standalone: true,
  imports: [CarRentalListComponent, CarRemtalAddUpdateModalComponent,NgbToastModule,CommonModule,FormsModule,NgbPaginationModule],
  templateUrl: './car-rental-admin.component.html',
  styleUrl: './car-rental-admin.component.scss'
})
export class CarRentalAdminComponent implements OnInit {
searchByCarName() {
this.carRental.searchByCarName(this.searchQuery).subscribe({
  next:(response)=>{
    this.data=response;
  }
})

}
searchQuery: any;
  constructor(private carRental:CarRentalService){}
  data:any;
ngOnInit(): void {
  this.loadData();
}
modal=inject(NgbModal);
addSuccessfull=false;
totalRecords=0;
pageSize=6;
page=1;
loadData()
{
  this.carRental.getAllCarRentals(this.pageSize,this.page).subscribe({
    next:(resposne:any)=>{
      console.log(resposne);
      this.totalRecords=resposne.totalCount;
      this.data=resposne.carRentals;
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
onPageChange(page:number)
{
  this.page=page;
  this.loadData();
}
handleChange(event:any)
{
  this.loadData();
}
}
