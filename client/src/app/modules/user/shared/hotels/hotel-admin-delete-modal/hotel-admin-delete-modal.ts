import { Component, EventEmitter, Input, Output } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HotelServiceService } from '../../../../../common/services/Hotels/hotel-service.service';

@Component({
  selector: 'app-hotel-admin-delete-modal',
  standalone: false,
  templateUrl: './hotel-admin-delete-modal.html',
  styleUrl: './hotel-admin-delete-modal.css'
})
export class HotelAdminDeleteModal {
@Input()id: any;
constructor(private hotel:HotelServiceService,private modal:NgbModal){}
showToast=false;
@Output()deleteEmitted=new EventEmitter<any>;
delete1(id:any)
{
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
