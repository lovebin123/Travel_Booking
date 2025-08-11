import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-hotel-details',
  standalone: false,
  templateUrl: './hotel-details.html',
  styleUrl: './hotel-details.css'
})
export class HotelDetails implements OnInit {
ngOnInit(): void {
this.no_stars_active=Array(+this.data.no_of_stars);
this.no_stars_inactive=Array(5 - +this.data.no_of_stars);
}
@Input()data:any;
no_stars_active:any;
no_stars_inactive:any;
}
