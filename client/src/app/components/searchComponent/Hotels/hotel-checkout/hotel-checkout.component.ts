import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbDateStruct, NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-checkout',
  standalone: true,
  imports: [NgbPopoverModule,NgbDatepickerModule,CommonModule,FormsModule],
  templateUrl: './hotel-checkout.component.html',
  providers:[{
      provide:DateTimeService,
      useFactory:()=>new DateTimeService()
    }],
  styleUrl: './hotel-checkout.component.scss'
})
export class HotelCheckoutComponent {
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
