import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';
import { FlightPaymentService } from '../../../../services/Flights/FlightPayment/flight-payment.service';
import { Router } from '@angular/router';
import { ChangeDetectorRef } from '@angular/core';
@Component({
  selector: 'app-flight-payment-list',
  standalone: true,
  imports: [],
  providers:[{
    provide:DateTimeService,
    useFactory:()=>new DateTimeService()
  }],
  templateUrl: './flight-payment-list.component.html',
  styleUrl: './flight-payment-list.component.scss'
})
export class FlightPaymentListComponent implements OnInit {
  constructor(private dateMonth:DateTimeService,private flights:FlightPaymentService,private router:Router,private cdf:ChangeDetectorRef){}
  @Input() name1:any;
    @Input()time_of_departure: any
    @Input()source: string = '';
    @Input()time_of_arrival: any;
    @Input()destination: string = '';
    @Input()price: number = 0; 
    @Input()id:any;
    @Input()firstName:any;
    @Input()lastName:any;
    @Input()paymentIntentId:any;
    @Input()date_of_departure:any;
    @Input()flightData:any;
    dateDetails={day:'',month:'',date:''};
ngOnInit(): void {
 this.dateDetails=this.dateMonth.findDateTime(this.date_of_departure);
 this.cdf.detectChanges();
}
showTicket()
{
  this.flights.getByid(this.id).subscribe(
    {
      next:(response:any)=>{
        console.log(response);
        this.router.navigate(['/flightTicket'],{
          state:{id:this.id}
        });
      },
    }
  )
}
}
