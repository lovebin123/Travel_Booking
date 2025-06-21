import { Component, inject, OnInit, TemplateRef } from '@angular/core';
import { HotelListComponent } from "../../../components/cards/Hotels/hotel-list/hotel-list.component";
import { HotelServiceService } from '../../../services/Hotels/hotel-service.service';
import { NgbModal, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { HotelAdminAddUpdateModalComponent } from "../../../components/cards/Hotels/hotel-admin-add-update-modal/hotel-admin-add-update-modal.component";

@Component({
  selector: 'app-hotel-admin',
  standalone: true,
  imports: [HotelListComponent, NgbToastModule, CommonModule, HotelAdminAddUpdateModalComponent],
  templateUrl: './hotel-admin.component.html',
  styleUrl: './hotel-admin.component.scss'
})
export class HotelAdminComponent implements OnInit {
  data:any=[];
  constructor(private hotel:HotelServiceService){}
  additionSuccessfull=false;
  modal=inject(NgbModal);
ngOnInit(): void {
this.loadData();
}
loadData()
{
   this.hotel.getAllHotels().subscribe({
  next:(response:any)=>{
    this.data=response;
  }
 })
}
handleChange(event:any)
{
  this.loadData();
}

addHotels(content:TemplateRef<any>)
{
  const modalRef=this.modal.open(content,{centered:true,size:'lg'});
  modalRef.result.catch((response)=>{
    this.additionSuccessfull=response;
  })
}
}
