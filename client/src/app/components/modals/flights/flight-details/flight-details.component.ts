import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-flight-details',
  standalone: true,
  imports: [],
  templateUrl: './flight-details.component.html',
  styleUrl: './flight-details.component.scss'
})
export class FlightDetailsComponent {
@Input()flightDetail:any=[];
@Input()day:any;
@Input()month:any
@Input()dayNum:any;
@Input()diff:any;
}
