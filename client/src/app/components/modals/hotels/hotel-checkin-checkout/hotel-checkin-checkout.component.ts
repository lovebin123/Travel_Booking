import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-hotel-checkin-checkout',
  standalone: true,
  imports: [],
  templateUrl: './hotel-checkin-checkout.component.html',
  styleUrl: './hotel-checkin-checkout.component.scss',
  providers:[{
        provide:DateTimeService,
        useFactory:()=>new DateTimeService()
      }],
})
export class HotelCheckinCheckoutComponent implements OnInit{
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
   console.log(this.checkin_date);
   console.log(this.checkout_date);
   
  }

}
