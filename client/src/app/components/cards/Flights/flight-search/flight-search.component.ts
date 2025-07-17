import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { AsyncPipe, CommonModule, JsonPipe} from '@angular/common';
import { EventEmitter,Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbDatepickerModule, NgbDateStructAdapter, NgbPopover, NgbPopoverModule, NgbTypeaheadModule,NgbDateStruct, NgbAlertModule, NgbDatepicker, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { debounceTime, distinctUntilChanged, map, Observable, of, OperatorFunction } from 'rxjs';
import { FlightsService } from '../../../../services/Flights/flights.service';
import { DateTimeService } from '../../../../services/DateTime/date-time.service';
import { FlightFromComponent } from "../../../searchComponent/Flights/flight-from/flight-from.component";
import { FlightToComponent } from "../../../searchComponent/Flights/flight-to/flight-to.component";
import { FlightDestinationDateComponent } from "../../../searchComponent/Flights/flight-destination-date/flight-destination-date.component";
import { FlightPassengarComponent } from "../../../searchComponent/Flights/flight-passengar/flight-passengar.component";
@Component({
  selector: 'app-flight-search',
  standalone: true,
  imports: [AsyncPipe, NgbAlertModule, JsonPipe, NgbPopoverModule, NgbToastModule,CommonModule, FormsModule, NgbPopoverModule, NgbTypeaheadModule, NgbDatepickerModule, NgbDatepicker, FlightFromComponent, FlightToComponent, FlightDestinationDateComponent, FlightPassengarComponent],
  templateUrl: './flight-search.component.html',
  styleUrl: './flight-search.component.scss',
    providers:[{
        provide:DateTimeService,
        useFactory:()=>new DateTimeService()
      }],
})
export class FlightSearchComponent   {
  constructor(private flights:FlightsService){}
  @Output() flightSearched=new EventEmitter<any>();
  @Output() passengerDetails=new EventEmitter<any>();
  locations:Set<string>=new Set<string>();
  showToast:boolean=false;
  name='';
  name1='';
  searchClicked=false;
  flightDetails={source:'',destination:'',date_of_departure:'',seatType:''};
  travellerDetails:any;
    handleFrom(data:any)
  {
   this.flightDetails.source=data?.name; 
  }
  handleTo(data:any)
  {
    this.flightDetails.destination=data?.name;
  }
  handleLocations(data:any)
  {
    this.locations=data;
  }
  handleDateofDeparture(data:any)
  {
    this.flightDetails.date_of_departure=data;
  }
  handlePassengerDetails(data:any)
  {
      
    this.travellerDetails=data;

  }
  handleSeatType(data:any)
  {
    this.flightDetails.seatType=data;
    
  }
swap() {
  let temp = this.flightDetails.source;
  this.flightDetails.source = this.flightDetails.destination;
  this.flightDetails.destination = temp;
  console.log(this.flightDetails.source, this.flightDetails.destination);
}
flightsFromQuery$: any=[];
printVals()
{
  if(!this.flightDetails.source ||!this.flightDetails.destination||!this.flightDetails.date_of_departure||!this.flightDetails.seatType|| !this.travellerDetails)
  {
    this.showToast=true;
    return;
  }
this.flights.getByQuery(this.flightDetails).subscribe({
  next:(response:any)=>{
    response=response.result;
    if(!this.travellerDetails)
    {
      this.showToast=true;
      return;
    }
    this.flightSearched.emit(response);
    this.passengerDetails.emit(this.travellerDetails);
  },
  error:(error)=>{
    this.showToast=true
  }
})
}
}
