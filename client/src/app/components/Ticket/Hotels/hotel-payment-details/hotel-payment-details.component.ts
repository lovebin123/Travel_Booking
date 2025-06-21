import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-payment-details',
  standalone: true,
  imports: [],
  templateUrl: './hotel-payment-details.component.html',
  styleUrl: './hotel-payment-details.component.scss'
})
export class HotelPaymentDetailsComponent implements OnInit {
@Input()data:any={};
dateMonth={date:'',month:'',day:'',year:''}
constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    this.dateMonth=this.dateService.findDateTime(this.data.booking_date);
  }

}
