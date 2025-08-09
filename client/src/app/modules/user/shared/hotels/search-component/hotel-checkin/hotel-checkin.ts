import { Component, EventEmitter, Output } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-checkin',
  standalone: false,
  templateUrl: './hotel-checkin.html',
  styleUrl: './hotel-checkin.css'
})
export class HotelCheckin {
 constructor(private dateService:DateTimeService){}
  @Output()checkinDateEmited=new EventEmitter<any>();
    checkinDateModel:NgbDateStruct | undefined;
  dateDetails={day:'',month:'',date:''}
date:string='';
  findDateMonth()
{
this.date=this.checkinDateModel
  ? `${this.checkinDateModel.year}-${String(this.checkinDateModel.month).padStart(2, '0')}-${String(this.checkinDateModel.day).padStart(2, '0')}`
  : '';
  this.checkinDateEmited.emit(this.date);
  this.dateDetails=this.dateService.findDateTime(this.date);
}
}
