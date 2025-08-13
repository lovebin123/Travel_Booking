import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { HotelBookingServiceService } from '../../../../../common/services/Hotels/HotelBooking/hotel-booking-service.service';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-hotel-delete-booking',
  standalone: false,
  templateUrl: './hotel-delete-booking.html',
  styleUrl: './hotel-delete-booking.css'
})
export class HotelDeleteBooking {
  constructor(private hotel: HotelBookingServiceService, public activeModal: NgbActiveModal) { }
  showToast = false;
  @Input() id: any;
  modal = inject(NgbModal);
  @Output() deleteEmitter = new EventEmitter<any>;
  delete1(id: any) {
    this.hotel.deleteById(id).subscribe({
      next: (response: any) => {
        this.deleteEmitter.emit();
        this.modal.dismissAll(this.showToast = true);
      }
    })
  }
  close() {
    this.modal.dismissAll();


  }
}
