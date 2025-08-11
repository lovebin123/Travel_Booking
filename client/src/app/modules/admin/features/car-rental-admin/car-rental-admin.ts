import { Component, inject, TemplateRef } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CarRentalService } from '../../../../common/services/CarRental/car-rental.service';

@Component({
  selector: 'app-car-rental-admin',
  standalone: false,
  templateUrl: './car-rental-admin.html',
  styleUrl: './car-rental-admin.css'
})
export class CarRentalAdmin {
searchByCarName() {
this.carRental.searchByCarName(this.searchQuery).subscribe({
  next:(response)=>{
    this.data=response.result;
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
      this.totalRecords=resposne.result.totalCount;
      this.data=resposne.result.carRentals;
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
