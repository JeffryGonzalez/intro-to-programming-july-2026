import { Component, inject } from '@angular/core';
import { providers } from '../types';
import { ShowsData } from '../shows-data';

@Component({
  selector: 'app-shows-filter',
  imports: [],
  template: `
    <div class="filter pb-4">
      <input
        (click)="service.clearFilter()"
        class="btn filter-reset"
        type="radio"
        name="filter"
        aria-label="All"
      />
      @for (p of providers; track p) {
        @let pCount =
          service.showsList().filter((s) => s.streamingServices.some((s) => s === p)).length;
        <input
          type="radio"
          name="filter"
          (click)="service.setFilterBy(p)"
          class="btn "
          aria-label="{{ service.providersMap[p].display + ' (' + pCount + ')' }}"
        />
      }
    </div>
  `,
  styles: ``,
})
export class Filter {
  providers = providers;

  service = inject(ShowsData);
}
