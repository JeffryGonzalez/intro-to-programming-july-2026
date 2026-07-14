import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

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
export class Learning {}
