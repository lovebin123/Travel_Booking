import { Component, EventEmitter, Output } from '@angular/core';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-flight-destination-date',
  standalone: false,
  templateUrl: './flight-destination-date.html',
  styleUrl: './flight-destination-date.css'
})
export class FlightDestinationDate {
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
