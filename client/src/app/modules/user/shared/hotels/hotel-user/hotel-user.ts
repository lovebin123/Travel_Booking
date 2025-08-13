import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-hotel-user',
  standalone: false,
  templateUrl: './hotel-user.html',
  styleUrl: './hotel-user.css'
})
export class HotelUser {
  @Input() data: any = {};
}
