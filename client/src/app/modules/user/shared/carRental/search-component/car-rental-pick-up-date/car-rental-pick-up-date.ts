import { Component, EventEmitter, Output } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-pick-up-date',
  standalone: false,
  templateUrl: './car-rental-pick-up-date.html',
  styleUrl: './car-rental-pick-up-date.css'
})
export class CarRentalPickUpDate {
 constructor(private dateService:DateTimeService){}
  @Output()pickupDateEmited=new EventEmitter<any>();
  pickupDateModel:NgbDateStruct | undefined;
  dateDetails={day:'',month:'',date:''}
date:string='';
  findDateMonth()
{
this.date=this.pickupDateModel
  ? `${this.pickupDateModel.year}-${String(this.pickupDateModel.month).padStart(2, '0')}-${String(this.pickupDateModel.day).padStart(2, '0')}`
  : '';
  this.pickupDateEmited.emit(this.date);
  this.dateDetails=this.dateService.findDateTime(this.date);
}
}
