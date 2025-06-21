import { Component, Input } from '@angular/core';
import { CarRentalDetailsComponent } from "../../../components/modals/carRentals/car-rental-details/car-rental-details.component";
import { CarRentalServicesComponent } from "../../../components/modals/carRentals/car-rental-services/car-rental-services.component";
import { CarRentalUserComponent } from "../../../components/modals/carRentals/car-rental-user/car-rental-user.component";
import { CarRentalBookingService } from '../../../services/CarRental/CarRentalBooking/car-rental-booking.service';

@Component({
  selector: 'app-car-rental-booking-modal',
  standalone: true,
  imports: [CarRentalDetailsComponent, CarRentalServicesComponent, CarRentalUserComponent],
  templateUrl: './car-rental-booking-modal.component.html',
  styleUrl: './car-rental-booking-modal.component.scss'
})
export class CarRentalBookingModalComponent {
constructor(private carRental:CarRentalBookingService){}
@Input()data:any={}
book(id:any)
{
  this.carRental.createCheckout(id).subscribe({
    next:(response)=>{
      console.log(response);
      document.location.href=response.url;
    }
  })
}
}
