import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.html',
  styleUrl: './page-not-found.css',
  standalone:true,
  imports:[],
})
export class PageNotFound {
constructor(private router:Router){}
  goHome()
{
  this.router.navigate(['/']);
}
}
