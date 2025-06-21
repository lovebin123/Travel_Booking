import { Component, EventEmitter, Output } from '@angular/core';
import {NgbPopoverModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { HotelLocationComponent } from "../../../searchComponent/Hotels/hotel-location/hotel-location.component";
import { HotelCheckinComponent } from "../../../searchComponent/Hotels/hotel-checkin/hotel-checkin.component";
import { HotelCheckoutComponent } from "../../../searchComponent/Hotels/hotel-checkout/hotel-checkout.component";
import { HotelAdultsRoomsComponent } from "../../../searchComponent/Hotels/hotel-adults-rooms/hotel-adults-rooms.component";
import { HotelServiceService } from '../../../../services/Hotels/hotel-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-hotel-search',
  standalone: true,
  imports: [NgbPopoverModule, HotelLocationComponent, HotelCheckinComponent, HotelCheckoutComponent, HotelAdultsRoomsComponent,NgbToastModule,CommonModule],
  templateUrl: './hotel-search.component.html',
  styleUrl: './hotel-search.component.scss'
})
export class HotelSearchComponent {
  @Output()hotelsEmitted=new EventEmitter<any>();
  @Output()hotelSearchEmitted=new EventEmitter<any>();
  @Output()roomAdultsEmitted=new EventEmitter<any>();
  constructor(private hotelService:HotelServiceService){}
  hotelSearch:any={checkin:'',checkout:''};
  location='';
  roomsAdults={rooms:'',adults:'',children:'0'};
  handleLocation(data:any)
  {
    this.location=data.name1;
  }
  handleCheckin(data:any)
  {
    this.hotelSearch.checkin=data;
  }
  handleCheckout(data:any)
  {
    this.hotelSearch.checkout=data;
  }
  handleRoomsAdults(data:any)
  {
    this.roomsAdults=data;
  }
  showToast=false;
  getHotels()
  {
    if(!this.location || !this.roomsAdults.adults || !this.hotelSearch.checkout || !this.hotelSearch.checkout || !this.roomsAdults.rooms )
    {
          this.showToast=true;
        return;
    }
    this.hotelService.getHotelsFromQuery(this.location).subscribe({
      next:(response:any)=>{
        this.hotelsEmitted.emit(response);
        this.hotelSearchEmitted.emit(this.hotelSearch);
        this.roomAdultsEmitted.emit(this.roomsAdults);
        
      }
    })
  }
}
