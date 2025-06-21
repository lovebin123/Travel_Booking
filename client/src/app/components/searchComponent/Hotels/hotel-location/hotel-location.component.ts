import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { NgbPopoverModule,NgbTypeaheadModule } from '@ng-bootstrap/ng-bootstrap';
import { debounceTime, distinctUntilChanged, map, Observable } from 'rxjs';
import { HotelServiceService } from '../../../../services/Hotels/hotel-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-hotel-location',
  standalone: true,
  imports: [NgbPopoverModule,NgbTypeaheadModule,FormsModule,CommonModule],
  templateUrl: './hotel-location.component.html',
  styleUrl: './hotel-location.component.scss'
})
export class HotelLocationComponent implements OnInit{
  @Output()locationClicked=new EventEmitter<any>();
  locationName:any;
  locations:Set<string>=new Set<string>();
  constructor(private hotelService:HotelServiceService){}
  ngOnInit(): void {
   this.hotelService.getHotelLocations().subscribe((response)=>{
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
