import { Component, signal } from '@angular/core';
import { Section } from '../../shared/layouts/section';
import { NavLink } from '../../shared/types';

@Component({
  selector: 'app-shows',
  imports: [Section],
  template: `
    <app-shared-section sectionTitle="Shows!" [links]="links()">
      <div class="p-2">
        <h3 class="text-xl">All Things to Do With Shows!</h3>
      </div>
    </app-shared-section>
  `,
  styles: ``,
})
export class Shows {
  links = signal<NavLink[]>([
    {
      path: '.',
      text: 'Home',
    },
    {
      path: 'add',
      text: 'Add A Show',
    },
  ]);
}
