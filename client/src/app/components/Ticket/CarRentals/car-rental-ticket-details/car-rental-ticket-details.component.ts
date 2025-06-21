import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-ticket-details',
  standalone: true,
  imports: [],
  templateUrl: './car-rental-ticket-details.component.html',
  styleUrl: './car-rental-ticket-details.component.scss'
})
export class CarRentalTicketDetailsComponent implements OnInit{
    constructor(private dateService:DateTimeService){}
ngOnInit(): void {
   this.dateMonth1=this.dateService.findDateTime(this.data.carRentalBooking.bookedFromDate);
    this.dateMonth2=this.dateService.findDateTime(this.data.carRentalBooking.bookedTillDate);
}
@Input()data:any={};
dateMonth1={date:'',month:'',day:'',year:''};
dateMonth2={date:'',month:'',day:'',year:''};
}
