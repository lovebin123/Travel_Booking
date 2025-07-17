import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Hotel } from '../../../../models/hotels';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HotelServiceService } from '../../../../services/Hotels/hotel-service.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-hotel-admin-add-update-modal',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './hotel-admin-add-update-modal.component.html',
  styleUrl: './hotel-admin-add-update-modal.component.scss'
})
export class HotelAdminAddUpdateModalComponent implements OnInit {
  @Input() id:any;
  constructor(private hotel:HotelServiceService,private modal:NgbModal){}
  ngOnInit(): void {
    if(this.id!=undefined)
    {
       this.hotel.getById(this.id).subscribe({
      next:(response:any)=>{
        response=response.result;
        console.log(response);
        this.data=response;
         this.hotelData.bed_type=this.data.bed_type;
      this.hotelData.bedroom_type=this.data.bedroom_type;
      this.hotelData.location=this.data.location;
      this.hotelData.name=this.data.name;
      this.hotelData.no_of_rooms_available=this.data.no_of_rooms_available;
      this.hotelData.no_of_stars=this.data.no_of_stars;
      this.hotelData.price=this.data.price;
      this.hotelData.rating=this.data.rating;
      this.hotelData.user_review=this.data.user_review;
      }
    })
    }
  }
  loadData()
  {
    this.hotel.getById(this.id).subscribe({
      next:(response)=>{
        response=response.result;
        this.data=response;
      }
    })
  }
@Input()type:any;
@Output()componentEmitted=new EventEmitter<any>();
data:any={};
hotelData:Hotel={
  bed_type:'',
  bedroom_type:'',
  location:'',
  name:'',
  no_of_stars: 1,
  no_of_rooms_available:1,
  price:0,
  rating:'',
  user_review:''
};
showToast1=false;
showToast2=false;
add()
{
  this.hotel.addHotel(this.hotelData).subscribe({
    next:(response)=>{
      response=response.result;
      const modelRef=this.modal.dismissAll(this.showToast1=true);
      this.componentEmitted.emit();
    }
  })
}
@Output()updaterEmitted=new EventEmitter<any>();
update(id:any,hotelData:Hotel)
{
  this.hotel.updateHotel(id,hotelData).subscribe({
    next:(response)=>{
      response=response.result;
      this.modal.dismissAll(this.showToast2=true);
      this.updaterEmitted.emit();
    }
  })
}
}
