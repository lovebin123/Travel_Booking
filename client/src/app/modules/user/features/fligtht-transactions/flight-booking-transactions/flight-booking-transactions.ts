import { Component, OnInit } from '@angular/core';
import { FlightBookingService } from '../../../../../services/Flights/FlightBooking/flight-booking.service';
@Component({
  selector: 'app-flight-booking-transactions',
  standalone: false,
  templateUrl: './flight-booking-transactions.html',
  styleUrl: './flight-booking-transactions.css'
})
export class FlightBookingTransactions implements OnInit{
data:any=null;
  flightData:any=[];
  bookingId:any;
constructor(private  flightBooking:FlightBookingService){}
  ngOnInit(): void {
    this.flightBooking.getUserBookings().subscribe((response:any)=>{
      this.data=response.result;
      console.log(response);
      for(let i=0;i<this.data.length;i++)
      {
        this.flightData=this.data[i].flight;
        this.bookingId=this.data[i].id;
      }
    })
  }
}
