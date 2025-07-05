import { Component } from '@angular/core';
import { HotelSearchComponent } from "../../../components/cards/Hotels/hotel-search/hotel-search.component";
import { HotelListComponent } from "../../../components/cards/Hotels/hotel-list/hotel-list.component";

@Component({
  selector: 'app-hotel-home-page',
  standalone: true,
  imports: [HotelSearchComponent, HotelListComponent],
  templateUrl: './hotel-home-page.component.html',
  styleUrl: './hotel-home-page.component.scss'
})
export class HotelHomePageComponent {
  data:any;
  checkiCheckout:any;
  searchClicked=false;
  roomAdults:any;
  getAllHotels(data:any)
  {
    this.searchClicked=true;
    this.data=data;
  }
  getCheckinCheckout(data:any)
  {
    this.checkiCheckout=data;
  }
  getRoomAdults(data:any)
  {
    this.roomAdults=data;
  }
}
