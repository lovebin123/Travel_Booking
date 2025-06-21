import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-hotel-details',
  standalone: true,
  imports: [],
  templateUrl: './hotel-details.component.html',
  styleUrl: './hotel-details.component.scss'
})
export class HotelDetailsComponent implements OnInit{
ngOnInit(): void {
this.no_stars_active=Array(+this.data.no_of_stars);
this.no_stars_inactive=Array(5 - +this.data.no_of_stars);
console.log(this.no_stars_inactive);
}
@Input()data:any;
no_stars_active:any;
no_stars_inactive:any;
}
