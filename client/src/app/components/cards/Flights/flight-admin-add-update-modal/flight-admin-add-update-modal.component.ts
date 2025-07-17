import { ChangeDetectorRef, Component, EventEmitter, inject, Injectable, Input, OnInit, Output } from '@angular/core';
import { Flight } from '../../../../models/flight';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ModalDismissReasons, NgbDatepickerModule, NgbDateStruct, NgbModal, NgbPopoverModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { FlightsService } from '../../../../services/Flights/flights.service';
import { FlightAdminComponent } from '../../../../pages/Flights/flight-admin/flight-admin.component';

@Component({
  selector: 'app-flight-admin-add-update-modal',
  standalone: true,
  imports: [FormsModule,CommonModule,NgbDatepickerModule,NgbToastModule],
  templateUrl: './flight-admin-add-update-modal.component.html',
  styleUrl: './flight-admin-add-update-modal.component.scss'
})
export class FlightAdminAddUpdateModalComponent implements OnInit{
  @Input()id:any;
  private modal=inject(NgbModal);
  @Output()componentEmitted=new EventEmitter<any>();
  constructor(private flight:FlightsService,private cd:ChangeDetectorRef){}
  ngOnInit(): void {
    this.cd.detectChanges();
    if(this.id!=undefined)
    {
      console.log(this.id);
      this.flight.getById(this.id).subscribe({
        next:(response)=>{
          response=response.result;
          this.data=response;
          this.flightData.date_of_departure=this.data.date_of_departure;
          this.flightData.destination=this.data.destination;
          this.flightData.name=this.data.name;
          this.flightData.no_of_seats=this.data.no_of_seats;
          this.flightData.price=this.data.price;
          this.flightData.seatType=this.data.seatType;
          this.flightData.source=this.data.source;
          this.flightData.time_of_arrival=this.data.time_of_arrival;
          this.flightData.time_of_departure=this.data.time_of_departure;
        }
      })
    }
  }
  flightData: Flight={
    name:'',time_of_arrival:'',time_of_departure:'',date_of_departure:'',no_of_seats:500,seatType:'',source:'',destination:'',price:4000
  };
  @Input()type:any;
  data:any;
  dateOfDepartureModal:NgbDateStruct | undefined;
  showToast=false;
  showToast1=false;
  findChanges()
  {
     this.flightData.date_of_departure=this.dateOfDepartureModal
  ? `${this.dateOfDepartureModal.year}-${String(this.dateOfDepartureModal.month).padStart(2, '0')}-${String(this.dateOfDepartureModal.day).padStart(2, '0')}`
  : '';
  
  }

  add()
  {
    this.flight.createFlight(this.flightData).subscribe({
      next:(response:any)=>{
        response=response.result;
        this.data=response;
        this.showToast1=true;
          this.modal.dismissAll(this.showToast1=true);
      }
    })
  }
  update(id:any,flightData:Flight)
  {
    this.flight.updateFlight(id,flightData).subscribe({
      next:(response)=>{
          this.modal.dismissAll(this.showToast=true);
          this.componentEmitted.emit(flightData);
          
      }
    })
  }
}
