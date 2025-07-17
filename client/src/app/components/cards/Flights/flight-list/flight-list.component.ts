import { Component, Input, OnChanges, SimpleChanges, ViewChild,Output,EventEmitter, inject, TemplateRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgbActiveModal, NgbModal,NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { FlightBookingComponent } from '../../../../pages/Flights/flight-booking-modal/flight-booking.component';
import { FlightBookingService } from '../../../../services/Flights/FlightBooking/flight-booking.service';
import { FlightAdminAddUpdateModalComponent } from "../flight-admin-add-update-modal/flight-admin-add-update-modal.component";
import { FlightDeleteAdminComponent } from '../flight-delete-admin/flight-delete-admin.component';
import { Router } from '@angular/router';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';
@Component({
  selector: 'app-flight-list',
  standalone: true,
  imports: [CommonModule, FormsModule, NgbToastModule, FlightBookingComponent, FlightAdminAddUpdateModalComponent,FlightDeleteAdminComponent],
  templateUrl: './flight-list.component.html',
  providers: [
    NgbActiveModal,
],
  styleUrl: './flight-list.component.scss'
})
export class FlightListComponent implements OnChanges {
  private modal=inject(NgbModal);
  private addUpdateModal=inject(NgbModal);
  constructor(private flightBooking:FlightBookingService,private modalService:NgbModal,private activeModal:NgbActiveModal,private router:Router,private dateTime:DateTimeService){}
@Input() name: string = '';
  @Input()time_of_departure: string = '';
  @Input()source: string = '';
  @Input()time_of_arrival: string = '';
  @Input()destination: string = '';
  @Input()price: number = 0; 
  @Input()date_of_departure:any;
  @Input()id:number=0;
  @Input()data1:any;
  @Input()isBooked:any;
  @Input()paymentId:any;
  @Input()btnTitle:string='';
  @Input()no_of_adults:string='1';
  @Input()no_of_children:string='0';
  @Output()btnClick=new EventEmitter<void>();
  diff:string='';
  data:any={};
  flightBooked=[];
  bookingId:any;
  dateDetails={date:'',day:'',month:'',year:''}
  userBooked=[];
  showToast=false;
  f1:number=0;
  t1:number=0;
  tra:number=0;
  dep1:number=0;
  a1:number=0;
  c1:number=0;
  showToast1=false;
  padZero(n: number): string {
  return n < 10 ? '0' + n : n.toString();
}

  ngOnChanges(): void {
    if(this.date_of_departure!=undefined)
    this.dateDetails=this.dateTime.findDateTime(this.date_of_departure);
    const time_of_departure=this.time_of_departure;
    const time_of_arrival=this.time_of_arrival;
    const [hours1,minutes1]=time_of_departure.split(":").map(Number);
    const dataObj1=new Date();
    dataObj1.setHours(hours1,minutes1);
    const [hours2,minutes2]=time_of_arrival.split(":").map(Number);
    const dataObj2=new Date();
    dataObj2.setHours(hours2,minutes2);
  const diffMs=dataObj2.getTime()-dataObj1.getTime();
    const diffMinutes = Math.floor(diffMs / 60000);
const hours = Math.floor(diffMinutes / 60);
const minutes = diffMinutes % 60;
this.diff = `${this.padZero(hours)}:${this.padZero(minutes)}`;

  }
  onClick()
  {
    this.btnClick.emit();
  }
  bookFlight(id:any,content:TemplateRef<any>)
  {
    console.log(this.data1);
    this.flightBooking.postFlightBooking(id,this.no_of_adults,this.no_of_children).subscribe({
      next:(response:any)=>{
        response=response.result;
        this.modal.open(content,{size:'lg',centered:true});
        this.data=response;
        this.flightBooked=this.data.flight;
        this.userBooked=this.data.appUser;
        this.bookingId=this.data.id;
      },
      error:()=>{
        this.showToast=true;
      }
    })
  }

  pay(id:number)
{
  this.flightBooking.goToPayement(id).subscribe(
    (response:any)=>{
      response=response.result;
      document.location.href=response.url;
    }
  )
}
editSuccessful=false;
deletionSuccessfull=false;
edit(id:any,content:TemplateRef<any>)
{
  const modelRef=this.addUpdateModal.open(content,{centered:true,size:'lg'});
  modelRef.result.catch((response)=>{
    this.editSuccessful=response;
  })
}
@Output()editEmitter=new EventEmitter<any>();
@Output()deleteEmitter=new EventEmitter<any>();
handleEditEmiiter(event:any)
{
  this.editEmitter.emit(event);
}
delete(id:any,content:TemplateRef<any>)
{
  const modalRef=this.modalService.open(content,{centered:true,size:'sm'});
  modalRef.result.catch((data)=>{
   this.deletionSuccessfull=data;
  })
}
handleDeleteEmitter(event:any)
{
    this.deleteEmitter.emit(event);
}
  navToPayment()
{
  this.router.navigate(['flightTicket'],{state:{id:this.paymentId}});
}
  
}
