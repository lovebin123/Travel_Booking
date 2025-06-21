import { CommonModule } from '@angular/common';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbPopoverModule, NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { HotelServiceService } from '../../../../services/Hotels/hotel-service.service';
import { debounceTime, distinctUntilChanged, map, Observable } from 'rxjs';
import { CarRentalService } from '../../../../services/CarRental/car-rental.service';

@Component({
  selector: 'app-car-rental-location',
  standalone: true,
  imports: [FormsModule,CommonModule,NgbTypeaheadModule,NgbPopoverModule],
  templateUrl: './car-rental-location.component.html',
  styleUrl: './car-rental-location.component.scss'
})
export class CarRentalLocationComponent implements OnInit{
    @Output()locationClicked=new EventEmitter<any>();
    locations:Set<string>=new Set<string>();
  constructor(private carRental:CarRentalService){}
    locationName:any;
  ngOnInit(): void {
   this.carRental.getLocations().subscribe((response)=>{
    for(let i=0;i<response.length;i++)
    {
      this.locations.add(response[i]);
    }
   });
  }
   get hotelLocations(): { name1: string }[] {
  return Array.from(this.locations).map(name1 => ({ name1 }));
}
onLocationSelection(data:any)
{
  this.locationClicked.emit(data);
}
search1 = (text1$: Observable<string>) =>
  text1$.pipe(
    debounceTime(200),
    distinctUntilChanged(),
    map(term1 =>
      term1.length < 2 ? [] :
      this.hotelLocations.filter(v => v.name1.toLowerCase().includes(term1.toLowerCase())).slice(0, 10)
    )
  );

formatter1 = (result: { name1: string }) => result.name1;
}

