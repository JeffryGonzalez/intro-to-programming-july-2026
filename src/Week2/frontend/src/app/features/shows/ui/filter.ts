import { Component, inject } from '@angular/core';
import { providers } from '../types';
import { ShowsData } from '../shows-data';

@Component({
  selector: 'app-shows-filter',
  imports: [],
  template: `
    <div class="join pb-4">
      @for (p of providers; track p) {
        @let pCount =
          service.showsList().filter((s) => s.streamingServices.some((s) => s === p)).length;
        <button
          [aria-disabled]="pCount === 0"
          (click)="service.setFilterBy(p)"
          class="btn join-item"
        >
          {{ service.providersMap[p].display }}
          <span class="opacity-70 text-xs font-extralight">({{ pCount }})</span>
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
