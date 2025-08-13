import { Component } from '@angular/core';

@Component({
  selector: 'app-hotel-home-page',
  standalone: false,
  templateUrl: './hotel-home-page.html',
  styleUrl: './hotel-home-page.css'
})
export class HotelHomePage {
  data: any;
  checkiCheckout: any;
  searchClicked = false;
  roomAdults: any;
  getAllHotels(data: any) {
    this.searchClicked = true;
    this.data = data;
  }
  getCheckinCheckout(data: any) {
    this.checkiCheckout = data;
  }
  getRoomAdults(data: any) {
    this.roomAdults = data;
  }
}
