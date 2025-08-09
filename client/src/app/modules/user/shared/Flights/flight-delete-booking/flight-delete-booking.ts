import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FlightBookingService } from '../../../../../common/services/Flights/FlightBooking/flight-booking.service';


@Component({
  selector: 'app-flight-delete-booking',
  standalone: false,
  templateUrl: './flight-delete-booking.html',
  styleUrl: './flight-delete-booking.css'
})
export class FlightDeleteBooking {
constructor(private flight:FlightBookingService,public activeModal:NgbActiveModal){}
  showToast=false;
  @Input()id:any;
  modal=inject(NgbModal);
  @Output()deleteEmitter=new EventEmitter<any>;
delete1(id:any)
{
this.flight.deleteById(id).subscribe({
next:(response:any)=>{
  console.log(id);
  this.deleteEmitter.emit();
  this.modal.dismissAll(this.showToast=true);
}
})
}
close()
{
  this.modal.dismissAll();
  

}
}
