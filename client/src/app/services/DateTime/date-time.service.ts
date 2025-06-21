import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DateTimeService {
  constructor() {}

  private dayNames = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
  private monthNames = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

  findDateTime(dateStr: string) {
    const date = new Date(dateStr);

    return {
      date: date.getDate().toString(),
      month: this.monthNames[date.getMonth()],
      day: this.dayNames[date.getDay()],
      year: date.getFullYear().toString()
    };
  }
}
