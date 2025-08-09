import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-ticket-details',
  standalone: false,
  templateUrl: './hotel-ticket-details.html',
  styleUrl: './hotel-ticket-details.css'
})
export class HotelTicketDetails implements OnInit {
@Input()data:any={};
dateMonth1={date:'',month:'',day:'',year:''};
dateMonth2={date:'',month:'',day:'',year:''};
  constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    this.dateMonth1=this.dateService.findDateTime(this.data.hotelBooking.check_in_date);
    this.dateMonth2=this.dateService.findDateTime(this.data.hotelBooking.check_out_date);
  }
}
