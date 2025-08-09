import { Component, ElementRef, EventEmitter, inject, Input, OnInit, Output, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { createHotelBooking } from '../../../../../common/models/createHotelBooking';
import { DateTimeService } from '../../../../../common/services/DateTime/date-time.service';
import { HotelBookingServiceService } from '../../../../../common/services/Hotels/HotelBooking/hotel-booking-service.service';

@Component({
  selector: 'app-hotel-list',
  standalone: false,
  templateUrl: './hotel-list.html',
  styleUrl: './hotel-list.css'
})
export class HotelList implements OnInit{
constructor(private hotelBooking:HotelBookingServiceService,private router:Router,private dateService:DateTimeService,private modal:NgbModal){}
  loveBtnClicked=0;
  @Input()hotelData:any;
  @Input()CheckinCheckout:any;
  @Input()id:any;
  @Input()roomAdults:any;
  @Input()price:any;
  @Input()type:any;
  @Input()data:any={};
  date1={date:'',month:'',day:'',year:''};
  date2={date:'',month:'',day:'',year:''};
  @ViewChild ('loveBtn',{static:false}) loveBtn!:ElementRef;
  createHotelBooking:createHotelBooking={
    check_in_date:'',
    check_out_date:'',
    no_of_adults:'',
    no_of_children:'',
    no_of_rooms:''
  }
  no_of_stars:any;
  showToast=false;
ngOnInit(): void {
  if(this.data!=undefined)
  {
  this.date1=this.dateService.findDateTime(this.data.check_in_date);
    this.date2=this.dateService.findDateTime(this.data.check_out_date);
 this.no_of_stars=Array(+this.hotelData.no_of_stars);
  }
}
@Output()updateEmitted=new EventEmitter<any>();
handleEmitter(event:any)
{
  this.updateEmitted.emit(event);
}
handleDeleteEmitter(event:any)
{
  console.log(event);
  this.deleteEmitted.emit(event);
}
bookHotel(id:any,content:TemplateRef<any>)
{
  this.createHotelBooking.check_in_date=this.CheckinCheckout.checkin;
  this.createHotelBooking.check_out_date=this.CheckinCheckout.checkout;
  this.createHotelBooking.no_of_adults=this.roomAdults.adults;
  this.createHotelBooking.no_of_children=this.roomAdults.children;
  this.createHotelBooking.no_of_rooms=this.roomAdults.rooms;
  this.hotelBooking.postHotelBooking(id,this.createHotelBooking).subscribe({
    next:(response:any)=>{
      response=response.result;
      this.modal.open(content,{size:'lg',centered:true});
      this.data=response;
          },
    error:(error:any)=>{
      this.showToast=true;
    }
  })
}
pay(id:any)
{
  this.hotelBooking.createSession(id).subscribe({
    next:(response:any)=>{
      response=response.result;
      document.location.href=response.url;
    }
  })
}
navToPayment()
{
  this.router.navigate(['dashboard/hotelTicket'],{state:{id:this.data.paymentId}});
}
loveClick()
{
  const btn=this.loveBtn.nativeElement;
  if(this.loveBtnClicked==0)
  {
    btn.style.color='red';
    this.loveBtnClicked=1;
  }
  else{
    btn.style.color='black';
    this.loveBtnClicked=0;
  }

}
editSuccessfull=false;
deletionSuccessfull=false;
@Output()editEmitted=new EventEmitter<any>();
@Output()deleteEmitted=new EventEmitter<any>();
edit(content:TemplateRef<any>,id:any)
{
  const modalRef=this.modal.open(content,{centered:true,size:'lg'});
  modalRef.result.catch((data)=>{
    this.editSuccessfull=data;
    this.editEmitted.emit();
  })
}
modal2=inject(NgbModal);
delete1(content:TemplateRef<any>)
{
  const modalRef=this.modal2.open(content,{centered:true,size:'sm'});
  modalRef.result.catch((data)=>{
    this.deletionSuccessfull=data;
  })
}
 
}
