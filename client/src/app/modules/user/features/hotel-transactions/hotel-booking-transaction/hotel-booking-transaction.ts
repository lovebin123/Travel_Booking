import { Component, OnInit } from '@angular/core';
import { HotelBookingServiceService } from '../../../../../common/services/Hotels/HotelBooking/hotel-booking-service.service';

@Component({
  selector: 'app-hotel-booking-transaction',
  standalone: false,
  templateUrl: './hotel-booking-transaction.html',
  styleUrl: './hotel-booking-transaction.css'
})
export class HotelBookingTransaction implements OnInit {
constructor(private hotels:HotelBookingServiceService){}
data:any={};
  ngOnInit(): void {
  this.loadData();
  }
  loadData()
  {
     this.hotels.getUserBookings().subscribe({
    next:(response:any)=>{
      response=response.result;
      this.data=response;
    }
   })
  }
  handleChange(event:any)
  {
    this.loadData();
  }
}
