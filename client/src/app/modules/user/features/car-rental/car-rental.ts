import { Component } from '@angular/core';

@Component({
  selector: 'app-car-rental',
  standalone: false,
  templateUrl: './car-rental.html',
  styleUrl: './car-rental.css'
})
export class CarRental {
data:any;
search:any;
searchClicked=false;
handleCarRentalSearchEmitted(data:any)
{
  this.search=data;
}
  handleCarRentalsEmitted(data:any)
{
  this.searchClicked=true;
this.data=data;
}
}
