import { Component, signal } from '@angular/core';
import { Section } from '../../shared/layouts/section';
import { NavLink } from '../../shared/types';

@Component({
  selector: 'app-learning',
  imports: [Section],
  template: ` <app-shared-section title="Demos and Stuff" [links]="links()" /> `,
  styles: ``,
})
export class Learning {
  links = signal<NavLink[]>([
    {
      path: '.',
      text: 'Home',
    },
    {
      path: 'signals',
      text: 'Signals',
    },
  ]);
}
