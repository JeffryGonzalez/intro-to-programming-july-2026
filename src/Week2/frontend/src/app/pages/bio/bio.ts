import { Component, signal } from '@angular/core';
import { ToggleButton } from './toggle-button';

@Component({
  selector: 'app-bio',
  imports: [ToggleButton],
  templateUrl: './bio.html',
  styleUrl: './bio.css',
})
export class Bio {
  protected readonly toggled = signal(false);

  protected readonly offLabel = signal('Turn Off');

  toggleOff() {
    this.toggled.set(false);
  }

  toggleOn() {
    this.toggled.set(true);
  }
}
