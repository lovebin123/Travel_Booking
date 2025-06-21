import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbDateStruct, NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-checkin',
  standalone: true,
  imports: [NgbPopoverModule,NgbDatepickerModule,CommonModule,FormsModule],
  templateUrl: './hotel-checkin.component.html',
  styleUrl: './hotel-checkin.component.scss',
  providers:[{
        provide:DateTimeService,
        useFactory:()=>new DateTimeService()
      }],
})
export class HotelCheckinComponent {
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
