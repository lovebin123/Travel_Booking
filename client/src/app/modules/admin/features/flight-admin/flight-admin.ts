import { ChangeDetectorRef, Component, inject, OnChanges, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subscription } from 'rxjs';
import { FlightsService } from '../../../../services/Flights/flights.service';

@Component({
  selector: 'app-flight-admin',
  standalone: false,
  templateUrl: './flight-admin.html',
  styleUrl: './flight-admin.css'
})
export class FlightAdmin implements OnInit,OnDestroy{
constructor(private flights:FlightsService,private cd:ChangeDetectorRef){}
  ngOnDestroy(): void {
    this.adminFlightData.unsubscribe();
  }
  private addModal=inject(NgbModal);
  data:any={};
  searchQuery:any;
  additionSuccessful=false;
  totalRecords=0;
  pageSize=10;
  page=1;
  adminFlightData!:Subscription
  ngOnInit(): void {
   this.loadData();
  }
  loadData():void
  {
    this.adminFlightData=this.flights.getAllFlights(this.page,this.pageSize).subscribe({
      next:(respose:any)=>{
        respose=respose.result;
        console.log(respose);
        this.data=respose.flights;
        this.totalRecords=respose.totalCount;
        console.log(this.totalRecords);
      }
    })
  }
  onPageChange(page:number)
  {
    this.page=page;
    this.loadData();
  }
  handleChange(event:any)
  {
    this.loadData()
  }

  addFlights(content:TemplateRef<any>)
  {
    const modalRef=this.addModal.open(content,{centered:true,size:'lg'});
    modalRef.result.catch((response)=>{
      this.additionSuccessful=response;
    })
  } 
searchByFlightName()
{
  this.flights.searchByFlightName(this.searchQuery).subscribe({
    next:(response:any)=>{
      response=response.result;
      console.log(response);
      this.data=response;
    }
  })
}
}
