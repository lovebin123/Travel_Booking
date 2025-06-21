import { ChangeDetectorRef, Component, inject, OnDestroy, OnInit, TemplateRef } from '@angular/core';
import { FlightsService } from '../../../services/Flights/flights.service';
import { FlightListComponent } from "../../../components/cards/Flights/flight-list/flight-list.component";
import { NgbModal, NgbToastModule } from '@ng-bootstrap/ng-bootstrap';
import { FlightAdminAddUpdateModalComponent } from "../../../components/cards/Flights/flight-admin-add-update-modal/flight-admin-add-update-modal.component";
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-flight-admin',
  standalone: true,
  imports: [FlightListComponent, FlightAdminAddUpdateModalComponent,NgbToastModule,CommonModule],
  templateUrl: './flight-admin.component.html',
  styleUrl: './flight-admin.component.scss'
})
export class FlightAdminComponent implements OnInit,OnDestroy {
  constructor(private flights:FlightsService,private cd:ChangeDetectorRef){}
  ngOnDestroy(): void {
  }
  private addModal=inject(NgbModal);
  data:any={};
  additionSuccessful=false;
  ngOnInit(): void {
   this.loadData();
  }
  loadData():void
  {
    this.flights.getAllFlights().subscribe({
      next:(respose)=>{
        this.data=respose;

      }
    })
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

}
