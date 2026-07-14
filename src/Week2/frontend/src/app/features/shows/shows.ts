import { Component } from '@angular/core';
import { List } from './ui/list';

@Component({
  selector: 'app-shows',
  imports: [List],
  template: ` <app-shows-list /> `,
  styles: ``,
})
export class Shows {}
