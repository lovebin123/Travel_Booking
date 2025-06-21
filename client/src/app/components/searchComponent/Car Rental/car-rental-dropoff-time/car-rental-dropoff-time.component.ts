import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-car-rental-dropoff-time',
  standalone: true,
  imports: [NgbPopoverModule,CommonModule,FormsModule],
  templateUrl: './car-rental-dropoff-time.component.html',
  styleUrl: './car-rental-dropoff-time.component.scss'
})
export class CarRentalDropoffTimeComponent {
@Output()dropoffTimeEmitter=new EventEmitter<any>();
    findVals()
    {
      this.dropoffTimeEmitter.emit(this.dropoff_time);
      console.log(this.dropoff_time);
    }
dropoff_time:any;
}
