import { Component } from '@angular/core';
import { FlightHomeComponent } from "../../pages/Flights/flight-home/flight-home.component";
import { HotelHomePageComponent } from "../../pages/Hotels/hotel-home-page/hotel-home-page.component";
import { CarRentalHomePageComponent } from "../../pages/CarRental/car-rental-home-page/car-rental-home-page.component";

@Component({
  selector: 'app-tabs',
  standalone: true,
  imports: [FlightHomeComponent, HotelHomePageComponent, CarRentalHomePageComponent],
  templateUrl: './nav-tabs.component.html',
  styleUrl: './tabs.component.scss'
})
export class TabsComponent {

}
