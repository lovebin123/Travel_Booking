import { Component, Input } from '@angular/core';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car-rental-payemnt-list',
  standalone: true,
  imports: [],
  templateUrl: './car-rental-payemnt-list.component.html',
  styleUrl: './car-rental-payemnt-list.component.scss'
})
export class CarRentalPayemntListComponent {
constructor(private dateService:DateTimeService,private router:Router){}
  date1={date:'',month:'',day:'',year:''};
  date2={date:'',month:'',day:'',year:''};
  ngOnInit(): void {
   this.date1=this.dateService.findDateTime(this.data.carRentalBooking.bookedFromDate);
   this.date2=this.dateService.findDateTime(this.data.carRentalBooking.bookedTillDate);
  }
@Input()data:any;
navToPayment()
{
  this.router.navigate(['carRentalTicket'],{state:{id:this.data.id}});
}
}
