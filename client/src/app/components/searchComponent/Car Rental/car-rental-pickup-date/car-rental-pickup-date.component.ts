import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbDateStruct, NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-pickup-date',
  standalone: true,
  imports: [NgbDatepickerModule,CommonModule,FormsModule,NgbPopoverModule],
  templateUrl: './car-rental-pickup-date.component.html',
  styleUrl: './car-rental-pickup-date.component.scss'
})
export class CarRentalPickupDateComponent {
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
