import { Component } from '@angular/core';
import { HotelBookingModalComponent } from "../../Hotels/hotel-booking-modal/hotel-booking-modal.component";
import { CarRentalSearchComponent } from "../../../components/cards/Car Rental/car-rental-search/car-rental-search.component";
import { CarRentalListComponent } from "../../../components/cards/Car Rental/car-rental-list/car-rental-list.component";

@Component({
  selector: 'app-car-rental-home-page',
  standalone: true,
  imports: [HotelBookingModalComponent, CarRentalSearchComponent, CarRentalListComponent],
  templateUrl: './car-rental-home-page.component.html',
  styleUrl: './car-rental-home-page.component.scss'
})
export class CarRentalHomePageComponent {
data:any;
search:any;
handleCarRentalSearchEmitted(data:any)
{
  this.search=data;
}
  handleCarRentalsEmitted(data:any)
{
this.data=data;
console.log(data);
}
}
