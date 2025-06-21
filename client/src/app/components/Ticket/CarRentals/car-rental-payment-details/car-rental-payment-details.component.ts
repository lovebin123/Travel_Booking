import { Component, Input } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-payment-details',
  standalone: true,
  imports: [],
  templateUrl: './car-rental-payment-details.component.html',
  styleUrl: './car-rental-payment-details.component.scss'
})
export class CarRentalPaymentDetailsComponent {
@Input()data:any={};
dateMonth={date:'',month:'',day:'',year:''}
constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    this.dateMonth=this.dateService.findDateTime(this.data.booking_date);
  }
}
