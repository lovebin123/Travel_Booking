import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Observable, debounceTime, distinctUntilChanged, map } from 'rxjs';

@Component({
  selector: 'app-flight-to',
  standalone: false,
  templateUrl: './flight-to.html',
  styleUrl: './flight-to.css'
})
export class FlightTo {
  @Input()toData:any;
    to:any='';
  @Input()locations:Set<string>=new Set<string>();
  @Output()toEmiited=new EventEmitter<any>();
     get airports(): { name: string }[] {
    return Array.from(this.locations).map(name => ({ name }));
  }
    onDestinationSelection(to:any)
  {
      this.toEmiited.emit(to);
    }
search = (text$: Observable<string>) =>
  text$.pipe(
    debounceTime(200),
    distinctUntilChanged(),
    map(term =>
      term.length < 2 ? [] :
      this.airports.filter(v => v.name.toLowerCase().includes(term.toLowerCase())).slice(0, 10)
    )
  );

formatter = (result: { name: string }) => result.name;
}
