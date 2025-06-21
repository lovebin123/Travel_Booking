import { Component, Input, OnInit } from '@angular/core';
import { NgbTooltipModule } from '@ng-bootstrap/ng-bootstrap';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';

@Component({
  selector: 'app-car-rental-details',
  standalone: true,
  imports: [NgbTooltipModule],
  templateUrl: './car-rental-details.component.html',
  styleUrl: './car-rental-details.component.scss'
})
export class CarRentalDetailsComponent implements OnInit {
  pickup_date={date:'',month:'',day:'',year:''};
  dropoff_date={date:'',month:'',day:'',year:''};
      constructor(private dateService:DateTimeService){}
  ngOnInit(): void {
    this.pickup_date=this.dateService.findDateTime(this.data.bookedFromDate);
    this.dropoff_date=this.dateService.findDateTime(this.data.bookedTillDate);
  }
  @Input()data:any=null;
}
