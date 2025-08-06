import { Component, forwardRef, Input } from '@angular/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

@Component({
  selector: 'app-input-field',
  imports: [],
  providers: [{
    provide: NG_VALUE_ACCESSOR,
    useExisting: forwardRef(() => InputField),
    multi: true
  }],
  standalone: true,
  templateUrl: './input-field.html',
  styleUrl: './input-field.css'
})
export default class InputField implements ControlValueAccessor{

 @Input() id: string | null = '';
  @Input() name: string | null = null;
  @Input() placeholder: string | null = null;
  @Input() type: 'email' | 'password' | 'text' | 'number' = 'text';
  @Input() required = false;
  @Input() class: string = '';

  value: string | null = null;
  isDisabled = false;

  onTouched: () => void = () => {};
  onChange: (value: string) => void = () => {};

  writeValue(obj: any): void {
    this.value = obj;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState(isDisabled: boolean): void {
    this.isDisabled = isDisabled;
  }

  onInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    this.value = input.value;
    this.onChange(this.value);
    this.onTouched();
  }
}