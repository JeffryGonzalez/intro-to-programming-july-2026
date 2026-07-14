import { Component, inject } from '@angular/core';
import { ShowsData } from '../features/shows/shows-data';

@Component({
  selector: 'app-about',
  imports: [],
  providers: [ShowsData],
  template: ` <p>about works!</p> `,
  styles: ``,
})
export class About {
  svc = inject(ShowsData);
}
