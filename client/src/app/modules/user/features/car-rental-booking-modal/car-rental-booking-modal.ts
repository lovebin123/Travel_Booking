import { Component, Input } from '@angular/core';
import { CarRentalBookingService } from '../../../../common/services/CarRental/CarRentalBooking/car-rental-booking.service';

@Component({
  selector: 'app-car-rental-booking-modal',
  standalone: false,
  templateUrl: './car-rental-booking-modal.html',
  styleUrl: './car-rental-booking-modal.css'
})
export class CarRentalBookingModal {
  constructor(private carRental: CarRentalBookingService) { }
  @Input() data: any = {}
  book(id: any) {
    this.carRental.createCheckout(id).subscribe({
      next: (response: any) => {
        response = response.result;
        document.location.href = response.url;
      }
    })
  }
}
