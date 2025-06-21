import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-hotel-payment-list',
  standalone: true,
  imports: [],
  templateUrl: './hotel-payment-list.component.html',
  styleUrl: './hotel-payment-list.component.scss'
})
export class HotelPaymentListComponent implements OnInit{
  constructor(private dateService:DateTimeService,private router:Router){}
  date1={date:'',month:'',day:'',year:''};
  date2={date:'',month:'',day:'',year:''};
  ngOnInit(): void {
   this.date1=this.dateService.findDateTime(this.data.hotelBooking.check_in_date);
   this.date2=this.dateService.findDateTime(this.data.hotelBooking.check_out_date);
  }
@Input()data:any;
navToPayment()
{
  console.log(this.data.id);
this.router.navigate(['/hotelTicket'],{
  state:{id:this.data.id},
})
}
}
