import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-hotel-user',
  standalone: true,
  imports: [],
  templateUrl: './hotel-user.component.html',
  styleUrl: './hotel-user.component.scss'
})
export class HotelUserComponent {
@Input()data:any={};
}
