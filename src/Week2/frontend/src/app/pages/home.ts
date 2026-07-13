import { Component } from '@angular/core';
import { Bio } from './bio/bio';

@Component({
  selector: 'app-home',
  imports: [Bio],
  template: `
    <p>home works!</p>
    <button>Click ME</button>
    <app-bio />
    <button>Click ME</button>
  `,
  styles: ``,
})
export class Home {}
