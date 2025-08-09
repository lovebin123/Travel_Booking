import { Component, EventEmitter, Output } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-drop-off-date',
  standalone: false,
  templateUrl: './car-rental-drop-off-date.html',
  styleUrl: './car-rental-drop-off-date.css'
})
export class CarRentalDropOffDate {
 constructor(private dateService:DateTimeService){}
  @Output()dropOffDateEmitted=new EventEmitter<any>();
  dropoffDateModel:NgbDateStruct | undefined;
  dateDetails={day:'',month:'',date:''}
date:string='';
  findDateMonth()
{
this.date=this.dropoffDateModel
  ? `${this.dropoffDateModel.year}-${String(this.dropoffDateModel.month).padStart(2, '0')}-${String(this.dropoffDateModel.day).padStart(2, '0')}`
  : '';
  this.dropOffDateEmitted.emit(this.date);
  this.dateDetails=this.dateService.findDateTime(this.date);
}
}
