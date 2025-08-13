import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-flight-user',
  standalone: false,
  templateUrl: './flight-user.html',
  styleUrl: './flight-user.css'
})
export class FlightUser implements OnInit {
  @Input() user: any = {};
  @Input() no_of_adults: any;
  @Input() no_of_children: any;
  fullname = '';
  ngOnInit(): void {
    this.fullname = this.user.firstName + " " + this.user.lastName;
  }
}
