import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-flight-seat',
  standalone: true,
  imports: [],
  templateUrl: './flight-seat.component.html',
  styleUrl: './flight-seat.component.scss'
})
export class FlightSeatComponent {
@Input() flightDetails:any=[];
@Input()data:any={};
}
