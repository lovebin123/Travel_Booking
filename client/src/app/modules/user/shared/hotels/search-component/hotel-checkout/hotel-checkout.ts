import { Component, EventEmitter, Output } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-checkout',
  standalone: false,
  templateUrl: './hotel-checkout.html',
  styleUrl: './hotel-checkout.css'
})
export class HotelCheckout {
@Output()checkoutEmitter=new EventEmitter<any>();
  constructor(private dateService:DateTimeService){}
checkoutDateModel:NgbDateStruct|undefined;
dateDetails={day:'',month:'',date:''}
date:string='';
findDateMonth()
{

this.date=this.checkoutDateModel
  ? `${this.checkoutDateModel.year}-${String(this.checkoutDateModel.month).padStart(2, '0')}-${String(this.checkoutDateModel.day).padStart(2, '0')}`
  : '';
  this.dateDetails=this.dateService.findDateTime(this.date);
this.checkoutEmitter.emit(this.date);
}
}
