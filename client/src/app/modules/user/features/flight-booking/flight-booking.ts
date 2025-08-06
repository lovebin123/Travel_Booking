import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';
import { FlightBookingService } from '../../../../services/Flights/FlightBooking/flight-booking.service';

@Component({
  selector: 'app-flight-booking',
  standalone: false,
  templateUrl: './flight-booking.html',
  styleUrl: './flight-booking.css'
})
export class FlightBooking {
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
  this.bookingService.goToPayement(id).subscribe((response:any)=>{
    this.data=response.result;
        document.location.href=this.data.url;
  })
}

}
