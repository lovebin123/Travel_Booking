import { Component, EventEmitter, Output } from '@angular/core';
import { FlightsService } from '../../../../../common/services/Flights/flights.service';

@Component({
  selector: 'app-flight-search',
  standalone: false,
  templateUrl: './flight-search.html',
  styleUrl: './flight-search.css'
})
export class FlightSearch {
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
