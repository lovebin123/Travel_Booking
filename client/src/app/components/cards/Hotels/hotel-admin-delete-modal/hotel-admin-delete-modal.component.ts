import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModal, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { HotelServiceService } from '../../../../services/Hotels/hotel-service.service';

@Component({
  selector: 'app-hotel-admin-delete-modal',
  standalone: true,
  imports: [NgbToastModule,CommonModule,FormsModule],
  templateUrl: './hotel-admin-delete-modal.component.html',
  styleUrl: './hotel-admin-delete-modal.component.scss'
})
export class HotelAdminDeleteModalComponent {
@Input()id: any;
constructor(private hotel:HotelServiceService,private modal:NgbModal){}
showToast=false;
@Output()deleteEmitted=new EventEmitter<any>;
delete1(id:any)
{
  console.log(this.id);
  this.hotel.deleteHotel(id).subscribe({
    next:(response)=>{
        const msg="Successful";
  this.deleteEmitted.emit(msg);
  this.modal.dismissAll(this.showToast=true);
    }
  })
}
close()
{
  this.modal.dismissAll();
}
}
