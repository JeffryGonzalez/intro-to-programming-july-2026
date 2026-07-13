import { Component, input, output } from '@angular/core';

@Component({
  selector: 'app-toggle-button',
  imports: [],
  template: `
    <button
      (click)="wasClicked.emit()"
      [disabled]="toggled() === false"
      class="btn btn-primary uppercase p-2 m-8"
    >
      {{ text() }}
    </button>
  `,
  styles: ``,
})
export class ToggleButton {
  toggled = input.required<boolean>();
  text = input('Click Me');

  wasClicked = output();
}
