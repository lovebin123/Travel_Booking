import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-flight-destination-date',
  standalone: true,
  imports: [NgbDatepickerModule,FormsModule,CommonModule],
  templateUrl: './flight-destination-date.component.html',
  styleUrl: './flight-destination-date.component.scss',
  providers:[{
          provide:DateTimeService,
          useFactory:()=>new DateTimeService()
        }],
})
export class FlightDestinationDateComponent {
  constructor(private dateService:DateTimeService){}
  fromDateModel:NgbDateStruct | undefined;
      dateDetails={day:'',month:'',date:''}
  date:string='';
  @Output()destinationDateEmitter=new EventEmitter<any>();
findDateTIme(data:any)
{
  this.date=this.fromDateModel
  ? `${this.fromDateModel.year}-${String(this.fromDateModel.month).padStart(2, '0')}-${String(this.fromDateModel.day).padStart(2, '0')}`
  : '';
  this.dateDetails=this.dateService.findDateTime(this.date);
  this.destinationDateEmitter.emit(this.date);
}
}
