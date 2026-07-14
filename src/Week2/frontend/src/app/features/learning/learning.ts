import { Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ShowsData } from '../shows/shows-data';

@Component({
  selector: 'app-learning',
  imports: [RouterLink, RouterOutlet],
  template: `
    <div class="flex flex-col">
      <div class="flex flex-row">
        <a class="btn btn-link p-x-8" routerLink="/learning/">Home</a>
        <a class="btn btn-link p-x-8" routerLink="signals">Signals</a>
      </div>
      <div>
        <router-outlet />
      </div>
    </div>
  `,
  styles: ``,
})
export class Learning {
  svc = inject(ShowsData);
}
