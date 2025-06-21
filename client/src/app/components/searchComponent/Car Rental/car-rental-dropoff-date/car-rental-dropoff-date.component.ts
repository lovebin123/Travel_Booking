import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbDateStruct, NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-dropoff-date',
  standalone: true,
  imports: [CommonModule,NgbPopoverModule,FormsModule,NgbDatepickerModule],
  templateUrl: './car-rental-dropoff-date.component.html',
  styleUrl: './car-rental-dropoff-date.component.scss'
})
export class CarRentalDropoffDateComponent {
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
