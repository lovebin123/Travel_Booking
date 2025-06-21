import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModal, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { CarRentalService } from '../../../../services/CarRental/car-rental.service';

@Component({
  selector: 'app-car-rental-admin-delete',
  standalone: true,
  imports: [NgbToastModule,CommonModule,FormsModule],
  templateUrl: './car-rental-admin-delete.component.html',
  styleUrl: './car-rental-admin-delete.component.scss'
})
export class CarRentalAdminDeleteComponent {
showToast=false;
@Input()id:any;
@Output()deleteEmitted=new EventEmitter<any>();
modal=inject(NgbModal);
constructor(private carRental:CarRentalService){}
delete1(id:any)
{
  this.carRental.deleteCarRental(id).subscribe({
    next:(response)=>{
      this.modal.dismissAll(this.showToast=true);
      this.deleteEmitted.emit();
    }
  })
}
close()
{
  this.modal.dismissAll();
}
}
