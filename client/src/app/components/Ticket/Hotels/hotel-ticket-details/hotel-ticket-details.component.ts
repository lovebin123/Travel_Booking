import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-ticket-details',
  standalone: true,
  imports: [],
  templateUrl: './hotel-ticket-details.component.html',
  styleUrl: './hotel-ticket-details.component.scss'
})
export class HotelTicketDetailsComponent implements OnInit{
@Input()data:any={};
dateMonth1={date:'',month:'',day:'',year:''};
dateMonth2={date:'',month:'',day:'',year:''};
  constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    this.dateMonth1=this.dateService.findDateTime(this.data.hotelBooking.check_in_date);
    this.dateMonth2=this.dateService.findDateTime(this.data.hotelBooking.check_out_date);
  }
}
