import { Component, Input } from '@angular/core';
import { DateTimeService } from '../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-payment-details',
  standalone: false,
  templateUrl: './car-rental-payment-details.html',
  styleUrl: './car-rental-payment-details.css'
})
export class CarRentalPaymentDetails {
@Input()data:any={};
dateMonth={date:'',month:'',day:'',year:''}
constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    this.dateMonth=this.dateService.findDateTime(this.data.booking_date);
  }
}
