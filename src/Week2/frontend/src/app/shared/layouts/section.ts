import { Component, input } from '@angular/core';
import { RouterLink, RouterOutlet, RouterLinkActive } from '@angular/router';
import { NavLink } from '../types';

@Component({
  selector: 'app-shared-section',
  imports: [RouterOutlet, RouterLink, RouterLinkActive],
  template: `
    <div class="flex flex-col">
      <h2>{{ sectionTitle() }}</h2>
      <div role="tablist" class="tabs tabs-lift">
        @for (link of links(); track link.path) {
          <a
            class="tab"
            role="tab"
            routerLinkActive="tab-active"
            [routerLinkActiveOptions]="{ exact: true }"
            [routerLink]="link.path"
            >{{ link.text }}</a
          >
        }
      </div>
      <div class="p-4 bg-base-300">
        <ng-content />
        <router-outlet />
      </div>
    </div>
  `,
  styles: ``,
})
export class Section {
  sectionTitle = input('Section'); // optional - will be 'Section' by default
  links = input.required<NavLink[]>(); // required, you must give me these.
}
