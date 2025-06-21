import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FlightsService } from '../../../../services/Flights/flights.service';
import { NgbActiveModal, NgbModal, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-flight-delete-admin',
  standalone: true,
  imports: [NgbToastModule,FormsModule,CommonModule],
  providers: [
    NgbActiveModal,
],
  templateUrl: './flight-delete-admin.component.html',
  styleUrl: './flight-delete-admin.component.scss'
})
export class FlightDeleteAdminComponent {
  constructor(private flight:FlightsService,public activeModal:NgbActiveModal){}
  showToast=false;
  @Input()id:any;
  modal=inject(NgbModal);
  @Output()deleteEmitter=new EventEmitter<any>;
delete1(id:any)
{
this.flight.deleteById(id).subscribe({
next:(response)=>{
  console.log(id);
  const msg="Successful";
  this.deleteEmitter.emit(msg);
  this.modal.dismissAll(this.showToast=true);
}
})
}
close()
{
  this.modal.dismissAll();
  

}
}
