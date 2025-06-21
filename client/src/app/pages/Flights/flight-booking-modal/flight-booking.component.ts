import { response } from 'express';
import { FlightDetailsComponent } from '../../../components/modals/flights/flight-details/flight-details.component';
import { FlightUserComponent } from '../../../components/modals/flights/flight-user/flight-user.component';
import { FlightBookingService } from '../../../services/Flights/FlightBooking/flight-booking.service';
import { FlightBaggageComponent } from './../../../components/modals/flights/flight-baggage/flight-baggage.component';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DateTimeService } from '../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-flight-booking',
  standalone: true,
  imports: [FlightBaggageComponent, FlightDetailsComponent, FlightUserComponent],
  templateUrl: './flight-booking.component.html',
  styleUrl: './flight-booking.component.scss',
  providers:[{
    provide:DateTimeService,
    useFactory:()=>new DateTimeService()
  }],
})
export class FlightBookingComponent implements OnInit{
  constructor(private bookingService:FlightBookingService,private router:Router,private dateService:DateTimeService){}
@Input() flightClicked:any=[];
@Input() user:any=[];
@Input() diff:any;
@Input() no_of_adults:any;
@Input() no_of_children:any;
@Input()flightBookingId:any;
data:any=[];
dateMonth={date:'',month:'',day:''};
ngOnInit(): void {
    this.dateMonth=this.dateService.findDateTime(this.flightClicked.date_of_departure);
}
proceedToPayement(id:number)
{
  this.bookingService.goToPayement(id).subscribe((response)=>{
    this.data=response;
        document.location.href=this.data.url;
  })
}

}
