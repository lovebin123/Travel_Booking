import { ChangeDetectorRef, Component, inject, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { FlightsService } from '../../../services/Flights/flights.service';
import { FlightListComponent } from "../../../components/cards/Flights/flight-list/flight-list.component";
import { NgbModal,NgbPaginationModule, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { FlightAdminAddUpdateModalComponent } from "../../../components/cards/Flights/flight-admin-add-update-modal/flight-admin-add-update-modal.component";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
@Component({
  selector: 'app-flight-admin',
  standalone: true,
  imports: [NgbPaginationModule,CommonModule,FormsModule,FlightListComponent, FlightAdminAddUpdateModalComponent,NgbToastModule,CommonModule],
  templateUrl: './flight-admin.component.html',
  styleUrl: './flight-admin.component.scss'
})
export class FlightAdminComponent implements OnInit,OnDestroy {
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
    next:(response)=>{
      response=response.result;
      console.log(response);
      this.data=response;
    }
  })
}
}
