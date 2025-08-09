import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FlightsService } from '../../../../../common/services/Flights/flights.service';

@Component({
  selector: 'app-flight-admin-delete-admin',
  standalone: false,
  templateUrl: './flight-admin-delete-admin.html',
  styleUrl: './flight-admin-delete-admin.css'
})
export class FlightAdminDeleteAdmin {
 constructor(private flight:FlightsService,public activeModal:NgbActiveModal){}
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
