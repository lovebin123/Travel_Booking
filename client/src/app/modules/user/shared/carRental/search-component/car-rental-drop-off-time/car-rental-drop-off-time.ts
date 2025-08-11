import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-car-rental-drop-off-time',
  standalone: false,
  templateUrl: './car-rental-drop-off-time.html',
  styleUrl: './car-rental-drop-off-time.css'
})
export class CarRentalDropOffTime {
@Output()dropoffTimeEmitter=new EventEmitter<any>();
    findVals()
    {
      this.dropoffTimeEmitter.emit(this.dropoff_time);
    }
dropoff_time:any;
}
