import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FlightBookingService } from '../../../../services/Flights/FlightBooking/flight-booking.service';
import { FlightListComponent } from "../../../../components/cards/Flights/flight-list/flight-list.component";

@Component({
  selector: 'app-flight-booking-transaction',
  standalone:true,
  imports: [ FlightListComponent],
  templateUrl: './flight-booking-transaction.component.html',
  styleUrl: './flight-booking-transaction.component.scss'
})
export class FlightBookingTransactionComponent implements OnInit {
  
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
