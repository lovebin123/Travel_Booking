import { Component, EventEmitter, Output } from '@angular/core';
import { NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CarRentalLocationComponent } from "../../../searchComponent/Car Rental/car-rental-location/car-rental-location.component";
import { CarRentalPickupDateComponent } from "../../../searchComponent/Car Rental/car-rental-pickup-date/car-rental-pickup-date.component";
import { CarRentalPickupTimeComponent } from "../../../searchComponent/Car Rental/car-rental-pickup-time/car-rental-pickup-time.component";
import { CarRentalDropoffDateComponent } from "../../../searchComponent/Car Rental/car-rental-dropoff-date/car-rental-dropoff-date.component";
import { CarRentalDropoffTimeComponent } from "../../../searchComponent/Car Rental/car-rental-dropoff-time/car-rental-dropoff-time.component";
import { CarRentalService } from '../../../../services/CarRental/car-rental.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-car-rental-search',
  standalone: true,
  imports: [NgbToastModule, CarRentalLocationComponent, CarRentalPickupDateComponent, CarRentalPickupTimeComponent, CarRentalDropoffDateComponent, CarRentalDropoffTimeComponent,CommonModule,FormsModule],
  templateUrl: './car-rental-search.component.html',
  styleUrl: './car-rental-search.component.scss'
})
export class CarRentalSearchComponent {
  constructor(private carRental:CarRentalService){}
carRentalSearch={location:'',pickupdate:'',pickuptime:'',dropoffdate:'',dropofftime:''};
data:any={};
@Output()carRentalsEmitted=new EventEmitter<any>();
@Output()carRentalSearchEmitted=new EventEmitter<any>();
handleLocation(data:any)
{
  this.carRentalSearch.location=data?.name1;
}
handlePickupDate(data:any)
{
  this.carRentalSearch.pickupdate=data;
}
handlePickupTime(data:any)
{
  this.carRentalSearch.pickuptime=data;
}
handleDropoffDate(data:any)
{
  this.carRentalSearch.dropoffdate=data;
}
handleDropoffTime(data:any)
{
  this.carRentalSearch.dropofftime=data;
}
showToast1=false;
onSearch()
{
  if(!this.carRentalSearch.location || !this.carRentalSearch.pickupdate || !this.carRentalSearch.dropoffdate || !this.carRentalSearch.dropofftime || !this.carRentalSearch.pickuptime)
  {
    this.showToast1=true;
    return;
  }
  this.carRental.getFromQuery(this.carRentalSearch).subscribe({
    next:(response:any)=>{
      response=response.result;
      this.data=response;
      this.carRentalsEmitted.emit(this.data);
      this.carRentalSearchEmitted.emit(this.carRentalSearch);
    }
  })
} 
}
