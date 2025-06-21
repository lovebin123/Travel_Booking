import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbPopoverModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-hotel-adults-rooms',
  standalone: true,
  imports: [NgbPopoverModule,CommonModule,FormsModule],
  templateUrl: './hotel-adults-rooms.component.html',
  styleUrl: './hotel-adults-rooms.component.scss'
})
export class HotelAdultsRoomsComponent{
  roomAdults={rooms:'1',adults:'1',children:'0'};
  @Output()roomEmitter=new EventEmitter<any>();
  findVals()
  {
    this.roomEmitter.emit(this.roomAdults);
    console.log(this.roomAdults);
  }
}
