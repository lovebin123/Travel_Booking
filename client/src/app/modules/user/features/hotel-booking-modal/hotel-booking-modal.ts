import { Component, Input } from '@angular/core';
import { HotelBookingServiceService } from '../../../../common/services/Hotels/HotelBooking/hotel-booking-service.service';

@Component({
  selector: 'app-hotel-booking-modal',
  standalone: false,
  templateUrl: './hotel-booking-modal.html',
  styleUrl: './hotel-booking-modal.css'
})
export class HotelBookingModal {
  constructor(private hotel: HotelBookingServiceService) { }
  @Input() data: any = {};
  pay(id: any) {
    this.hotel.createSession(id).subscribe({
      next: (response: any) => {
        response = response.result;
        document.location.href = response.url;
      }
    })
  }
}
