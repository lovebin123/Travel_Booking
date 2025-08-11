import { Component, EventEmitter, Output } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-car-rental-pick-up-time',
  standalone: false,
  templateUrl: './car-rental-pick-up-time.html',
  styleUrl: './car-rental-pick-up-time.css'
})
export class CarRentalPickUpTime {
 @Output()pickupTimeEmitter=new EventEmitter<any>();
    findVals()
    {
      this.pickupTimeEmitter.emit(this.pickup_time);
    }
pickup_time:any;
}
