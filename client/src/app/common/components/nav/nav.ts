import { Component, Input } from '@angular/core';
import { Router } from '@angular/router';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from '../../services/auth-service';
@Component({
  selector: 'app-nav',
  imports: [FontAwesomeModule,NgbDropdownModule],
  templateUrl: './nav.html',
  styleUrl: './nav.css'
})
export class Nav {
role=localStorage.getItem('role');
  @Input()firstName='';
  faUser=faUser;
    constructor(private router:Router,private auth:AuthService){}

  logout()
  {
    this.auth.logout();
  }
  navToBookings()
  {
    this.router.navigateByUrl('')
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
