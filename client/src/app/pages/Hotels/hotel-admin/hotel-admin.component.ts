import { Component, inject, OnInit, TemplateRef } from '@angular/core';
import { HotelListComponent } from "../../../components/cards/Hotels/hotel-list/hotel-list.component";
import { HotelServiceService } from '../../../services/Hotels/hotel-service.service';
import { NgbModal, NgbPaginationModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { HotelAdminAddUpdateModalComponent } from "../../../components/cards/Hotels/hotel-admin-add-update-modal/hotel-admin-add-update-modal.component";
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-hotel-admin',
  standalone: true,
  imports: [HotelListComponent, NgbToastModule, FormsModule, HotelAdminAddUpdateModalComponent,NgbPaginationModule],
  templateUrl: './hotel-admin.component.html',
  styleUrl: './hotel-admin.component.scss'
})
export class HotelAdminComponent implements OnInit {
  data:any=[];
  searchQuery:any;
  constructor(private hotel:HotelServiceService){}
  additionSuccessfull=false;
  modal=inject(NgbModal);
   totalRecords=0;
  pageSize=6;
  page=1;
ngOnInit(): void {
this.loadData();
}
loadData()
{
   this.hotel.getAllHotels(this.page,this.pageSize).subscribe({
  next:(response:any)=>{
    this.data=response.hotels;
    this.totalRecords=response.totalCount;
  }
 })
}
handleChange(event:any)
{
  this.loadData();
}
onPageChange(page:number)
{
  this.page=page;
  this.loadData();
}
addHotels(content:TemplateRef<any>)
{
  const modalRef=this.modal.open(content,{centered:true,size:'lg'});
  modalRef.result.catch((response)=>{
    this.additionSuccessfull=response;
  })
}
searchByHotelName()
{
  this.hotel.searchByHotelName(this.searchQuery).subscribe({
    next:(response)=>{
      this.data=response;
    }
  }
  )
}
}
