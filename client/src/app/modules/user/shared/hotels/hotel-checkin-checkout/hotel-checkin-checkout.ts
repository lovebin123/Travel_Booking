import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../../common/services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-checkin-checkout',
  standalone: false,
  templateUrl: './hotel-checkin-checkout.html',
  styleUrl: './hotel-checkin-checkout.css'
})
export class HotelCheckinCheckout implements OnInit {
 checkin_date={date:'',month:'',day:'',year:''};
    checkout_date={date:'',month:'',day:'',year:''};
  constructor(private dateService:DateTimeService){}
  @Input() checkin:any;
@Input() checkout:any;
@Input()rooms:any;
@Input()adults:any;
@Input()children:any;
@Input()data:any={};
  ngOnInit(): void {
   this.checkin_date=this.dateService.findDateTime(this.checkin);
   this.checkout_date=this.dateService.findDateTime(this.checkout);
   
   
  }

}
