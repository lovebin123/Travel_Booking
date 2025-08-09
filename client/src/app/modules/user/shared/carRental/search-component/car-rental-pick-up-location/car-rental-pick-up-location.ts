import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable, debounceTime, distinctUntilChanged, map } from 'rxjs';
import { CarRentalService } from '../../../../../../common/services/CarRental/car-rental.service';

@Component({
  selector: 'app-car-rental-pick-up-location',
  standalone: false,
  templateUrl: './car-rental-pick-up-location.html',
  styleUrl: './car-rental-pick-up-location.css'
})
export class CarRentalPickUpLocation  implements OnInit{
 @Output()locationClicked=new EventEmitter<any>();
    locations:Set<string>=new Set<string>();
  constructor(private carRental:CarRentalService){}
    locationName:any;
  ngOnInit(): void {
   this.carRental.getLocations().subscribe((response:any)=>{
    response=response.result;
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
