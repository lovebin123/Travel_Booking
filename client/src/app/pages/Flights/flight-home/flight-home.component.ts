import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FlightBookingComponent } from '../../../pages/Flights/flight-booking-modal/flight-booking.component';
import { FlightSearchComponent } from '../../../components/cards/Flights/flight-search/flight-search.component';
import { FlightListComponent } from '../../../components/cards/Flights/flight-list/flight-list.component';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-flight-home',
  standalone: true,
  imports: [FlightBookingComponent,FlightListComponent,FlightSearchComponent,FormsModule, CommonModule,NgbToastModule],
  templateUrl: './flight-home.component.html',
  styleUrl: './flight-home.component.scss'
})
export class FlightHomeComponent {
  temp:any=null;
  data:any;
  searchClicked=false;
Book: string='Book';
showToast=false;
  onSearch(data:any)
  {
    console.log(data);
    this.searchClicked=true;
    this.temp=data;
  }
  onPlay(data:any)
  {
    if(!data)
    {
      this.showToast=true;
    }
    this.data=data;
  }
}
