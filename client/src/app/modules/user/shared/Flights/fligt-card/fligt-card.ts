import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-fligt-card',
  standalone: false,
  templateUrl: './fligt-card.html',
  styleUrl: './fligt-card.css'
})
export class FligtCard implements OnInit,OnChanges {
@Input()flightClicked:any;
date_of_dep:string='';
  constructor(private dateService:DateTimeService){}
  dateDetails={date:'',month:'',day:''}
  diff='';
  padZero(n: number): string {
  return n < 10 ? '0' + n : n.toString();
}
  ngOnInit(): void {
   this.date_of_dep=this.flightClicked.date_of_departure;
  }

ngOnChanges(): void {
    this.dateDetails=this.dateService.findDateTime(this.flightClicked.date_of_departure);
   const time_of_departure=this.flightClicked.time_of_departure;
    const time_of_arrival=this.flightClicked.time_of_arrival;
    const [hours1,minutes1]=time_of_departure.split(":").map(Number);
    const dataObj1=new Date();
    dataObj1.setHours(hours1,minutes1);
    const [hours2,minutes2]=time_of_arrival.split(":").map(Number);
    const dataObj2=new Date();
    dataObj2.setHours(hours2,minutes2);
  const diffMs=dataObj2.getTime()-dataObj1.getTime();
    const diffMinutes = Math.floor(diffMs / 60000);
const hours = Math.floor(diffMinutes / 60);
const minutes = diffMinutes % 60;
this.diff = `${this.padZero(hours)}:${this.padZero(minutes)}`;

}
}
