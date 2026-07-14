import { Component, inject } from '@angular/core';
import { providers } from '../types';
import { ShowsData } from '../shows-data';

@Component({
  selector: 'app-shows-filter',
  imports: [],
  template: `
    <div class="join">
      @for (p of providers; track p) {
        <button
          [disabled]="service.getFilterBy() === p"
          (click)="service.setFilterBy(p)"
          class="btn join-item"
        >
          {{ p }}
        </button>
      }
      <button
        [disabled]="service.getFilterBy() === undefined"
        (click)="service.clearFilter()"
        class="btn join-item"
      >
        Clear
      </button>
    </div>
  `,
  styles: ``,
})
export class Filter {
  providers = providers;

  service = inject(ShowsData);
}
