import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-flight-user',
  standalone: true,
  imports: [],
  templateUrl: './flight-user.component.html',
  styleUrl: './flight-user.component.scss'
})
export class FlightUserComponent implements OnInit {
  @Input() user:any={};
  @Input() no_of_adults:any;
  @Input()no_of_children:any;
  fullname='';
ngOnInit(): void {
  this.fullname=this.user.firstName+" "+this.user.lastName;
}

}
