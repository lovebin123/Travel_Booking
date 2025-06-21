import { Component, Input, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/Account/auth.service';
import {faUser} from "@fortawesome/free-solid-svg-icons";
import { NgbDropdown, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TabsComponent } from "../nav-tabs/tabs.component";
@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FontAwesomeModule, NgbDropdownModule, TabsComponent,RouterLink],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  @Input()firstName='';
  faUser=faUser;
    constructor(private router:Router,private auth:AuthService){}

  logout()
  {
    this.auth.logout();
  }
  hero() {
  this.router.navigateByUrl('/hero');
}

}
