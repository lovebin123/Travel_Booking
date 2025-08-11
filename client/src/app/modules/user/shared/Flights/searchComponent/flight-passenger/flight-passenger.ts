import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-flight-passenger',
  standalone: false,
  templateUrl: './flight-passenger.html',
  styleUrl: './flight-passenger.css'
})
export class FlightPassenger {
travellerDetails:any={adults:'1',children:''};
  no_of_travellers:number=0;
  @Output()passengerDetailsEmitted=new EventEmitter<any>();
  @Output()seatTypeEmitted=new EventEmitter<any>();
  seatType:any;
findTotalTravellers()
{
  this.no_of_travellers=+this.travellerDetails.adults + +this.travellerDetails.children;
  this.passengerDetailsEmitted.emit(this.travellerDetails);
  this.seatTypeEmitted.emit(this.seatType);
}
}
