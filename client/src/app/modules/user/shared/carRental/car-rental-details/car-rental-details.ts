import { Component, Input, OnInit } from '@angular/core';
import { DateTimeService } from '../../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-details',
  standalone: false,
  templateUrl: './car-rental-details.html',
  styleUrl: './car-rental-details.css'
})
export class CarRentalDetails implements OnInit {
pickup_date={date:'',month:'',day:'',year:''};
  dropoff_date={date:'',month:'',day:'',year:''};
      constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    
    this.pickup_date=this.dateService.findDateTime(this.data.bookedFromDate);
    this.dropoff_date=this.dateService.findDateTime(this.data.bookedTillDate);
  }
  @Input()data:any=null;
}
