import { Component, OnInit } from '@angular/core';
import { HotelListComponent } from "../../../../components/cards/Hotels/hotel-list/hotel-list.component";
import { HotelBookingServiceService } from '../../../../services/Hotels/HotelBooking/hotel-booking-service.service';

@Component({
  selector: 'app-hotel-booking-transaction',
  standalone: true,
  imports: [HotelListComponent],
  templateUrl: './hotel-booking-transaction.component.html',
  styleUrl: './hotel-booking-transaction.component.scss'
})
export class HotelBookingTransactionComponent implements OnInit {
constructor(private hotels:HotelBookingServiceService){}
data:any={};
  ngOnInit(): void {
   this.hotels.getUserBookings().subscribe({
    next:(response:any)=>{
      this.data=response;
    }
   })
  }

}
