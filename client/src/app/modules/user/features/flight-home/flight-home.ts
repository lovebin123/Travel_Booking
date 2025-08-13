import { Component } from '@angular/core';

@Component({
  selector: 'app-flight-home',
  standalone: false,
  templateUrl: './flight-home.html',
  styleUrl: './flight-home.css'
})
export class FlightHome {
  temp: any = null;
  data: any;
  searchClicked = false;
  Book: string = 'Book';
  showToast = false;
  onSearch(data: any) {
    this.searchClicked = true;
    this.temp = data;
  }
  onPlay(data: any) {
    if (!data) {
      this.showToast = true;
    }
    this.data = data;
  }
}
