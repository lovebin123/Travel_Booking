import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbPopover, NgbPopoverModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { debounceTime, distinctUntilChanged, map, Observable } from 'rxjs';
import { FlightsService } from '../../../../services/Flights/flights.service';

@Component({
  selector: 'app-flight-from',
  standalone: true,
  imports: [FormsModule,CommonModule,NgbPopoverModule,NgbTypeaheadModule],
  templateUrl: './flight-from.component.html',
  styleUrl: './flight-from.component.scss'
})
export class FlightFromComponent implements OnInit {
  @Input()fromData:any;
  @Output()handleFromEmitter=new EventEmitter<any>();
  @Output()handleLocationsSetEmitter=new EventEmitter<any>();
    from:any='';
  constructor(private flights:FlightsService){}
  locations:Set<string>=new Set<string>();
  sources:any=[];
   get airports(): { name: string }[] {
    return Array.from(this.locations).map(name => ({ name }));
  }
    ngOnInit(): void {
      this.flights.getSources().subscribe((response)=>{
        response=response.result;
      for(let i=0;i<response.length;i++)
      {
          this.locations.add(response[i]);
      }
      })
      this.flights.getDestinations().subscribe((response)=>{
        response=response.result.result;
        for(let i=0;i<response.length;i++)
        this.locations.add(response[i]);
      })
    }
  onSourceSelection(from:any)
{
  this.locations.delete(from.name);
  this.handleFromEmitter.emit(from);
  this.handleLocationsSetEmitter.emit(this.locations);
  console.log(this.locations);
}
search = (text$: Observable<string>) =>
  text$.pipe(
    debounceTime(200),
    distinctUntilChanged(),
    map(term =>
      term.length < 2 ? [] :
      this.airports.filter(v => v.name.toLowerCase().includes(term.toLowerCase())).slice(0, 10)
    )
  );

formatter = (result: { name: string }) => result.name;
}
