import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-hotel-adults-rooms',
  standalone: false,
  templateUrl: './hotel-adults-rooms.html',
  styleUrl: './hotel-adults-rooms.css'
})
export class HotelAdultsRooms {
roomAdults={rooms:'1',adults:'1',children:'0'};
  @Output()roomEmitter=new EventEmitter<any>();
  findVals()
  {
    this.roomEmitter.emit(this.roomAdults);
  }
}
