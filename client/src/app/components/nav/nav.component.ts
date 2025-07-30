import { Component, Input, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../services/Account/auth.service';
import {faUser} from "@fortawesome/free-solid-svg-icons";
import { NgbDropdown, NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { TabsComponent } from "../nav-tabs/tabs.component";
import { CookieService } from 'ngx-cookie-service';
@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FontAwesomeModule, NgbDropdownModule, TabsComponent,RouterLink],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  role=localStorage.getItem('role');
  @Input()firstName='';
  faUser=faUser;
    constructor(private router:Router,private auth:AuthService,private cookieService:CookieService){}

  logout()
  {
    this.auth.logout();
  }
  hero() {
  if(this.role==='User')
  this.router.navigateByUrl('/dashboard');
else
  this.router.navigate(['/admin'])
}
viewProfile()
{
  this.router.navigate(['/editProfile'])
}

}
