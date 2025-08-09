import { Component, EventEmitter, Output } from '@angular/core';
import { HotelServiceService } from '../../../../../common/services/Hotels/hotel-service.service';

@Component({
  selector: 'app-hotel-search',
  standalone: false,
  templateUrl: './hotel-search.html',
  styleUrl: './hotel-search.css'
})
export class HotelSearch {
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
        response=response.result;
        this.hotelsEmitted.emit(response);
        this.hotelSearchEmitted.emit(this.hotelSearch);
        this.roomAdultsEmitted.emit(this.roomsAdults);
        
      }
    })
  }
}
