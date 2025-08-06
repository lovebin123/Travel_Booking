import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-flight-details',
  standalone: false,
  templateUrl: './flight-details.html',
  styleUrl: './flight-details.css'
})
export class FlightDetails {
@Input()flightDetail:any=[];
@Input()day:any;
@Input()month:any
@Input()dayNum:any;
@Input()diff:any;
}
