import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-payment-details',
  standalone: false,
  templateUrl: './hotel-payment-details.html',
  styleUrl: './hotel-payment-details.css'
})
export class HotelPaymentDetails implements OnInit {
@Input()data:any={};
dateMonth={date:'',month:'',day:'',year:''}
constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    this.dateMonth=this.dateService.findDateTime(this.data.booking_date);
  }
}
