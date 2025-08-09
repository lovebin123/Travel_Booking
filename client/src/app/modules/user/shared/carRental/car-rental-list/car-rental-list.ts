import { Component, EventEmitter, inject, Input, Output, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { createCarRentalBooking } from '../../../../../common/models/createCarRentalBooking';
import { CarRentalBookingService } from '../../../../../common/services/CarRental/CarRentalBooking/car-rental-booking.service';

@Component({
  selector: 'app-car-rental-list',
  standalone: false,
  templateUrl: './car-rental-list.html',
  styleUrl: './car-rental-list.css'
})
export class CarRentalList {
 constructor(private carRental:CarRentalBookingService,private router:Router){}
  private modal=inject(NgbModal);
  carData:any={};
  @Input()type:any;
 diff:any;
 showToast=false;
 @Input()carRentaldata:any;
 @Input()data:any;
 @Input()pickupdate:any;
 @Input()price:any;
 @Input()dropoffdate:any;
  @Input()pickuptime:any;
 @Input()dropofftime:any;
 createCarRentalBooking:createCarRentalBooking={
  diff:0,
  dropoffDate:'',
  dropoffTime:'',
  pickupDate:'',
  pickupTime:''
 };
  ngOnInit(): void {
    if(this.carRentaldata===undefined)
    {
    let date1=new Date(this.pickupdate);
    let date2=new Date(this.dropoffdate);
    let diffInMins=date2.getTime()-date1.getTime();
    this.diff=diffInMins/(1000*3600*24);
    }
    else{
      let date1=new Date(this.carRentaldata.bookedFromDate);
    let date2=new Date(this.carRentaldata.bookedTillDate);
    let diffInMins=date2.getTime()-date1.getTime();
    this.diff=diffInMins/(1000*3600*24);
    }
}
book(id:any,content:TemplateRef<any>)
{
  this.createCarRentalBooking.diff=this.diff;
  this.createCarRentalBooking.dropoffDate=this.dropoffdate;
  this.createCarRentalBooking.pickupDate=this.pickupdate;
  this.createCarRentalBooking.pickupTime=this.pickuptime;
  this.createCarRentalBooking.dropoffTime=this.dropofftime;
this.carRental.createBooking(id,this.createCarRentalBooking).subscribe({
  next:(response:any)=>{
    console.log(response.result);
      this.modal.open(content,{size:'lg',centered:true});
    this.carData=response.result;
  },
  error:(error)=>{
    this.showToast=true;
  }
});
}
pay(id:any)
{
  this.carRental.createCheckout(id).subscribe({
    next:(response:any)=>{
      console.log(response);
      response=response.result;
      document.location.href=response.url;
    }
  })
}
navToPayment()
{
  console.log(this.carRentaldata);
  this.router.navigate(['dashboard/carRentalTicket'],{state:{id:this.carRentaldata.paymentId}});
}
editModal=inject(NgbModal);
editSuccessfull=false;
@Output()editEmitted=new EventEmitter<any>();
handleChange(event:any)
{
  this.editEmitted.emit(event);
}
edit(content:TemplateRef<any>)
{
  const modalRef=this.editModal.open(content,{centered:true,size:'lg'});
  modalRef.result.catch((response)=>{
    this.editSuccessfull=response;
  })
}
deletionSuccessfull=false;
delete1(content:TemplateRef<any>)
{
   const modalRef=this.modal.open(content,{centered:true,size:'sm'});
  modalRef.result.catch((data)=>{
    this.deletionSuccessfull=data;
  })
}

}
