import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-flight-passengar',
  standalone: true,
  imports: [NgbPopoverModule,CommonModule,FormsModule],
  templateUrl: './flight-passengar.component.html',
  styleUrl: './flight-passengar.component.scss'
})
export class FlightPassengarComponent {
travellerDetails:any={adults:'1',children:''};
  no_of_travellers:number=0;
  @Output()passengerDetailsEmitted=new EventEmitter<any>();
  @Output()seatTypeEmitted=new EventEmitter<any>();
  seatType:any;
findTotalTravellers()
{
  this.no_of_travellers=+this.travellerDetails.adults + +this.travellerDetails.children;
  this.passengerDetailsEmitted.emit(this.travellerDetails);
  console.log(this.travellerDetails);
  this.seatTypeEmitted.emit(this.seatType);
}
}
