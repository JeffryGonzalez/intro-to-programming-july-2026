import { Component } from '@angular/core';
import { List } from '../ui/list';
import { Filter } from '../ui/filter';

@Component({
  selector: 'app-shows-home',
  imports: [List, Filter],
  template: `
    <app-shows-filter />
    <app-shows-list />
  `,
  styles: ``,
})
export class Home {}
