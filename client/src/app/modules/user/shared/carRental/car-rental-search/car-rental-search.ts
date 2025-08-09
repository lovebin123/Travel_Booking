import { Component, EventEmitter, Output } from '@angular/core';
import { CarRentalService } from '../../../../../common/services/CarRental/car-rental.service';

@Component({
  selector: 'app-car-rental-search',
  standalone: false,
  templateUrl: './car-rental-search.html',
  styleUrl: './car-rental-search.css'
})
export class CarRentalSearch {
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
