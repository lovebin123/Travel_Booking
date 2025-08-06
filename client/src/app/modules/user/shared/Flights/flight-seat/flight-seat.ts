import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-flight-seat',
  standalone: false,
  templateUrl: './flight-seat.html',
  styleUrl: './flight-seat.css'
})
export class FlightSeat {
@Input() flightDetails:any=[];
@Input()data:any={};
}
