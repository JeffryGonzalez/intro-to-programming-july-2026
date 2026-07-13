import { Component, input } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav-link',
  imports: [RouterLink, RouterLinkActive],
  template: `
    <a [routerLinkActive]="['font-bold', 'border-b-2', 'opacity-60']" [routerLink]="link().path">{{
      link().text
    }}</a>
  `,
  styles: ``,
})
export class NavLink {
  // what this is saying is when you use this component, you MUST give it a link wich has a path and text
  link = input.required<{ path: string; text: string }>();
}
