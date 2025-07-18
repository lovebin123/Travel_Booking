import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { CarRental } from '../../../../models/carRentals';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CarRentalService } from '../../../../services/CarRental/car-rental.service';
import { NgbDate, NgbDatepickerModule, NgbDateStruct, NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-car-remtal-add-update-modal',
  standalone: true,
  imports: [CommonModule,FormsModule,NgbDatepickerModule],
  templateUrl: './car-remtal-add-update-modal.component.html',
  styleUrl: './car-remtal-add-update-modal.component.scss'
})
export class CarRemtalAddUpdateModalComponent implements OnInit {
  constructor(private carRental:CarRentalService){}
  ngOnInit(): void {
    if(this.id!=undefined)
    {
        this.carRental.getById(this.id).subscribe((response:any)=>{
          response=response.result;
          this.data=response;
          console.log(this.data);
          this.carRentalData.AvailableFromDate=this.data.availableFromDate;
          this.carRentalData.AvailableFromTime=this.data.availableFromTime;
          this.carRentalData.AvailableUntilDate=this.data.availableUntilDate;
          this.carRentalData.AvailableUntilTime=this.data.availableUntilTime;
          this.carRentalData.drive_type=this.data.drive_type;
          this.carRentalData.is_available=this.data.is_available;
          this.carRentalData.location=this.data.location;
          this.carRentalData.carName=this.data.car_name;
          this.carRentalData.no_of_seats=this.data.no_of_seats;
          this.carRentalData.price=this.data.price;
          this.carRentalData.rating=this.data.rating;
          this.carRentalData.user_review=this.data.user_review;
        })
    }
  }
  @Input()type:any;
  @Input()id:any;
  @Output()addEmitted=new EventEmitter<any>();
  showToast1=false;
  showToast2=false;
  data:any={};
  modal=inject(NgbModal);
carRentalData:CarRental={
  AvailableFromDate:'',
  AvailableUntilDate:'',
  drive_type:'',
  is_available:true,
  location:'',
  carName:'',
  AvailableFromTime:'',
  AvailableUntilTime:'',
  no_of_seats:5,
  price:0,
  rating:1,
  user_review:''
}
availableFromDate:NgbDateStruct|undefined;
availableToDate:NgbDateStruct|undefined;
add(carRentalData:CarRental)
{
  this.carRental.createCarRental(carRentalData).subscribe({
    next:(response)=>{
    this.addEmitted.emit();
    this.modal.dismissAll(this.showToast1=true);
    }
  })
}
findAvailableFromDate()
{
 this.carRentalData.AvailableFromDate=this.availableFromDate
  ? `${this.availableFromDate.year}-${String(this.availableFromDate.month).padStart(2, '0')}-${String(this.availableFromDate.day).padStart(2, '0')}`
  : '';
}
findAvailableToDate()
{
  this.carRentalData.AvailableUntilDate=this.availableToDate
  ? `${this.availableToDate.year}-${String(this.availableToDate.month).padStart(2, '0')}-${String(this.availableToDate.day).padStart(2, '0')}`
  : '';
}

@Output()updateEmitted=new EventEmitter<any>();
update(id:any,carRentalData:CarRental)
{
    console.log(this.carRentalData.AvailableFromDate);
    

  this,this.carRental.updateCarRental(id,carRentalData).subscribe({
    next:(response)=>{
      this.updateEmitted.emit();
      this.modal.dismissAll(this.showToast2=true);
    }
  })
}

}
