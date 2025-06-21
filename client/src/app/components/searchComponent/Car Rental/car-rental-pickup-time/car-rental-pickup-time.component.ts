import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-car-rental-pickup-time',
  standalone: true,
  imports: [NgbPopoverModule,CommonModule,FormsModule],
  templateUrl: './car-rental-pickup-time.component.html',
  styleUrl: './car-rental-pickup-time.component.scss'
})
export class CarRentalPickupTimeComponent {
   @Output()pickupTimeEmitter=new EventEmitter<any>();
    findVals()
    {
      this.pickupTimeEmitter.emit(this.pickup_time);
      console.log(this.pickup_time);
    }
pickup_time:any;
}
