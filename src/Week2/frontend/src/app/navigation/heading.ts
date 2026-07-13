import { Component, signal } from '@angular/core';
import { NavLink } from './nav-link';
import { NavEnd } from './nav-end';
import { Expando } from '../shared/icons/expando';

@Component({
  selector: 'app-heading',
  imports: [NavLink, NavEnd, Expando],
  templateUrl: './heading.html',

  styles: ``,
})
export class Heading {
  protected readonly links = signal([
    {
      path: 'home',
      text: 'Home',
    },
    {
      path: 'about',
      text: 'About Us',
    },
  ]);
}
