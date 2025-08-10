import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.html',
  styleUrl: './button.css'
})
export class Button{
  @Input() type: 'submit' | 'reset' | 'button' = 'button';
  @Input() disabled = false;
  @Input() text = 'Button';
  @Input() severity: 'primary' | 'secondary' | 'danger' | 'success' = 'primary';
  @Input() width='';
  @Input()height='';
  @Input()backgroundColor='';

  get classes() {
    const cls = ['btn', 'fs-4', 'text-white'];
    switch (this.severity) {
      case 'primary':
        cls.push('btn-secondary');
        break;
      case 'secondary':
        cls.push('btn-secondary');
        break;
      case 'danger':
        cls.push('btn-danger');
        break;
      case 'success':
        cls.push('btn-success');
        break;
    }
    return cls;
  }
}
