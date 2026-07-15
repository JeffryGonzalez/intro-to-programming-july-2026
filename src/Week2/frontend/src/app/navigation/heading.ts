import { Component, signal } from '@angular/core';

import { NavEnd } from './nav-end';
import { Expando } from '../shared/icons/expando';
import { NavLink as Linky } from '../shared/types';
import { NavLink } from './nav-link';

@Component({
  selector: 'app-heading',
  imports: [NavLink, NavEnd, Expando],
  templateUrl: './heading.html',

  styles: ``,
})
export class Heading {
  protected readonly links = signal<Linky[]>([
    {
      path: 'home',
      text: 'Home',
    },
    {
      path: 'learning',
      text: 'Learning Stuff',
    },
    {
      path: 'shows',
      text: 'Shows',
    },
    {
      path: 'about',
      text: 'About Us',
    },
  ]);
}
